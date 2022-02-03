using PixelSilo.Helper;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class EnforceData : Singleton<EnforceData>
{
      public GameController gameController;
      public UserData userData;
      public EquipController equipController;
      // 기본 1레벨 시작 = 1
      [Header("Gold")]
      public float m_goldMaxHpCount;
      public float m_goldHpRegenCount;
      public float m_goldDamageCount;
      public float m_goldCriticalRateCount;
      public float m_goldCriticalDamageCount;

      [Header("GoldNeed")]
      public int m_goldNeedMaxHp;
      public int m_goldNeedHpRegen;
      public int m_goldNeedDamage;
      public int m_goldNeedCriticalRate;
      public int m_goldNeedCriticalDamage;

      [Header("Bless")]
      public int m_blessMaxHpCount;
      public int m_blessDamageCount;
      public int m_blessAttackSpeedCount;
      public int m_blessCriticalDamageCount;
      public int m_blessDoubleAttackCount;
      public int m_blessGoldCount;
      public int m_blessUnitEnforceCount;

      [Header("BlessNeed")]
      public int m_blessNeedMaxHp;
      public int m_blessNeedDamage;
      public int m_blessNeedAttackSpeed;
      public int m_blessNeedCriticalDamage;
      public int m_blessNeedDoubleAttack;
      public int m_blessNeedGold;
      public int m_blessNeedUnitEnforce;

      [Header("Weapon")]
      public float m_weaponDamage;

      [Header("Result")]
      public float m_resultMaxHp;
      public float m_resultHpRegen;
      public float m_resultDamage;
      public float m_resultCriticalRate;
      public float m_resultCriticalDamage;

      public float m_resultAttackSpeed;
      public float m_resultGold;
      public float m_resultDoubleAttack;
      public float m_resultUnitEnforce;

      [Header("GoldUI")]
      public TextMeshProUGUI g_maxHpLevelText;
      public TextMeshProUGUI g_maxHpCurrentText;
      public TextMeshProUGUI g_maxHpNextText;
      public TextMeshProUGUI g_maxHpNeedGoldText;
      public Button g_maxHpButton;
      public TextMeshProUGUI g_hpRegenLevelText;
      public TextMeshProUGUI g_hpRegenCurrentText;
      public TextMeshProUGUI g_hpRegenNextText;
      public TextMeshProUGUI g_hpRegenNeedGoldText;
      public Button g_hpRegenButton;
      public TextMeshProUGUI g_damageLevelText;
      public TextMeshProUGUI g_damageCurrentText;
      public TextMeshProUGUI g_damageNextText;
      public TextMeshProUGUI g_damageNeedGoldText;
      public Button g_damageButton;
      public TextMeshProUGUI g_criRateLevelText;
      public TextMeshProUGUI g_criRateCurrentText;
      public TextMeshProUGUI g_criRateNextText;
      public TextMeshProUGUI g_criRateNeedGoldText;
      public Button g_criRateButton;
      public TextMeshProUGUI g_criDmgLevelText;
      public TextMeshProUGUI g_criDmgCurrentText;
      public TextMeshProUGUI g_criDmgNextText;
      public TextMeshProUGUI g_criDmgNeedGoldText;
      public Button g_criDmgButton;

      [Header("BlessUI")]
      public TextMeshProUGUI b_maxHpLevelText;
      public TextMeshProUGUI b_maxHpCurrentText;
      public TextMeshProUGUI b_maxHpNextText;
      public TextMeshProUGUI b_maxHpNeedGoldText;
      public Button b_maxHpButton;
      public TextMeshProUGUI b_damageLevelText;
      public TextMeshProUGUI b_damageCurrentText;
      public TextMeshProUGUI b_damageNextText;
      public TextMeshProUGUI b_damageNeedGoldText;
      public Button b_damageButton;
      public TextMeshProUGUI b_attackSpeedLevelText;
      public TextMeshProUGUI b_attackSpeedCurrentText;
      public TextMeshProUGUI b_attackSpeedNextText;
      public TextMeshProUGUI b_attackSpeedNeedGoldText;
      public Button b_attackSpeedButton;
      public TextMeshProUGUI b_criDmgLevelText;
      public TextMeshProUGUI b_criDmgCurrentText;
      public TextMeshProUGUI b_criDmgNextText;
      public TextMeshProUGUI b_criDmgNeedGoldText;
      public Button b_criDmgButton;
      public TextMeshProUGUI b_doubleAttackLevelText;
      public TextMeshProUGUI b_doubleAttackCurrentText;
      public TextMeshProUGUI b_doubleAttackNextText;
      public TextMeshProUGUI b_doubleAttackNeedGoldText;
      public Button b_doubleAttackButton;
      public TextMeshProUGUI b_goldLevelText;
      public TextMeshProUGUI b_goldCurrentText;
      public TextMeshProUGUI b_goldNextText;
      public TextMeshProUGUI b_goldNeedGoldText;
      public Button b_goldButton;
      public TextMeshProUGUI b_unitLevelText;
      public TextMeshProUGUI b_unitCurrentText;
      public TextMeshProUGUI b_unitNextText;
      public TextMeshProUGUI b_unitNeedGoldText;
      public Button b_unitButton;

      // 데미지 공식
      // 공격력 ( 골드강화 + 가호)
      // 공격력증가 ( 무기)
      // 추가공격력 ( 오라 + 모험단 티어)
      // 데미지증가(악세서리)
      //
      // 공격력 * 공격력증가 * 추가공격력 * 데미지증가 = 최종 데미지

      private void Awake()
      {
            GetUserData();
            CalculateGoldNeedAll();
            CalculateBlessNeedAll();
            AllButtonEnabled();
            GoldUIRefreshAll();
      }
      public void GetUserData()
      {
            m_goldMaxHpCount = userData.GetGoldMaxHp();
            m_goldHpRegenCount = userData.GetGoldHpRegen();
            m_goldDamageCount = userData.GetGoldDamage();
            m_goldCriticalRateCount = userData.GetGoldCriticalRate();
            m_goldCriticalDamageCount = userData.GetGoldCriticalDamage();
      }
      public void CalculateGoldNeedAll()
      {
            CalculateGoldNeedMaxHp();
            CalculateGoldNeedHpRegen();
            CalculateGoldNeedDamage();
            CalculateGoldNeedCriticalRate();
            CalculateGoldNeedCriticalDamage();
      }
      public void CalculateBlessNeedAll()
      {
            CalculateBlessNeedMaxHp();
            CalculateBlessNeedDamage();
            CalculateBlessNeedAttackSpeed();
            CalculateBlessNeedCriticalDamage();
            CalculateBlessNeedDoubleAttack();
            CalculateBlessNeedGold();
            CalculateBlessNeedUnit();
      }
      // 강화에 필요한 골드 계산.
      public void CalculateGoldNeedMaxHp()
      {
            m_goldNeedMaxHp = (int)(Mathf.Pow((m_goldMaxHpCount / 100), 4) +
                  100 * Mathf.Pow((m_goldMaxHpCount / 100), 3) +
                   5000 * Mathf.Pow((m_goldMaxHpCount / 100), 2) - (m_goldMaxHpCount / 2) + 1);
      }
      public void CalculateGoldNeedHpRegen()
      {
            m_goldNeedHpRegen = (int)(Mathf.Pow((m_goldHpRegenCount / 100), 4) +
                  100 * Mathf.Pow((m_goldHpRegenCount / 100), 3) +
                   5000 * Mathf.Pow((m_goldHpRegenCount / 100), 2) - (m_goldHpRegenCount / 2) + 1);
      }
      public void CalculateGoldNeedDamage()
      {
            m_goldNeedDamage =(int)(Mathf.Pow((m_goldDamageCount / 100), 4) + 
                  100 * Mathf.Pow( (m_goldDamageCount / 100) , 3 ) +
                   5000 * Mathf.Pow( (m_goldDamageCount / 100) ,2) - (m_goldDamageCount / 2) + 1);
      }
      public void CalculateGoldNeedCriticalRate()
      {
            m_goldNeedCriticalRate = (int)(50 * Mathf.Pow(((m_goldCriticalRateCount+1) / 100), 5) + 2 * Mathf.Pow(m_goldCriticalRateCount+1, 3));
      }
      public void CalculateGoldNeedCriticalDamage()
      {
            m_goldNeedCriticalDamage = (int)(50 * Mathf.Pow(((m_goldCriticalDamageCount+1) / 100), 5) + 2 * Mathf.Pow(m_goldCriticalDamageCount+1, 3));
      }

      // 가호에 필요한 재화 계산
      public void CalculateBlessNeedMaxHp()
      {
            // 체력 강화 가호 공식 = x^2-x*2+100
            m_blessNeedMaxHp = (int)(Mathf.Pow(m_blessMaxHpCount +1, 2) - (m_blessMaxHpCount +1)* 2 + 100);
      }
      public void CalculateBlessNeedDamage()
      {
            m_blessNeedDamage = (int)(Mathf.Pow(m_blessDamageCount+1, 2) - (m_blessDamageCount +1)* 2 + 100);
      }
      public void CalculateBlessNeedAttackSpeed()
      {
            m_blessNeedAttackSpeed = (int)(Mathf.Pow(m_blessAttackSpeedCount+1, 2) - (m_blessAttackSpeedCount +1)* 2 + 100);
      }
      public void CalculateBlessNeedCriticalDamage()
      {
            m_blessNeedCriticalDamage = (int)(Mathf.Pow(m_blessCriticalDamageCount+1, 2) - (m_blessCriticalDamageCount+1) * 2 + 100);
      }
      public void CalculateBlessNeedDoubleAttack()
      {
            m_blessNeedDoubleAttack = (int)(Mathf.Pow(m_blessDoubleAttackCount+1, 2) - (m_blessDoubleAttackCount + 1) * 2 + 100);
      }
      public void CalculateBlessNeedGold()
      {
            m_blessNeedGold = (int)(Mathf.Pow(m_blessGoldCount+1, 2) - (m_blessGoldCount + 1) * 2 + 100);
      }
      public void CalculateBlessNeedUnit()
      {
            m_blessNeedUnitEnforce = (int)(Mathf.Pow(m_blessUnitEnforceCount+1, 2) - (m_blessUnitEnforceCount + 1) * 2 + 100);
      }

      // 강화,가호로 적용된 데미지 결과 출력
      public float CalculateGoldMaxHp()
      {
            float goldMaxHp = 0f;
            
            if (m_goldMaxHpCount <= 2000)
            {
                  goldMaxHp = m_goldMaxHpCount * 20;
            }
            else if (m_goldMaxHpCount <= 4000)
            {
                  goldMaxHp = 40000 + (m_goldMaxHpCount - 2000) * 30;
            }
            else if (m_goldMaxHpCount <= 6000)
            {
                  goldMaxHp = 100000 + (m_goldMaxHpCount - 4000) * 40;
            }
            else if (m_goldMaxHpCount <= 8000)
            {
                  goldMaxHp = 180000 + (m_goldMaxHpCount - 6000) * 50;
            }
            else if (m_goldMaxHpCount <= 10000)
            {
                  goldMaxHp = 280000 + (m_goldMaxHpCount - 8000) * 60;
            }
            return goldMaxHp;
      }
      public float CalculateBlessMaxHp()
      {
            float blessMaxHp = 0f;
            if (m_blessMaxHpCount <= 1000)
            {
                  blessMaxHp = m_blessMaxHpCount * 0.001f + 1;
            }
            else if (m_blessMaxHpCount <= 2000)
            {
                  blessMaxHp = 1 + (m_blessMaxHpCount - 1000) * 0.002f + 1;
            }
            else if (m_blessMaxHpCount <= 3000)
            {
                  blessMaxHp = 3 + (m_blessMaxHpCount - 2000) * 0.003f + 1;
            }
            else if (m_blessMaxHpCount <= 4000)
            {
                  blessMaxHp = 6 + (m_blessMaxHpCount - 3000) * 0.004f + 1;
            }
            else if (m_blessMaxHpCount <= 5000)
            {
                  blessMaxHp = 10 + (m_blessMaxHpCount - 4000) * 0.005f + 1;
            }
            return blessMaxHp;
      }

      public float CalculateHpRegen()
      {
            float goldHpRegen = 0f;

            if (m_goldHpRegenCount <= 4000)
            {
                  goldHpRegen = m_goldHpRegenCount * 0.001f ;
            }
            else if (m_goldHpRegenCount <= 8000)
            {
                  goldHpRegen = 4 + (m_goldHpRegenCount - 4000) * 0.002f ;
            }
            else if (m_goldHpRegenCount <= 10000)
            {
                  goldHpRegen = 12 + (m_goldHpRegenCount - 8000) * 0.003f ;
            }
        
            return goldHpRegen;
      }
      public float CalculateGoldDamage()
      {
            float goldDamage = 0f;
           
            if(m_goldDamageCount <= 2000)
            {
                  goldDamage = m_goldDamageCount * 2;
            }else if(m_goldDamageCount <= 4000)
            {
                  goldDamage = 4000 + (m_goldDamageCount-2000) * 3;
            }else if(m_goldDamageCount <= 6000)
            {
                  goldDamage = 10000 + (m_goldDamageCount - 4000) * 4;
            }else if(m_goldDamageCount <= 8000)
            {
                  goldDamage = 18000 + (m_goldDamageCount - 6000) * 5;
            }else if(m_goldDamageCount <= 10000)
            {
                  goldDamage = 28000 + (m_goldDamageCount - 8000) * 6;
            }

            return goldDamage ;
      }
      public float CalculateBlessDamage()
      {
            float blessDamage = 0f;

            if (m_blessDamageCount <= 1000)
            {
                  blessDamage = m_blessDamageCount * 0.01f + 1;
            }
            else if (m_blessDamageCount <= 2000)
            {
                  blessDamage = 10 + (m_blessDamageCount - 1000) * 0.02f + 1;
            }
            else if (m_blessDamageCount <= 3000)
            {
                  blessDamage = 30 + (m_blessDamageCount - 2000) * 0.03f + 1;
            }
            else if (m_blessDamageCount <= 4000)
            {
                  blessDamage = 60 + (m_blessDamageCount - 3000) * 0.04f + 1;
            }
            else if (m_blessDamageCount <= 5000)
            {
                  blessDamage = 100 + (m_blessDamageCount - 4000) * 0.05f + 1;
            }

            return blessDamage;
      }
      public float CalculateBlessAttackSpeed()
      {
            float blessAttackSpeed = 0f;

            if(m_blessAttackSpeedCount <= 1000)
            {
                  blessAttackSpeed = m_blessAttackSpeedCount * 0.01f;
            }
            else if (m_blessAttackSpeedCount <= 2000)
            {
                  blessAttackSpeed = 10 + m_blessAttackSpeedCount * 0.03f;
            }
            else if (m_blessAttackSpeedCount <= 3000)
            {
                  blessAttackSpeed = 40 + m_blessAttackSpeedCount * 0.05f;
            }
            else if (m_blessAttackSpeedCount <= 4000)
            {
                  blessAttackSpeed = 90 + m_blessAttackSpeedCount * 0.07f;
            }
            else if (m_blessAttackSpeedCount <= 5000)
            {
                  blessAttackSpeed = 160 + m_blessAttackSpeedCount * 0.09f;
            }

            return blessAttackSpeed;
      }


      public float CalculateCriticalRate()
      {
            float goldCriticalRate;

            goldCriticalRate = m_goldCriticalRateCount * 0.1f;

            return goldCriticalRate;
      }
      public float CalculateCriticalDamage()
      {
            float goldCriticalDamage;
           

            goldCriticalDamage = m_goldCriticalDamageCount * 0.1f;

          

            return goldCriticalDamage;
      }
      public float CalculateBlessCriticalDamage()
      {
            float blessCriticalDamage = 0f;

            if (m_blessCriticalDamageCount <= 1000)
            {
                  blessCriticalDamage = m_blessCriticalDamageCount * 0.3f;
            }
            else if (m_blessCriticalDamageCount <= 2000)
            {
                  blessCriticalDamage = 300 + (m_blessCriticalDamageCount - 1000) * 0.5f;
            }
            else if (m_blessCriticalDamageCount <= 3000)
            {
                  blessCriticalDamage = 800 + (m_blessCriticalDamageCount - 2000) * 0.7f;
            }
            else if (m_blessCriticalDamageCount <= 4000)
            {
                  blessCriticalDamage = 1500 + (m_blessCriticalDamageCount - 3000) * 0.9f;
            }
            else if (m_blessCriticalDamageCount <= 5000)
            {
                  blessCriticalDamage = 2400 + (m_blessCriticalDamageCount - 4000) * 1.1f;
            }

            return blessCriticalDamage;
      }
      public float CalculateBlessDoubleAttack()
      {
            float blessDoubleAttack = 0f;

            if(m_blessDoubleAttackCount <= 2000)
            {
                  blessDoubleAttack = m_blessDoubleAttackCount * 0.01f;
            }else if(m_blessDoubleAttackCount <= 4000)
            {
                  blessDoubleAttack = 20 + m_blessDoubleAttackCount * 0.02f;
            }
            else if (m_blessDoubleAttackCount <= 5000)
            {
                  blessDoubleAttack = 60 + m_blessDoubleAttackCount * 0.04f;
            }

            return blessDoubleAttack;
      }
      public float CalculateBlessGold()
      {
            float blessGold = 0f;

            if(m_blessGoldCount <= 1000)
            {
                  blessGold = m_blessGoldCount * 0.1f;
            }else if(m_blessGoldCount <= 2000)
            {
                  blessGold = 100 + m_blessGoldCount * 0.3f;
            }
            else if (m_blessGoldCount <= 3000)
            {
                  blessGold = 400 + m_blessGoldCount * 0.5f;
            }
            else if (m_blessGoldCount <= 4000)
            {
                  blessGold = 900 + m_blessGoldCount * 0.7f;
            }
            else if (m_blessGoldCount <= 5000)
            {
                  blessGold = 1600 + m_blessGoldCount * 0.9f;
            }

            return blessGold;
      }
      public float CalculateBlessUnit()
      {
            float blessUnit = 0f;

            if(m_blessUnitEnforceCount <= 1000)
            {
                  blessUnit = m_blessUnitEnforceCount * 0.03f;
            }else if(m_blessUnitEnforceCount <= 2000)
            {
                  blessUnit = 30 +  m_blessUnitEnforceCount * 0.05f;
            }
            else if (m_blessUnitEnforceCount <= 3000)
            {
                  blessUnit = 80 + m_blessUnitEnforceCount * 0.07f;
            }
            else if (m_blessUnitEnforceCount <= 4000)
            {
                  blessUnit = 150 + m_blessUnitEnforceCount * 0.09f;
            }
            else if (m_blessUnitEnforceCount <= 5000)
            {
                  blessUnit = 240 + m_blessUnitEnforceCount * 0.11f;
            }

            return blessUnit;
      }

      //Button Event
      public void OnGoldMaxHpClick()
      {
            if (m_goldMaxHpCount < 10000)
            {
                  int gold = userData.GetGoldCoin();
                  if (m_goldNeedMaxHp <= gold)
                  {
                        gold -= m_goldNeedMaxHp;
                        m_goldMaxHpCount++;
                        userData.SetGoldCoin(gold);

                        // 변경된 수치 계산
                        CalculateGoldNeedMaxHp();
                        userData.SetGoldMaxHp(m_goldMaxHpCount);
                        
                        // 캐릭터에 적용
                        gameController.characterBase.CalculateMaxHp();

                        // UI 적용
                        GoldMaxHpRefresh();
                        equipController.RefreshStatusUI();

                        Debug.Log("체력 강화 (골드) lv : " + m_goldMaxHpCount);
                  }
            }
      }
      public void OnGoldHpRegenClick()
      {
            if (m_goldHpRegenCount < 10000)
            {
                  int gold = userData.GetGoldCoin();
                  if (m_goldNeedHpRegen <= gold)
                  {
                        gold -= m_goldNeedHpRegen;
                        m_goldHpRegenCount++;
                        userData.SetGoldCoin(gold);

                        // 변경된 수치 계산
                        CalculateGoldNeedHpRegen();
                        userData.SetGoldHpRegen(m_goldHpRegenCount);

                        // 캐릭터에 적용
                        gameController.characterBase.CalculateHpRegen();

                        // UI 적용
                        GoldHpRegenRefresh();
                        equipController.RefreshStatusUI();

                        Debug.Log("체력회복 강화 (골드) lv : " + m_goldHpRegenCount);
                  }
            }
      }
      public void OnGoldDamageClick()
      {
            if (m_goldDamageCount < 10000)
            {
                  int gold = userData.GetGoldCoin();
                  if (m_goldNeedDamage <= gold)
                  {
                        gold -= m_goldNeedDamage;
                        m_goldDamageCount++;
                        userData.SetGoldCoin(gold);

                        // 변경된 수치 계산
                        CalculateGoldNeedDamage();
                        userData.SetGoldDamage(m_goldDamageCount);

                        // 캐릭터에 적용
                        gameController.characterBase.CalculateDamage();

                        // UI 적용
                        GoldDamageRefresh();
                        equipController.RefreshStatusUI();

                        Debug.Log("체력 강화 (골드) lv : " + m_goldDamageCount);
                  }
            }
      }
      public void OnGoldCriticalRateClick()
      {
            if (m_goldCriticalRateCount < 1000)
            {
                  int gold = userData.GetGoldCoin();
                  if (m_goldNeedCriticalRate <= gold)
                  {
                        gold -= m_goldNeedCriticalRate;
                        m_goldCriticalRateCount++;
                        userData.SetGoldCoin(gold);

                        // 변경된 수치 계산
                        CalculateGoldNeedCriticalRate();
                        userData.SetGoldCriticalRate(m_goldCriticalRateCount);

                        // 캐릭터에 적용
                        gameController.characterBase.CalculateCriticalRate();

                        // UI 적용
                        GoldCriticalRateRefresh();
                        equipController.RefreshStatusUI();

                        Debug.Log("크리티컬 확률 강화 (골드) lv : " + m_goldCriticalRateCount);
                  }
            }
      }
      public void OnGoldCriticalDamageClick()
      {
            if (m_goldCriticalDamageCount < 1000)
            {
                  int gold = userData.GetGoldCoin();
                  if (m_goldNeedCriticalDamage <= gold)
                  {
                        gold -= m_goldNeedCriticalDamage;
                        m_goldCriticalDamageCount++;
                        userData.SetGoldCoin(gold);

                        // 변경된 수치 계산
                        CalculateGoldNeedCriticalDamage();
                        userData.SetGoldCriticalDamage(m_goldCriticalDamageCount);

                        // 캐릭터에 적용
                        gameController.characterBase.CalculateCriticalDamage();

                        // UI 적용
                        GoldCriticalDamageRefresh();
                        equipController.RefreshStatusUI();

                        Debug.Log("크리티컬 데미지 강화 (골드) lv : " + m_goldCriticalDamageCount);
                  }
            }
      }

      // BlessButtonEvent
      public void OnBlessMaxHpClick()
      {
            if(m_blessMaxHpCount < 5000)
            {
                  int bless = userData.GetBlessCoin();
                  if(m_blessNeedMaxHp <= bless)
                  {
                        bless -= m_blessNeedMaxHp;
                        m_blessMaxHpCount++;
                        userData.SetBlessCoin(bless);

                        // 변경된 수치 계산
                        CalculateBlessNeedMaxHp();
                        userData.SetBlessMaxHp(m_blessMaxHpCount);

                        // 캐릭터에 적용
                        gameController.characterBase.CalculateMaxHp();

                        //UI 적용
                        BlessMaxHpRefresh();
                        equipController.RefreshStatusUI();
                        Debug.Log("최대 생명력 (가호)  lv : " + m_blessMaxHpCount);
                  }
            }
      }
      public void OnBlessDamageClick()
      {
            if (m_blessDamageCount < 5000)
            {
                  int bless = userData.GetBlessCoin();
                  if (m_blessNeedDamage <= bless)
                  {
                        bless -= m_blessNeedDamage;
                        m_blessDamageCount++;
                        userData.SetBlessCoin(bless);

                        // 변경된 수치 계산
                        CalculateBlessNeedDamage();
                        userData.SetBlessDamage(m_blessDamageCount);

                        // 캐릭터에 적용
                        gameController.characterBase.CalculateDamage();

                        //UI 적용
                        BlessDamageRefresh();
                        equipController.RefreshStatusUI();

                        Debug.Log("공격력 (가호)  lv : " + m_blessDamageCount);
                  }
            }
      }
      public void OnBlessAttackSpeedClick()
      {
            if (m_blessAttackSpeedCount < 5000)
            {
                  int bless = userData.GetBlessCoin();
                  if (m_blessNeedAttackSpeed <= bless)
                  {
                        bless -= m_blessNeedAttackSpeed;
                        m_blessAttackSpeedCount++;
                        userData.SetBlessCoin(bless);

                        // 변경된 수치 계산
                        CalculateBlessNeedAttackSpeed();
                        userData.SetBlessAttackSpeed(m_blessAttackSpeedCount);

                        // 캐릭터에 적용
                        gameController.characterBase.CalculateAttackSpeed();

                        //UI 적용
                        BlessAttackSpeedRefresh();
                        equipController.RefreshStatusUI();

                        Debug.Log("공격속도 (가호)  lv : " + m_blessAttackSpeedCount);
                  }
            }
      }
      public void OnBlessCriticalDamageClick()
      {
            if (m_blessCriticalDamageCount < 5000)
            {
                  int bless = userData.GetBlessCoin();
                  if (m_blessNeedCriticalDamage <= bless)
                  {
                        bless -= m_blessNeedCriticalDamage;
                        m_blessCriticalDamageCount++;
                        userData.SetBlessCoin(bless);

                        // 변경된 수치 계산
                        CalculateBlessNeedCriticalDamage();
                        userData.SetBlessCriticalDamage(m_blessCriticalDamageCount);

                        // 캐릭터에 적용
                        gameController.characterBase.CalculateCriticalDamage();

                        //UI 적용
                        BlessCriticalDamageRefresh();
                        equipController.RefreshStatusUI();

                        Debug.Log("크리티컬 데미지 (가호)  lv : " + m_blessCriticalDamageCount);
                  }
            }
      }
      public void OnBlessDoubleAttackClick()
      {
            if (m_blessDoubleAttackCount < 5000)
            {
                  int bless = userData.GetBlessCoin();
                  if (m_blessNeedDoubleAttack <= bless)
                  {
                        bless -= m_blessNeedDoubleAttack;
                        m_blessDoubleAttackCount++;
                        userData.SetBlessCoin(bless);

                        // 변경된 수치 계산
                        CalculateBlessNeedDoubleAttack();
                        userData.SetBlessDoubleAttack(m_blessDoubleAttackCount);

                        // 캐릭터에 적용
                        gameController.characterBase.CalculateDoubleAttack();

                        //UI 적용
                        BlessDoubleAttackRefresh();
                        equipController.RefreshStatusUI();

                        Debug.Log("연격 확률 (가호)  lv : " + m_blessDoubleAttackCount);
                  }
            }
      }
      public void OnBlessGoldClick()
      {
            if (m_blessGoldCount < 5000)
            {
                  int bless = userData.GetBlessCoin();
                  if (m_blessNeedGold <= bless)
                  {
                        bless -= m_blessNeedGold;
                        m_blessGoldCount++;
                        userData.SetBlessCoin(bless);

                        // 변경된 수치 계산
                        CalculateBlessNeedGold();
                        userData.SetBlessGold(m_blessGoldCount);

                        // 캐릭터에 적용
                        gameController.CalculateBlessGold();

                        //UI 적용
                        BlessGoldRefresh();
                        equipController.RefreshStatusUI();

                        Debug.Log("골드획득량 (가호)  lv : " + m_blessGoldCount);
                  }
            }
      }
      public void OnBlessUnitClick()
      {
            if (m_blessUnitEnforceCount < 5000)
            {
                  int bless = userData.GetBlessCoin();
                  if (m_blessNeedUnitEnforce <= bless)
                  {
                        bless -= m_blessNeedUnitEnforce;
                        m_blessUnitEnforceCount++;
                        userData.SetBlessCoin(bless);

                        // 변경된 수치 계산
                        CalculateBlessNeedUnit();
                        userData.SetBlessUnit(m_blessUnitEnforceCount);

                        // 캐릭터에 적용
                        gameController.CalculateBlessUnitEnforce();

                        //UI 적용
                        BlessUnitRefresh();
                        equipController.RefreshStatusUI();

                        Debug.Log("단원강화 (가호)  lv : " + m_blessUnitEnforceCount);
                  }
            }
      }

      // UI Refresh
      public void AllButtonEnabled()
      {
            g_maxHpButton.enabled = true;
            g_hpRegenButton.enabled = true;
            g_damageButton.enabled = true;
            g_criRateButton.enabled = true;
            g_criDmgButton.enabled = true;

            b_maxHpButton.enabled = true;
            b_damageButton.enabled = true;
            b_attackSpeedButton.enabled = true;
            b_criDmgButton.enabled = true;
            b_doubleAttackButton.enabled = true;
            b_goldButton.enabled = true;
            b_unitButton.enabled = true;
      }
      public void GoldUIRefreshAll()
      {
            GoldMaxHpRefresh();
            GoldHpRegenRefresh();
            GoldDamageRefresh();
            GoldCriticalRateRefresh();
            GoldCriticalDamageRefresh();

            BlessMaxHpRefresh();
            BlessDamageRefresh();
            BlessAttackSpeedRefresh();
            BlessCriticalDamageRefresh();
            BlessDoubleAttackRefresh();
            BlessGoldRefresh();
            BlessUnitRefresh();

      }
      public void GoldMaxHpRefresh()
      {
            g_maxHpLevelText.text = m_goldMaxHpCount.ToString();
            g_maxHpCurrentText.text = CalculateGoldMaxHp().ToString();
            g_maxHpNeedGoldText.text = string.Format("{0:#,0}", m_goldNeedMaxHp);
            

            // 강화시 증가하는 수치
            if (m_goldMaxHpCount <= 2000)
                  g_maxHpNextText.text = "+20";
            else if (m_goldMaxHpCount <= 4000)
                  g_maxHpNextText.text = "+30";
            else if (m_goldMaxHpCount <= 6000)
                  g_maxHpNextText.text = "+40";
            else if (m_goldMaxHpCount <= 8000)
                  g_maxHpNextText.text = "+50";
            else if (m_goldMaxHpCount <= 10000)
                  g_maxHpNextText.text = "+60";

            if(m_goldMaxHpCount == 10000)
            {
                  // 최대 강화.. 버튼 잠궈야함
                  g_maxHpButton.enabled = false;
            }
      }
      public void GoldHpRegenRefresh()
      {
            g_hpRegenLevelText.text = m_goldHpRegenCount.ToString();
            g_hpRegenCurrentText.text = CalculateHpRegen().ToString();
            g_hpRegenNextText.text = "+0.0001%";
            g_hpRegenNeedGoldText.text = string.Format("{0:#,0}", m_goldNeedHpRegen);

            // 강화시 증가하는 수치
            if (m_goldHpRegenCount <= 4000)
                  g_hpRegenNextText.text = "+0.001%";
            else if (m_goldHpRegenCount <= 8000)
                  g_hpRegenNextText.text = "+0.002%";
            else if (m_goldHpRegenCount <= 10000)
                  g_hpRegenNextText.text = "+0.003%";
            
            if (m_goldHpRegenCount == 10000)
            {
                  // 최대 강화.. 버튼 잠궈야함
                  g_hpRegenButton.enabled = false;
            }
      }
      public void GoldDamageRefresh()
      {
            g_damageLevelText.text = m_goldDamageCount.ToString();
            g_damageCurrentText.text = CalculateGoldDamage().ToString();
            g_damageNeedGoldText.text = string.Format("{0:#,0}", m_goldNeedDamage);

            // 강화시 증가하는 수치
            if (m_goldDamageCount <= 2000)
                  g_damageNextText.text = "+2";
            else if (m_goldDamageCount <= 4000)
                  g_damageNextText.text = "+3";
            else if (m_goldDamageCount <= 6000)
                  g_damageNextText.text = "+4";
            else if (m_goldDamageCount <= 8000)
                  g_damageNextText.text = "+5";
            else if (m_goldDamageCount <= 10000)
                  g_damageNextText.text = "+6";

            if (m_goldDamageCount == 10000)
            {
                  // 최대 강화.. 버튼 잠궈야함
                  g_damageButton.enabled = false;
            }
      }
      public void GoldCriticalRateRefresh()
      {
            g_criRateLevelText.text = m_goldCriticalRateCount.ToString();
            g_criRateCurrentText.text = CalculateCriticalRate().ToString();
            g_criRateNextText.text = "+0.1%";
            g_criRateNeedGoldText.text = string.Format("{0:#,0}", m_goldNeedCriticalRate);

            if (m_goldCriticalRateCount == 1000)
            {
                  // 최대 강화.. 버튼 잠궈야함
                  g_criRateButton.enabled = false;
            }
      }
      public void GoldCriticalDamageRefresh()
      {
            g_criDmgLevelText.text = m_goldCriticalDamageCount.ToString();
            g_criDmgCurrentText.text = CalculateCriticalDamage().ToString();
            g_criDmgNextText.text = "+0.1%";
            g_criDmgNeedGoldText.text = string.Format("{0:#,0}", m_goldNeedCriticalDamage);

            if (m_goldCriticalDamageCount == 1000)
            {
                  // 최대 강화.. 버튼 잠궈야함
                  g_criDmgButton.enabled = false;
            }
      }

      public void BlessMaxHpRefresh()
      {
            b_maxHpLevelText.text = m_blessMaxHpCount.ToString();
            b_maxHpCurrentText.text = CalculateBlessMaxHp().ToString();
            b_maxHpNeedGoldText.text = string.Format("{0:#,0}", m_blessNeedMaxHp);

            // 강화시 증가하는 수치
            if (m_blessMaxHpCount <= 1000)
                  b_maxHpNextText.text = "+0.001%";
            else if (m_blessMaxHpCount <= 2000)
                  b_maxHpNextText.text = "+0.002%";
            else if (m_blessMaxHpCount <= 3000)
                  b_maxHpNextText.text = "+0.003%";
            else if (m_blessMaxHpCount <= 4000)
                  b_maxHpNextText.text = "+0.004%";
            else if (m_blessMaxHpCount <= 5000)
                  b_maxHpNextText.text = "+0.005%";


            if (m_blessMaxHpCount == 5000)
            {
                  // 최대 강화.. 버튼 잠궈야함
                  b_maxHpButton.enabled = false;
            }
      }
      public void BlessDamageRefresh()
      {
            b_damageLevelText.text = m_blessDamageCount.ToString();
            b_damageCurrentText.text = CalculateBlessDamage().ToString();
            b_damageNeedGoldText.text = string.Format("{0:#,0}", m_blessNeedDamage);

            // 강화시 증가하는 수치
            if (m_blessDamageCount <= 1000)
                  b_damageNextText.text = "+0.01%";
            else if (m_blessDamageCount <= 2000)
                  b_damageNextText.text = "+0.02%";
            else if (m_blessDamageCount <= 3000)
                  b_damageNextText.text = "+0.03%";
            else if (m_blessDamageCount <= 4000)
                  b_damageNextText.text = "+0.04%";
            else if (m_blessDamageCount <= 5000)
                  b_damageNextText.text = "+0.05%";


            if (m_blessDamageCount == 5000)
            {
                  // 최대 강화.. 버튼 잠궈야함
                  b_damageButton.enabled = false;
            }
      }
      public void BlessAttackSpeedRefresh()
      {
            b_attackSpeedLevelText.text = m_blessAttackSpeedCount.ToString();
            b_attackSpeedCurrentText.text = CalculateBlessAttackSpeed().ToString();
            b_attackSpeedNeedGoldText.text = string.Format("{0:#,0}", m_blessNeedAttackSpeed);

            // 강화시 증가하는 수치
            if (m_blessAttackSpeedCount <= 1000)
                  b_attackSpeedNextText.text = "+0.001%";
            else if (m_blessAttackSpeedCount <= 2000)
                  b_attackSpeedNextText.text = "+0.002%";
            else if (m_blessAttackSpeedCount <= 3000)
                  b_attackSpeedNextText.text = "+0.003%";
            else if (m_blessAttackSpeedCount <= 4000)
                  b_attackSpeedNextText.text = "+0.004%";
            else if (m_blessAttackSpeedCount <= 5000)
                  b_attackSpeedNextText.text = "+0.005%";


            if (m_blessAttackSpeedCount == 5000)
            {
                  // 최대 강화.. 버튼 잠궈야함
                  b_attackSpeedButton.enabled = false;
            }
      }
      public void BlessCriticalDamageRefresh()
      {
            b_criDmgLevelText.text = m_blessCriticalDamageCount.ToString();
            b_criDmgCurrentText.text = CalculateBlessCriticalDamage().ToString();
            b_criDmgNeedGoldText.text = string.Format("{0:#,0}", m_blessNeedCriticalDamage);

            // 강화시 증가하는 수치
            if (m_blessCriticalDamageCount <= 1000)
                  b_criDmgNextText.text = "+0.3%";
            else if (m_blessCriticalDamageCount <= 2000)
                  b_criDmgNextText.text = "+0.5%";
            else if (m_blessCriticalDamageCount <= 3000)
                  b_criDmgNextText.text = "+0.7%";
            else if (m_blessCriticalDamageCount <= 4000)
                  b_criDmgNextText.text = "+0.9%";
            else if (m_blessCriticalDamageCount <= 5000)
                  b_criDmgNextText.text = "+1.1%";


            if (m_blessCriticalDamageCount == 5000)
            {
                  // 최대 강화.. 버튼 잠궈야함
                  b_criDmgButton.enabled = false;
            }
      }
      public void BlessDoubleAttackRefresh()
      {
            b_doubleAttackLevelText.text = m_blessDoubleAttackCount.ToString();
            b_doubleAttackCurrentText.text = CalculateBlessDoubleAttack().ToString();
            b_doubleAttackNeedGoldText.text = string.Format("{0:#,0}", m_blessNeedDoubleAttack);

            // 강화시 증가하는 수치
            if (m_blessDoubleAttackCount <= 2000)
                  b_doubleAttackNextText.text = "+0.01%";
            else if (m_blessDoubleAttackCount <= 4000)
                  b_doubleAttackNextText.text = "+0.02%";
            else if (m_blessDoubleAttackCount <= 5000)
                  b_doubleAttackNextText.text = "+0.04%";
            

            if (m_blessDoubleAttackCount == 5000)
            {
                  // 최대 강화.. 버튼 잠궈야함
                  b_doubleAttackButton.enabled = false;
            }
      }
      public void BlessGoldRefresh()
      {
            b_goldLevelText.text = m_blessGoldCount.ToString();
            b_goldCurrentText.text = CalculateBlessGold().ToString();
            b_goldNeedGoldText.text = string.Format("{0:#,0}", m_blessNeedGold);

            // 강화시 증가하는 수치
            if (m_blessGoldCount <= 1000)
                  b_goldNextText.text = "+0.1%";
            else if (m_blessGoldCount <= 2000)
                  b_goldNextText.text = "+0.3%";
            else if (m_blessGoldCount <= 3000)
                  b_goldNextText.text = "+0.5%";
            else if (m_blessGoldCount <= 4000)
                  b_goldNextText.text = "+0.7%";
            else if (m_blessGoldCount <= 5000)
                  b_goldNextText.text = "+0.9%";


            if (m_blessGoldCount == 5000)
            {
                  // 최대 강화.. 버튼 잠궈야함
                  b_goldButton.enabled = false;
            }
      }
      public void BlessUnitRefresh()
      {
            b_unitLevelText.text = m_blessUnitEnforceCount.ToString();
            b_unitCurrentText.text = CalculateBlessUnit().ToString();
            b_unitNeedGoldText.text = string.Format("{0:#,0}", m_blessNeedUnitEnforce);

            // 강화시 증가하는 수치
            if (m_blessUnitEnforceCount <= 1000)
                  b_unitNextText.text = "+0.03";
            else if (m_blessUnitEnforceCount <= 2000)
                  b_unitNextText.text = "+0.05%";
            else if (m_blessUnitEnforceCount <= 3000)
                  b_unitNextText.text = "+0.07%";
            else if (m_blessUnitEnforceCount <= 4000)
                  b_unitNextText.text = "+0.09%";
            else if (m_blessUnitEnforceCount <= 5000)
                  b_unitNextText.text = "+0.11%";


            if (m_blessUnitEnforceCount == 5000)
            {
                  // 최대 강화.. 버튼 잠궈야함
                  b_unitButton.enabled = false;
            }
      }
}
