using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackController : MonoBehaviour
{
      public float m_xGap;          // 배경 이어붙일때의 간격.
      public float m_moveSpeed;     // 배경 이동속도.
      public GameObject leftObejct;
      public GameObject rightObject;
      Vector3 vec3;
      public bool m_isMove = false;

      [Header("MultiplySpeed")]
      public float m_multiplySpeed;

      // Start is called before the first frame update
      void Start()
      {
            vec3 = new Vector3(-m_moveSpeed * m_multiplySpeed , 0);
      }

      // Update is called once per frame
      void Update()
      {

      }

      public void MoveBackground()
      {
            if (!m_isMove)    // 코루틴 중복 실행 방지.
            {
                  StartCoroutine("MoveBack");
            }
      }
      public void StopBackGround()
      {
            if (m_isMove)
            {
                  StopCoroutine("MoveBack");
                  m_isMove = false;
            }
      }

      public void TestButtonClicked()
      {
            StartCoroutine(MoveBack());
      }
      public IEnumerator MoveBack()
      {
            m_isMove = true;
            while (true)
            {
                  yield return new WaitForFixedUpdate();

                  leftObejct.transform.Translate(vec3);
                  rightObject.transform.Translate(vec3);
                  if(rightObject.transform.position.x <= 0)
                  {
                        ChangeRightToLeft();
                  }
            }
      }

      public void ChangeRightToLeft()
      {
            // 왼쪽 배경 삭제, 오른쪽배경을 왼쪽배경으로 넣고
            // 오른쪽에 배경 하나 생성.

            GameObject temp = leftObejct;
            leftObejct = rightObject;
            rightObject = temp;

            rightObject.transform.position = new Vector3(leftObejct.transform.position.x + m_xGap, leftObejct.transform.position.y, 0);
      }

      public void ChangeMultiplySpeed(float speed)
      {
            m_multiplySpeed = speed;
            vec3 = new Vector3(-m_moveSpeed * m_multiplySpeed, 0);
      }
}
