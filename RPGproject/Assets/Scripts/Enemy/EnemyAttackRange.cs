using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
      public EnemyBase enemyBase;


      private void OnTriggerStay2D(Collider2D collision)
      {
            if (collision.CompareTag("Player"))
            {
                  enemyBase.MeetPlayer();
            }
      }
      private void OnTriggerExit2D(Collider2D collision)
      {
            if (collision.CompareTag("Player"))
            {
                  enemyBase.GonePlayer();
            }
      }
}
