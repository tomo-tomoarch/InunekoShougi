using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //text 使うので

public class NetworkManager : MonoBehaviour {

    Deck deck; //Deckクラスを参照します
   // ChipCalculator chipCalculator;

    [SerializeField] Text connectionText;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Camera sceneCamera;
    

    public float cardOffset; //カードのずらし幅offsetの宣言
    public Vector3 startfirst;
    public Vector3 startsecond;
    GameObject player;
    /*
      void Start()
      {
          //PhotonNetwork.logLevel = PhotonLogLevel.Full;
          //PhotonNetwork.ConnectUsingSettings("0.2");

          //deck = GetComponent<Deck>(); //Deck.csの取得
          deck = GameObject.Find("Deck").GetComponent<Deck>();
      }

          void Update()
          {
              connectionText.text = PhotonNetwork.connectionStateDetailed.ToString();

          }

          void OnJoinedLobby()
          {
              RoomOptions ro = new RoomOptions() { isVisible = true, maxPlayers = 2 };
              PhotonNetwork.JoinOrCreateRoom("Tomo", ro, TypedLobby.Default);

          }
      */
    public void StartSpawnProcess(float respawnTime)
    {
        if(PhotonNetwork.player.ID == 1)
        {
            sceneCamera.enabled = true;
        }
        else
        {
            sceneCamera.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

    public void StartingProcess()
    {
        deck = GameObject.Find("Deck").GetComponent<Deck>();

        StartSpawnProcess(0f);
        if (PhotonNetwork.player.ID == 1)
        {
            int index = 0;
            int cardCount = 0;　//内部で使う値cardCountの宣言
            deck.Shuffle();

            Vector3 temp3 = new Vector3(0.031f, -4.137f, 0);
           
            foreach (int i in deck.GetCards())
            {
                    float co = cardOffset * cardCount; //オフセット幅の計算
                    Vector3 temp = startfirst + new Vector3(4.3f -co, -2f,-1.0f);
                    GameObject cardCopy = (GameObject)PhotonNetwork.Instantiate("Koma", temp, spawnPoints[index].rotation, 0);
                   
                    KomaModel cardModel = cardCopy.GetComponent<KomaModel>();
                    cardModel.cardIndex = i;//インデックスにiを代入
                    cardModel.ToggleFace(0);
                    
                    cardCount++; //cardCountをインクリメント
               
            }

        }
        else
        {
            int index = 1;
            int cardCount = 0; //内部で使う値cardCountの宣言
            Vector3 temp2 = new Vector3(-6.61f, 3.18f, 0);

            
            foreach (int i in deck.GetCards())
            {

                    float co = cardOffset * cardCount; //オフセット幅の計算
                    Vector3 temp = startfirst + new Vector3(-3.1f -co, 2f,-1.0f);
                    GameObject cardCopy = (GameObject)PhotonNetwork.Instantiate("neko", temp, spawnPoints[index].rotation, 0);
                    
                    KomaModel cardModel = cardCopy.GetComponent<KomaModel>();
                    cardModel.cardIndex = i;//インデックスにiを代入
                    cardModel.ToggleFace(0);
                    
                    cardCount++; //cardCountをインクリメント

            }

            Vector3 matatabi = new Vector3(-3.7f, 1f, -1.0f);
            GameObject matatabihone = (GameObject)PhotonNetwork.Instantiate("hone", matatabi, spawnPoints[index].rotation, 0);

            KomaModel matatabiModel = matatabihone.GetComponent<KomaModel>();
            matatabiModel.cardIndex = 5;
            matatabiModel.ToggleFace(0);
        } 
    }

}
