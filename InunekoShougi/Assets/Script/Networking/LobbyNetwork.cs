using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyNetwork : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        if (!PhotonNetwork.connected)
        {
            print("connecting to server...");
            PhotonNetwork.ConnectUsingSettings("0.5.1");
        }
    }

 
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
