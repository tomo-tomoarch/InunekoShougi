using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleClick : MonoBehaviour, IPointerClickHandler
{
    KomaModel cardmodel;
    public int clickNum = 0; //外部参照用のクリック数の宣言
    private int i = 0;

    void Awake()
    {
        cardmodel = GetComponent<KomaModel>();
    }

   public void OnPointerClick(PointerEventData eventData)
   {

        if (eventData.clickCount > 1)
        {
            i++;
            if (i % 3 == 1)
            {
                Debug.Log(eventData.clickCount);
                clickNum = i; //外部参照用のクリック数（PlayerNetwrokMoverで取得する）
                cardmodel.ToggleFace(0);
                GetComponent<MouseOverAlways>().enabled = false;
            }
            else if (i % 3 == 2)
            {
                Debug.Log(eventData.clickCount);
                clickNum = i; //外部参照用のクリック数（PlayerNetwrokMoverで取得する）
                cardmodel.ToggleFace(2);
                GetComponent<MouseOverAlways>().enabled = false;
            }
            else
            {
                Debug.Log(eventData.clickCount);
                clickNum = i; //外部参照用のクリック数（PlayerNetwrokMoverで取得する）
                cardmodel.ToggleFace(1);
                GetComponent<MouseOverAlways>().enabled = true;
            }
        }
        
    }
}