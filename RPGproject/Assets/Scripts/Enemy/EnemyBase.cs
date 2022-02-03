using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
      private bool dead;
      private GameController gameController;
      private CharacterBase characterBase;
      private BoxCollider2D bodyCollider;
      private bool canActive = true;

      [Header("MultiplySpeed")]
      public float m_multiplySpeed = 1f;

      [Header("Status")]
      public float m_maxHP;
      public float m_curHP;
      public float m_regenHP;
      public Slider m_HpSlider;
      public float m_damageOrigin;              // 수치 합 전 기본 공격력.
      public float m_attackSpeedOrigin;
      public float m_moveSpeed;
      public float m_damageResult;              // 수치 계산 후 데미지
      public float m_maxHPResult;               // 수치 계산 후 체력
      
      
      private float m_currentAttackCooltime;

      [Header("Animation")]
      public Animator m_animator;
      public bool m_isMeetPlayer = false;


      public void Set(GameController _gameController, CharacterBase _characterBase)
      {
            gameController = _gameController;
            characterBase = _characterBase;
      }
      public void SetStageRate(float damageRate, float hpRate)
      {
            m_damageResult = m_damageOrigin * damageRate;
            m_maxHPResult = m_maxHP * hpRate;
      }
      void Start()
      {
            m_HpSlider.maxValue = m_maxHPResult;
            m_curHP = m_maxHPResult;
            RefreshHpBar();
            bodyCollider = GetComponent<BoxCollider2D>();
      }

      void Update()
      {
            if(characterBase == null)
            {
                  canActive = false;
            }
            if (canActive)
            {
                  // 각종 수치 감소 부분
                  if (m_currentAttackCooltime > 0)
                  {
                        m_currentAttackCooltime -= Time.deltaTime * m_multiplySpeed;
                  }


                  // Enemy Move
                  if (!m_isMeetPlayer)
                  {
                        transform.position
                              = Vector2.MoveTowards(transform.position, characterBase.transform.position
                                    , m_moveSpeed * Time.deltaTime * m_multiplySpeed);
                  }

                  // 플레이어를 공격
                  if (m_isMeetPlayer)
                  {
                        if (m_currentAttackCooltime <= 0)
                        {
                              m_animator.SetTrigger("Attack");
                              m_animator.SetFloat("AttackSpeed", m_attackSpeedOrigin * m_multiplySpeed);
                              m_currentAttackCooltime = m_attackSpeedOrigin;
                        }
                  }
            }
      }

      public void HitPlayer()
      {
            if(characterBase != null && !dead)
            {
                  Debug.Log("Enemy Attack Player");
                  characterBase.OnDamege(m_damageResult);
            }
      }

      public void MeetPlayer()
      {
            m_isMeetPlayer = true;
      }
      public void GonePlayer()
      {
            m_isMeetPlayer = false;
      }

      public void CanActive()
      {
            canActive = true;
      }
      public void CanNotActive()
      {
            canActive = false;
      }

      public void RefreshHpBar()
      {
            m_HpSlider.value = m_curHP;
      }

      public void OnDamage(float _hitDamage)
      {
            if (!dead)
            {
                  m_curHP -= _hitDamage;
                  RefreshHpBar();
                  if (m_curHP <= 0)
                  {
                        dead = true;
                        Dead();
                  }
            }
      }
      public void Dead()
      {
            CanNotActive();
            gameController.EnemyDead(this);
            bodyCollider.enabled = false;
            Destroy(gameObject, 0.5f);
      }
      public void DestroyEnemy()
      {
            Destroy(gameObject);
      }
      public void ChangeMultiplySpeed(float speed)
      {
            m_multiplySpeed = speed;
      }
}
