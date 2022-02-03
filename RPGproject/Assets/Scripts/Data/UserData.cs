using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserData : MonoBehaviour
{
      public EnforceData enforceData;
      public TextMeshProUGUI goldText;
      public TextMeshProUGUI blessText;
      [Header("Money")]
      public int goldCoin;
      public int blessCoin;

      // 데이터에 저장된 강화수치.
      [Header("GoldEnforceData")]
      public float m_goldMaxHp; // get; set; }
      public float m_goldHpRegen;
      public float m_goldDamage;
      public float m_goldCriticalRate;
      public float m_goldCriticalDamage;

      [Header("BlessEnforceData")]
      public float m_blessMaxHp;
      public float m_blessDamage;
      public float m_blessAttackSpeed;
      public float m_blessCriticalDamage;
      public float m_blessDoubleAttack;
      public float m_blessGold;
      public float m_blessUnit;

      // Start is called before the first frame update
      void Start()
      {
            RefreshGoldCoinUI();
            RefreshBlessCoinUI();
      }

      // Update is called once per frame
      void Update()
      {

      }

      public void RefreshGoldCoinUI()
      {
           // goldText.text = goldCoin.ToString();
            goldText.text = string.Format("{0:#,0}", goldCoin);
      }
      public void RefreshBlessCoinUI()
      {
          //  blessText.text = blessCoin.ToString();
            blessText.text = string.Format("{0:#,0}", blessCoin);
      }

      //Get, Set
      public void SetGoldCoin(int gold)
      {
            goldCoin = gold;
            RefreshGoldCoinUI();
      }
      public void SetBlessCoin(int bless)
      {
            blessCoin = bless;
            RefreshBlessCoinUI();
      }
      public int GetGoldCoin()
      {
            return goldCoin;
      }
      public int GetBlessCoin()
      {
            return blessCoin;
      }

      public void SetGoldMaxHp(float maxHp)
      {
            m_goldMaxHp = maxHp;
      }
      public void SetGoldHpRegen(float hpRegen)
      {
            m_goldHpRegen = hpRegen;
      }
      public void SetGoldDamage(float damage)
      {
            m_goldDamage = damage;
      }
      public void SetGoldCriticalRate(float criRate)
      {
            m_goldCriticalRate = criRate;
      }
      public void SetGoldCriticalDamage(float criDmg)
      {
            m_goldCriticalDamage = criDmg;
      }
      public float GetGoldMaxHp()
      {
            return m_goldMaxHp;
      }
      public float GetGoldHpRegen()
      {
            return m_goldHpRegen;
      }
      public float GetGoldDamage()
      {
            return m_goldDamage;
      }
      public float GetGoldCriticalRate()
      {
            return m_goldCriticalRate;
      }
      public float GetGoldCriticalDamage()
      {
            return m_goldCriticalDamage;
      }

      // Bless Set, Get
      public void SetBlessMaxHp(float maxhp)
      {
            m_blessMaxHp = maxhp;
      }
      public void SetBlessDamage(float damage)
      {
            m_blessDamage = damage;
      }
      public void SetBlessAttackSpeed(float attackspeed)
      {
            m_blessAttackSpeed = attackspeed;
      }
      public void SetBlessCriticalDamage(float criDmg)
      {
            m_blessCriticalDamage = criDmg;
      }
      public void SetBlessDoubleAttack(float doubleattack)
      {
            m_blessDoubleAttack = doubleattack;
      }
      public void SetBlessGold(float gold)
      {
            m_blessGold = gold;
      }
      public void SetBlessUnit(float unit)
      {
            m_blessUnit = unit;
      }

      public float GetBlessMaxHp()
      {
            return m_blessMaxHp;
      }
      public float GetBlessDamage()
      {
            return m_blessDamage;
      }
      public float GetBlessAttackSpeed()
      {
            return m_blessAttackSpeed;
      }
      public float GetBlessCriticalDamage()
      {
            return m_blessCriticalDamage;
      }
      public float GetBlessDoubleAttack()
      {
            return m_blessDoubleAttack;
      }
      public float GetBlessGold()
      {
            return m_blessGold;
      }
      public float GetBlessUnit()
      {
            return m_blessUnit;
      }
}
