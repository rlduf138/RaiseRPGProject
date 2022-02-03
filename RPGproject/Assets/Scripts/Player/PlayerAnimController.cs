using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
      public CharacterBase characterBase;
      
      public void AE_Attack()
      {
            characterBase.AttackAnimEvent();
            characterBase.HitEnemy();
      }

}
