using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRange : MonoBehaviour
{
      public CharacterBase characterBase;
      public EnemyBase targetEnemy;

      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

      }
      private void OnTriggerStay2D(Collider2D collision)
      {
            if (collision.CompareTag("Enemy"))
            {
                  if(targetEnemy == null)
                  {
                        targetEnemy =  collision.GetComponent<EnemyBase>();
                  }
                  characterBase.MeetEnemy(targetEnemy);
            }
      }
      private void OnTriggerExit2D(Collider2D collision)
      {
            if (collision.CompareTag("Enemy"))
            {
                  //characterBase.GoneEnemy();
                  if(collision.gameObject == targetEnemy.gameObject)
                  {
                        characterBase.GoneEnemy();
                        targetEnemy = null;
                  }
            }
      }
}
