using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopCanvasController : MonoBehaviour
{
      public GameController gameController;
      public Image img;
      public Sprite doubleSpeedImg;
      public Sprite singleSpeedImg;

      [Header("PlayerPrefs")]
      public float m_singleSpeed = 1f;
      public float m_doubleSpeed = 2f;
      public bool isDouble = false;


      private void Start()
      {
            if (PlayerPrefs.HasKey("Speed"))
            {
                  // speed 저장된게 있으면 적용
                  float speed = PlayerPrefs.GetFloat("Speed");
                  gameController.ChangeMultiplySpeed(speed);
                  if (speed == m_singleSpeed)
                  {
                        img.sprite = singleSpeedImg;
                        img.SetNativeSize();
                        isDouble = false;
                  }
                  else
                  {
                        img.sprite = doubleSpeedImg;
                        isDouble = true;
                        img.SetNativeSize();
                  }
            }
      }
     

      // Update is called once per frame
      void Update()
      {

      }

      public void OnSpeedButtonClick()
      {
            Debug.Log("SpeedButtonClick");
            if (isDouble)
            {
                  // 배속 적용 상태라면.
                  Debug.Log("배속 해제");
                  PlayerPrefs.SetFloat("Speed", m_singleSpeed);
                  img.sprite = singleSpeedImg;
                  img.SetNativeSize();
                  gameController.ChangeMultiplySpeed(PlayerPrefs.GetFloat("Speed"));
                  isDouble = false;
            }
            else if(!isDouble)
            {
                  Debug.Log("배속 적용");
                  PlayerPrefs.SetFloat("Speed", m_doubleSpeed);
                  img.sprite = doubleSpeedImg;
                  img.SetNativeSize();
                  gameController.ChangeMultiplySpeed(PlayerPrefs.GetFloat("Speed"));
                  isDouble = true;
            }
      }
}
