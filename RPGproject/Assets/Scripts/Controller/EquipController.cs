using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipController : MonoBehaviour
{
      public GameController gameController;
      public CharacterBase characterBase;

      public TextMeshProUGUI _maxHpText;
      public TextMeshProUGUI _hpRegenText;
      public TextMeshProUGUI _damageText;
      public TextMeshProUGUI _attackSpeedText;
      public TextMeshProUGUI _criticalRateText;
      public TextMeshProUGUI _criticalDamageText;
      public TextMeshProUGUI _goldText;
      public TextMeshProUGUI _doubleAttackText;

      void Start()
      {
            RefreshStatusUI();
      }

      void Update()
      {

      }

      public void RefreshStatusUI()
      {
            characterBase = gameController.characterBase;
            if(characterBase != null)
            {
                  
                  _maxHpText.text = string.Format("{0:#,0}", characterBase.GetMaxHp());
                  _hpRegenText.text = characterBase.GetHpRegen().ToString();
                  _damageText.text = string.Format("{0:#,0}", characterBase.GetDamage());
                  _attackSpeedText.text = characterBase.GetAttackSpeed().ToString();
                  _criticalRateText.text = characterBase.GetCriticalRate().ToString() + " %";
                  _criticalDamageText.text = characterBase.GetCriticalDamage().ToString() +" %";
                  _goldText.text = "10%";
                  _doubleAttackText.text = characterBase.GetDoubleAttack().ToString() + " %";
            }
      }

}
