using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverAlways : Photon.MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    CardFlipper flipper;
    KomaModel komaModel;
    

    private void Awake()
    {
        flipper = GetComponent<CardFlipper>();
        komaModel = GetComponent<KomaModel>();
    }

    private void Update()
    {
       
    }

    // オブジェクトの範囲内にマウスポインタが入った際に呼び出されます。
    public void OnPointerEnter(PointerEventData eventData)
    {
       
            komaModel.ToggleFace(0);
            //カードの表面を表示する
       
    }

    // オブジェクトの範囲内からマウスポインタが出た際に呼び出されます。
    public void OnPointerExit(PointerEventData eventData)
    {
      
            flipper.FlipCard(komaModel.faces[komaModel.cardIndex], komaModel.komaBack, -1);
            //カードを裏返すアニメーション処理の呼出
       
    }
}
