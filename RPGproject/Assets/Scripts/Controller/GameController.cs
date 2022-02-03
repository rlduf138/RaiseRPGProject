using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
      public GameObject playerPrefab;
      public GameObject enemyPrefab;
      public Transform playerPos;
      public Transform enemyPos;

      public CharacterBase characterBase;
      public EnemyBase enemyBase;
      public List<EnemyBase> enemyList;

      public MovingBackController movingBackController;
      [Header("MultiplySpeed")]
      public float m_multiplySpeed = 1f;

      [Header("GoldGain")]
      public float m_goldGainBase;
      public float m_goldGainResult;
      [Header("UnitEnforce")]
      public float m_unitEnforceBase;
      public float m_unitEnforceResult;

      [Header("StageNumber")]
      public int stageNumber;
      public TextMeshProUGUI text;
      public bool cleanStage = false;           // 스테이지 패배시 스테이지 정리중

      [Header("EnemyRate")]
      public float damageRate;
      public float hpRate;
      public float enemyCount;
      public float damageRateResult;
      public float hpRateResult;

      protected void Awake()
      {
            RefreshStageNumber();
            InstantiatePlayer();
            InstantiateEnemy();
      }

      protected void Update()
      {
            if (enemyList.Count == 0 && cleanStage == false)
            {
                  // 적 전멸시.
                  InstantiateEnemy();
                  stageNumber++;
                  RefreshStageNumber();
                  characterBase.FullHP();
            }
      }


      // 뒷 배경 움직이고 멈추기
      public void MoveBackGround()
      {
            movingBackController.MoveBackground();
      }
      public void StopBackGround()
      {
            movingBackController.StopBackGround();
      }

      // 플레이어 생성, 적 생성
      public void InstantiatePlayer()
      {
            //. 플레이어 생성,   시작, 사망시에 실행
            GameObject player = Instantiate(playerPrefab, playerPos.position, Quaternion.identity);
            characterBase = player.GetComponent<CharacterBase>();
            characterBase.ChangeMultiplySpeed(m_multiplySpeed);
            characterBase.Set(this);
      }
      public void InstantiateEnemy()
      {
            // 적 생성, 시작, 전멸, 플레이어 사망으로 스테이지 초기화 시 
            damageRateResult = 1 + damageRate * stageNumber;
            hpRateResult = 1 + hpRate * stageNumber;

            GameObject enemy = Instantiate(enemyPrefab, enemyPos.position, Quaternion.identity);
            enemyBase = enemy.GetComponent<EnemyBase>();
            enemyList.Add(enemyBase);
            enemyBase.Set(this, characterBase);
            enemyBase.ChangeMultiplySpeed(m_multiplySpeed);
            enemyBase.SetStageRate(damageRateResult, hpRateResult);
      }

      public void PlayerDead()
      {
            StartCoroutine(MoveBackStage());
      }
      public void EnemyDead(EnemyBase _enemy)
      {
            enemyList.Remove(_enemy);
      }
      public void DestroyAllEnemy()
      {
            for(int i = 0; i < enemyList.Count; i++)
            {
                  enemyList[i].DestroyEnemy();
            }
            enemyList.Clear();
      }
      public void RefreshStageNumber()
      {
            text.text = stageNumber.ToString() + "F";
      }

      
      /// <summary>
      /// 스테이지 실패시 돌아감
      /// </summary>
      /// <returns></returns>
      public IEnumerator MoveBackStage()
      {
            cleanStage = true;
            if(stageNumber != 1)
            {
                  stageNumber--;
            }
            RefreshStageNumber();
            DestroyAllEnemy();
            yield return new WaitForSeconds(0.5f);
            InstantiatePlayer();
            InstantiateEnemy();
            cleanStage = false;
      }

      public void CalculateBlessGold()
      {
            m_goldGainResult = m_goldGainBase + EnforceData.Instance.CalculateBlessGold();
      }
      public void CalculateBlessUnitEnforce()
      {
            m_unitEnforceResult = m_unitEnforceBase + EnforceData.Instance.CalculateBlessUnit();
      }
      public void ChangeMultiplySpeed(float speed)
      {
            m_multiplySpeed = speed;
            characterBase.ChangeMultiplySpeed(m_multiplySpeed);
            for(int i = 0; i < enemyList.Count; i++)
            {
                  enemyList[i].ChangeMultiplySpeed(m_multiplySpeed);
            }
            movingBackController.ChangeMultiplySpeed(m_multiplySpeed);
      }

      public void GoToStage(int n)
      {
            stageNumber = n;
            StartCoroutine(GoToStageCoroutine());
      }
      public IEnumerator GoToStageCoroutine()
      {
            cleanStage = true;
            Destroy(characterBase.gameObject);

            RefreshStageNumber();
            DestroyAllEnemy();
            yield return new WaitForSeconds(0.5f);
            InstantiatePlayer();
            InstantiateEnemy();
            cleanStage = false;
      }
}
