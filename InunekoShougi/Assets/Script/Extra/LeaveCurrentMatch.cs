using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveCurrentMatch : MonoBehaviour
{
    INSCore insCore;
    private PunTurnManager turnManager;

    public void OnClick_LeaveCurrentMatch()
    {
        insCore = GameObject.Find("TurnSystems").GetComponent<INSCore>();


        //this.turnManager = this.gameObject.GetComponent<PunTurnManager>();
        //this.gameObject.SetActive(false);
        
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(1);
    }



}
