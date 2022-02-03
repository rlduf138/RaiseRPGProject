using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomMenuController : MonoBehaviour
{
      [Header("ButtomButtonImage")]
      public Image m_goldButton;
      public Image m_blessButton;
      public Image m_equipButton;
      public Image m_questButton;
      public Image m_raidButton;
      public Image m_shopButton;

      [Header("BottomButtonSwapImage")]
      public Sprite m_offSprite;
      public Sprite m_onSprite;

      [Header("Panels")]
      public GameObject m_goldPanel;
      public GameObject m_blessPanel;
      public GameObject m_equipPanel;
      public GameObject m_questPanel;
      public GameObject m_raidPanel;
      public GameObject m_shopPanel;

      [Header("Bools")]
      public bool m_IsGold;
      public bool m_IsBless;
      public bool m_IsEquip;
      public bool m_IsQuest;
      public bool m_IsRaid;
      public bool m_IsShop;

      // Start is called before the first frame update
      void Start()
      {
            AllPanelOff();
            AllButtonImageOff();
            m_goldPanel.SetActive(true);
            m_goldButton.sprite = m_onSprite;
      }

      // Update is called once per frame
      void Update()
      {

      }

      public void AllPanelOff()
      {
            m_goldPanel.SetActive(false);
            m_blessPanel.SetActive(false);
            m_equipPanel.SetActive(false);
            m_questPanel.SetActive(false);
            m_raidPanel.SetActive(false);
            m_shopPanel.SetActive(false);

            m_IsGold = false;
            m_IsBless = false;
            m_IsEquip = false;
            m_IsQuest = false;
            m_IsRaid = false;
            m_IsShop = false;
      }
      public void AllButtonImageOff()
      {
            m_goldButton.sprite = m_offSprite;
            m_blessButton.sprite = m_offSprite;
            m_equipButton.sprite = m_offSprite;
            m_questButton.sprite = m_offSprite;
            m_raidButton.sprite = m_offSprite;
            m_shopButton.sprite = m_offSprite;
      }
      public void ResetAll()
      {
            AllPanelOff();
            AllButtonImageOff();
      }
      public void OnGoldButtonClick()
      {
            ResetAll();
            m_goldPanel.SetActive(true);
            m_goldButton.sprite = m_onSprite;
            m_IsGold = true;
      }
      public void OnBlessButtonClick()
      {
            ResetAll();
            m_blessPanel.SetActive(true);
            m_blessButton.sprite = m_onSprite;
            m_IsBless = true;
      }
      public void OnEquipButtonClick()
      {
            ResetAll();
            m_equipPanel.SetActive(true);
            m_equipButton.sprite = m_onSprite;
            m_IsEquip = true;
      }
      public void OnQuestButtonClick()
      {
            ResetAll();
            m_questPanel.SetActive(true);
            m_questButton.sprite = m_onSprite;
            m_IsQuest = true;
      }
      public void OnRaidButtonClick()
      {
            ResetAll();
            m_raidPanel.SetActive(true);
            m_raidButton.sprite = m_onSprite;
            m_IsRaid = true;
      }
      public void OnShopButtonClick()
      {
            ResetAll();
            m_shopPanel.SetActive(true);
            m_shopButton.sprite = m_onSprite;
            m_IsShop = true;
      }

}
