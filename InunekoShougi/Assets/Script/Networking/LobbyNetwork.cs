﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyNetwork : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        print("connecting to server...");
        PhotonNetwork.ConnectUsingSettings("0.4");
    }

    // Update is called once per frame
    private void OnConnectedToMaster()
    {
        print("connected to master.");

        PhotonNetwork.automaticallySyncScene = false;

        PhotonNetwork.playerName = PlayerNetwork.Instance.PlayerName;

        PhotonNetwork.JoinLobby(TypedLobby.Default);


    }

    private void OnJoinedLobby()
    {
        print("joined lobby.");

        if(!PhotonNetwork.inRoom)
        MainCanvasManager.Instance.LobbyCanvas.transform.SetAsLastSibling();
    }
}
