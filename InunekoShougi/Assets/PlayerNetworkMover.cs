﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkMover : Photon.MonoBehaviour
{
    KomaModel card;
    DoubleClick doubleClick;

    Vector3 position;
    public int clickedNum;
    float smoothing = 1f;
    private int i = 0;


    void Awake()
    {
        card = GetComponent<KomaModel>();
        doubleClick = GetComponent<DoubleClick>();
    }

    void Update()//start から変更
    {
       
       if (photonView.isMine)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            StartCoroutine("UpdateData");
        }
    }
    IEnumerator UpdateData()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * smoothing);
            yield return null;
        }
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.isWriting)
        {
            stream.SendNext(transform.position);　//現在のポジションを送る
            stream.SendNext(card.cardIndex);　//cardIndexの情報を送る
            stream.SendNext(doubleClick.clickNum);　//クリックされた回数を送る
        }
        else
       {
            KomaModel cardModel = GetComponent<KomaModel>();　//受信先のCardModelを取得
            position = (Vector3)stream.ReceiveNext();　//現在のポジションを受信
            cardModel.cardIndex = (int)stream.ReceiveNext(); //cardIndexの情報を受信
            clickedNum = (int)stream.ReceiveNext(); //クリックされた回数を受信

            if (clickedNum % 3 == 1) 
            {
                cardModel.ToggleFace(0); //表をレンダー
            }else if(clickedNum % 3 == 2)
            {
                cardModel.ToggleFace(2); //裏をレンダー
            }
            else
            {
                cardModel.ToggleFace(1);
            }                     
       }
    }
}