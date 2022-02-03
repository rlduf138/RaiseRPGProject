using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimEvent : MonoBehaviour
{
      public EnemyBase enemyBase;
      public void AE_Attack()
      {
            enemyBase.HitPlayer();
      }
}
