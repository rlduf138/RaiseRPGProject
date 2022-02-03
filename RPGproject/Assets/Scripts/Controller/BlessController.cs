using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessController : MonoBehaviour
{
      public GameController gameController;
      public UserData userData;
      public EnforceData enforceData;

      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

      }

      public void OnRebornButtonClick()
      {
            if (gameController.stageNumber > 100)
            {
                  // ȯ�� ��ư Ŭ��.
                  //�������� �ʱ�ȭ
                  int blessCoin = (int)((gameController.stageNumber * 0.5f)
                       + ((gameController.stageNumber - 100) * (gameController.stageNumber * 0.001f)));

                  float goldPoint =userData.GetGoldMaxHp() + userData.GetGoldHpRegen() + userData.GetGoldDamage()
                        + userData.GetGoldCriticalRate() + userData.GetGoldCriticalDamage();

                  float blessCoin_goldBonus = goldPoint * ((gameController.stageNumber - 100) * 0.01f + 1);

                  gameController.GoToStage(1);

                  // ��� ��ȭ �ʱ�ȭ
                  userData.SetGoldCoin(10000);         // �׽�Ʈ ������ ��� �ִ°���
                  userData.SetGoldMaxHp(0);
                  userData.SetGoldHpRegen(0);
                  userData.SetGoldDamage(0);
                  userData.SetGoldCriticalRate(0);
                  userData.SetGoldCriticalDamage(0);
                  userData.RefreshGoldCoinUI();

                  enforceData.GetUserData();
                  enforceData.CalculateGoldNeedAll();
                  enforceData.CalculateBlessNeedAll();
                  enforceData.AllButtonEnabled();
                  enforceData.GoldUIRefreshAll();

                 
                  userData.SetBlessCoin(blessCoin + (int)blessCoin_goldBonus + userData.GetBlessCoin());
                  userData.RefreshBlessCoinUI();
            }
      }
}
