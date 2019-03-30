
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetwork : MonoBehaviour
{

    NetworkManager networkManager;//追加
    INSCore insCore;

    public static PlayerNetwork Instance;
    public string PlayerName{ get; private set;}
    private PhotonView PhotonView;
    private int PlayersInGame = 0;

    
  
    private void Awake()
    {

        Instance = this;
        PhotonView = GetComponent<PhotonView>();

        PlayerName = "Player#" + Random.Range(1000, 9999);

        SceneManager.sceneLoaded += OnSceneFinishedLoading;

        PhotonNetwork.LoadLevel(1);
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        PlayersInGame = 0;// プレイヤー数のリセット
    

        if (scene.name == "Game")
        {
            if (PhotonNetwork.isMasterClient)
                MasterLoadedGame();
            
            else
                NonMasterLoadedGame();
           
        }
    }

    private void MasterLoadedGame()
    {
        Debug.Log("MasterLoadedGame");//1回目

        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);//1
        PhotonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others);//1
    }

    private void NonMasterLoadedGame()
    {
        Debug.Log("NonMasterLoadedGame");
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);//1B
    }

    [PunRPC]
    private void RPC_LoadGameOthers()//2other
    {
        Debug.Log("LoadGameOthers");
        PhotonNetwork.LoadLevel(2);
    
    }

    [PunRPC]
    private void RPC_LoadedGameScene()//2master , 2Bmaster
    {
        PlayersInGame++;
        if(PlayersInGame == PhotonNetwork.playerList.Length)
        {
            Debug.Log("All players are in the game scene.");//1回目
            PhotonView.RPC("RPC_CreatePlayer", PhotonTargets.MasterClient);
            PhotonView.RPC("RPC_CreatePlayer", PhotonTargets.Others);

        }
    }

    [PunRPC]
    private void RPC_CreatePlayer()//  3bmaster,other
    {
        networkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        networkManager.StartingProcess();

     
        insCore = GameObject.Find("TurnSystems").GetComponent<INSCore>();
        insCore.StartTurn();
          
      
    }
}
