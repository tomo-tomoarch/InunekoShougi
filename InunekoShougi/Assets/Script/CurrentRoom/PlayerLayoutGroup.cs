using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayoutGroup : MonoBehaviour
{

    [SerializeField]
    private GameObject _playerListingPrefab;
    private GameObject PlayerListingPrefab
    {
        get { return _playerListingPrefab; }
    }

    private List<PlayerListing> _playerListings = new List<PlayerListing>();
    private List<PlayerListing> PlayerListings
    {
        get { return _playerListings; }
    }

    public AudioSource dog;
    public AudioSource cat;
    private PhotonView PhotonView;


    private void Awake()
    {
        PhotonView = GetComponent<PhotonView>();
    }

    //called by photon whenever you join a room.
    private void OnJoinedRoom()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        MainCanvasManager.Instance.CurrentRoomCanvas.transform.SetAsLastSibling();

        PhotonPlayer[] photonPlayers = PhotonNetwork.playerList;
        for (int i = 0; i < photonPlayers.Length; i++)
        {
            PlayerJoinedRoom(photonPlayers[i]);
        }
        if(photonPlayers.Length == 1)
        {
            PhotonView.RPC("RPC_Dog", PhotonTargets.All);
        }
        else
        {
            PhotonView.RPC("RPC_Cat", PhotonTargets.All);
        }
        

    }
    
    //Called by photon whenever the master client is switched.
    private void OnMasterClientSwitched(PhotonPlayer newMasterClient)
    {
        PhotonNetwork.LeaveRoom();
    }



    //Called by photon when a player joins the room.
    private void OnPhotonPlayerConnected(PhotonPlayer photonPlayer)
    {
        PlayerJoinedRoom(photonPlayer);
        
    }

    //Called by photon when a player leaves the room.
    private void OnPhotonPlayerDisconnected(PhotonPlayer photonPlayer)
    {
        PlayerLeftRoom(photonPlayer);
    }


    private void PlayerJoinedRoom(PhotonPlayer photonPlayer)
    {
        if (photonPlayer == null)
            return;

        PlayerLeftRoom(photonPlayer);

        GameObject playerListingObj = Instantiate(PlayerListingPrefab);
        playerListingObj.transform.SetParent(transform, false);

        PlayerListing playerListing = playerListingObj.GetComponent<PlayerListing>();
        playerListing.ApplyPhotonPlayer(photonPlayer);

        PlayerListings.Add(playerListing);

    }


    private void PlayerLeftRoom(PhotonPlayer photonPlayer)
    {
        int index = PlayerListings.FindIndex(x => x.PhotonPlayer == photonPlayer);
        if ( index != -1)
        {
            Destroy(PlayerListings[index].gameObject);
            PlayerListings.RemoveAt(index);
        }
    }

    public void OnClickRoomState()
    {
       // if (!PhotonNetwork.isMasterClient)
       //     return;

       // PhotonNetwork.room.IsOpen = !PhotonNetwork.room.IsOpen;
       // PhotonNetwork.room.IsVisible = PhotonNetwork.room.IsOpen;
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    [PunRPC]
    private void RPC_Dog()
    {

        AudioSource[] audioSources = GetComponents<AudioSource>();
        audioSources[0].Play(0);
    }

    [PunRPC]
    private void RPC_Cat()
    {

        AudioSource[] audioSources = GetComponents<AudioSource>();
        audioSources[1].Play(0);
    }
       
}
