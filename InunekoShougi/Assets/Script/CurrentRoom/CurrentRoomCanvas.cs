﻿using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    public void OnClickStartSync()
    {
        if (!PhotonNetwork.isMasterClient)
            return;

        PhotonNetwork.LoadLevel(2);
    }

    public void OnClickStartDelayed()
    {
       if (!PhotonNetwork.isMasterClient)
         return;


        PhotonNetwork.room.IsOpen = false;
        PhotonNetwork.room.IsVisible = false;
        PhotonNetwork.LoadLevel(2);
    }
}
