using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBase : MonoBehaviour
{
      private bool dead;
      private GameController gameController;
      private BoxCollider2D bodyCollider;
      public EnemyBase targetEnemy;

      [Header("MultiplySpeed")]
      public float m_multiplySpeed = 1f;       // 배속.

      [Header("Status")]
      public float m_maxHPBase;
      public float m_curHP;
      public float m_regenHPBase;
      public Slider m_HpSlider;                 // 체력바
      public float m_damageBase;              // 수치 합 전 기본 공격력.
      public float m_attackSpeedBase;
      public float m_criticalRateBase;
      public float m_criticalDamageBase;
      public float m_doubleAttackBase;

      public float m_attackCooltime;                       //    1f / attackspeed
      public float m_currentAttackCooltime;          //  현재 공격 쿨타임
      private float m_currentRegenCoolTime;           // 현재 회복 쿨타임

      [Header("Status")]
      public float m_maxHpResult;
      public float m_hpRegenResult;
      public float m_damageResult;
      public float m_attackSpeedResult;
      public float m_criticalRateResult;
      public float m_criticalDamageResult;
      public float m_doubleAttackResult;

      [Header("AttackMotionControl")]
      public Animator m_animator;
      public int m_attackCount;
      public int m_maxAttackCount;                    // 공격 애니메이션 종류.
      public float m_attackCountResetTime;
      public float m_currentAttackCountResetTime;
      public bool m_isMeetEnemy = false;
      

      public void Set(GameController _gameController)
      {
            gameController = _gameController;
      }

      private void Start()
      {
            m_animator.SetFloat("RunSpeed", m_multiplySpeed);
      }

      void Awake()
      {
            CalculateStatus();
            m_HpSlider.maxValue = m_maxHpResult;
            RefreshHpBar();
            bodyCollider = GetComponent<BoxCollider2D>();
            
      }

      void Update()
      {
            // 각종 수치 감소부분
            if(m_currentAttackCooltime > 0)
                  m_currentAttackCooltime -= Time.deltaTime * m_multiplySpeed;

            if(m_currentAttackCountResetTime > 0)
            {
                  m_currentAttackCountResetTime -= Time.deltaTime * m_multiplySpeed;
            }

            if(m_currentRegenCoolTime > 0)
            {
                  m_currentRegenCoolTime -= Time.deltaTime * m_multiplySpeed;
            }

            // 공격 횟수 초기화.
            if(m_currentAttackCountResetTime <= 0)
            {
                  m_attackCount = 0;
            }

            // 달리는 모션중에는 배경 이동.  적과 전투중이 아닐경우만.
            if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Run") && !m_isMeetEnemy)
            {
                
                  gameController.MoveBackGround();
            }
            else
            {
                  gameController.StopBackGround();
            }

            if (m_isMeetEnemy)
            {
                  if(m_currentAttackCooltime <= 0)
                  {
                        // DoubleAttack
                        float da = Random.Range(0f, 1f);
                        if (da < m_doubleAttackResult / 100)
                        {
                              Debug.Log("DoubleAttack");
                              m_animator.SetInteger("Attack", 2);       // 2연격 애니메이션으로 바꾸기.
                              m_animator.SetFloat("AttackSpeed", m_attackSpeedResult *m_multiplySpeed );          // 공격 속도에 따른 애니메이션 속도.
                              m_currentAttackCooltime = m_attackCooltime;  // 공격 쿨타임 초기화.
                                                                           // m_animator.SetInteger("Attack", -1);
                              m_currentAttackCountResetTime = m_attackCountResetTime;
                              m_attackCount++;
                              if (m_attackCount > m_maxAttackCount)
                              {
                                    m_attackCount = 0;
                              }
                              HitEnemy();
                        }
                        else
                        {

                              // 공격 쿨타임이 되면 공격.
                              m_animator.SetInteger("Attack", m_attackCount); // -1 = 아무상태아님.
                              m_animator.SetFloat("AttackSpeed", m_attackSpeedResult * m_multiplySpeed);          // 공격 속도에 따른 애니메이션 속도.
                              m_currentAttackCooltime = m_attackCooltime;  // 공격 쿨타임 초기화.
                                                                           // m_animator.SetInteger("Attack", -1);
                              m_currentAttackCountResetTime = m_attackCountResetTime;

                              m_attackCount++;
                              if (m_attackCount > m_maxAttackCount)
                              {
                                    m_attackCount = 0;
                              }
                              
                        }
                  }
            }

            // 체력 회복
            if(m_currentRegenCoolTime <= 0)
            {
                  // 체력이 가득차지 않았을때 회복
                  if(m_curHP < m_maxHpResult)
                  {
                        Debug.Log("체력 자동 회복량 : " + m_maxHpResult * m_hpRegenResult / 100);
                        m_curHP += m_maxHpResult * m_hpRegenResult / 100;
                        if(m_curHP > m_maxHpResult)
                        {
                              m_curHP = m_maxHpResult;
                        }
                        m_currentRegenCoolTime = 3f;
                  }
            }
      }

      public void HitEnemy()
      {
            // 적을 공격하여 데미지를 줌.
            if (targetEnemy != null && !dead)
            {
                  

                  float ran = Random.Range(0f, 1f);
                  if(ran < m_criticalRateResult / 100)
                  {
                        targetEnemy.OnDamage(m_damageResult * (m_criticalDamageResult/100) );
                        Debug.Log("Critical!!!  Dmg : " + m_damageResult * (m_criticalDamageResult/100));
                  }
                  else
                        targetEnemy.OnDamage(m_damageResult);
            }
      }

      public void InitStatus()
      {
            m_curHP = m_maxHpResult;
      }

      public void MeetEnemy(EnemyBase _targetEnemy)
      {
            targetEnemy = _targetEnemy;
            m_isMeetEnemy = true;
      }
      public void GoneEnemy()
      {
            targetEnemy = null;
            m_isMeetEnemy = false;
      }
      public void AttackAnimEvent()
      {
            m_animator.SetInteger("Attack", -1);
      }
      public void RefreshHpBar()
      {
            m_HpSlider.value = m_curHP;
      }
      public void FullHP()
      {
            m_curHP = m_maxHpResult;
            m_HpSlider.value = m_curHP;
      }

      public void OnDamege(float _hitDamage)
      {
            if (!dead && !gameController.cleanStage)
            {
                  m_curHP -= _hitDamage;
                  RefreshHpBar();
                  if (m_curHP <= 0 )
                  {
                        dead = true;
                        Dead();
                  }
            }
      }
      public void Dead()
      {
            bodyCollider.enabled = false;
            Destroy(gameObject);
            gameController.PlayerDead();
      }

      public void ChangeMultiplySpeed(float speed)
      {
            // 배속 변경
            m_multiplySpeed = speed;
            m_animator.SetFloat("RunSpeed",  m_multiplySpeed);
      }

      public void CalculateStatus()
      {
            // 강화, 가호 적용된 스테이터스 계산.
            CalculateMaxHp();
            CalculateHpRegen();
            CalculateDamage();
            CalculateCriticalRate();
            CalculateCriticalDamage();
            CalculateAttackSpeed();
            CalculateDoubleAttack();
      }
      public void CalculateMaxHp()
      {
            m_maxHpResult = (m_maxHPBase + EnforceData.Instance.CalculateGoldMaxHp()) 
                  * EnforceData.Instance.CalculateBlessMaxHp();
      }
      public void CalculateHpRegen()
      {
            m_hpRegenResult = m_regenHPBase + EnforceData.Instance.CalculateHpRegen();
      }
      public void CalculateDamage()
      {
            m_damageResult = (m_damageBase + EnforceData.Instance.CalculateGoldDamage())
                  * EnforceData.Instance.CalculateBlessDamage();
      }
      public void CalculateCriticalRate()
      {
            m_criticalRateResult = m_criticalRateBase + EnforceData.Instance.CalculateCriticalRate();
      }
      public void CalculateCriticalDamage()
      {
            m_criticalDamageResult = m_criticalDamageBase + EnforceData.Instance.CalculateCriticalDamage()
                  + EnforceData.Instance.CalculateBlessCriticalDamage();
      }
      public void CalculateAttackSpeed()
      {
            m_attackSpeedResult =(int) m_attackSpeedBase * ((EnforceData.Instance.CalculateBlessAttackSpeed() / 100 +1 ));
            m_attackCooltime = 1 / m_attackSpeedResult;
      }
      public void CalculateDoubleAttack()
      {
            m_doubleAttackResult = m_doubleAttackBase + EnforceData.Instance.CalculateBlessDoubleAttack();
      }

      public float GetMaxHp()
      {
            return m_maxHpResult;
      }
      public float GetHpRegen()
      {
            return m_hpRegenResult;
      }
      public float GetDamage()
      {
            return m_damageResult;
      }
      public float GetAttackSpeed()
      {
            return m_attackSpeedResult;
      }
      public float GetCriticalRate()
      {
            return m_criticalRateResult;
      }
      public float GetCriticalDamage()
      {
            return m_criticalDamageResult;
      }
      public float GetDoubleAttack()
      {
            return m_doubleAttackResult;
      }
}
