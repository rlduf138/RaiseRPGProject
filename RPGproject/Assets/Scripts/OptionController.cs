using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionController : MonoBehaviour, IPointerClickHandler
{
      public GameController gameController;
      public GameObject panel;

      public InputField inputField;

      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

      }

      public void OnOptionButtonClick()
      {
            panel.SetActive(true);
      }

      public void OnPointerClick(PointerEventData eventData)
      {
            if (Input.touchCount == 1)
            {
                  if (eventData.pointerEnter == panel)
                  {
                        Debug.Log("EscPanel");
                        OptionClose();
                  }
                  else
                  {
                        Debug.Log("No Panel");
                  }
            }
            //throw new System.NotImplementedException();
      }

      public void OptionClose()
      {
            panel.SetActive(false);
      }
      public void InputButtonClick()
      {
            int n =  int.Parse(inputField.text);
            gameController.GoToStage(n);
      }

}
