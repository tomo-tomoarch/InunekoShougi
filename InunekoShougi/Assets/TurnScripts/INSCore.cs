using System; // 注意
using System.Collections;
using Photon; // 注意
using UnityEngine;
using UnityEngine.UI;　//注意

public class INSCore : PunBehaviour, IPunTurnManagerCallbacks// このコールバックを使用する際は1，2，3，4，5を実装しなければならない
{
    private PhotonView PhotonView;//追加する

    TurnChecker turnChecker;

    GameObject[] koma;
    Mouse mouse;
    PlayerNetworkMover playerNetworkMover;

    Image redFill;

    [SerializeField]
    private RectTransform TimerFillImage;//タイマーの赤い部分

    [SerializeField]
    private Text TurnText;//ターン数の表示テキスト

    [SerializeField]
    private Text TimeText;//残り時間の表示テキスト

    [SerializeField]
    private Text WaitingText;//待ってくださいのテキスト

    [SerializeField]
    private Text YourTurnText;

    [SerializeField]
    private Text ShoumeiText;

    [SerializeField]
    private Text WinText;

    [SerializeField]
    private Text LoseText;


    private int flagNumber;

   

    INSCore insCore;




    private int number=0;

    private bool IsShowingResults;//真偽値




    private PunTurnManager turnManager;

    public void Awake()// StartをAwakeに変更。
    {
        this.turnManager = this.gameObject.AddComponent<PunTurnManager>();//PunTurnManagerをコンポーネントに追加
        this.turnManager.TurnManagerListener = this;//リスナーを？
        this.turnManager.TurnDuration = 30f;//ターンは30秒にする

        PhotonView = GameObject.Find("TurnSystems").GetComponent<PhotonView>();//scriptsにphotonviewを付けておくのを忘れずに。
        turnChecker = GameObject.Find("TurnSystems").GetComponent<TurnChecker>();
    }


    private void Start()
    {
        int j;
        for (j = 0; j < 11; j++)
        {
           var properties = new ExitGames.Client.Photon.Hashtable();
           string card = PhotonNetwork.player.ID + "komaPosition" + j;
           properties.Add(card, null);　//ルームカスタムプロパティのリセット
           PhotonNetwork.room.SetCustomProperties(properties);
        }
    }

    void Update()
    {

        if (this.TurnText != null)
        {
            this.TurnText.text = this.turnManager.Turn.ToString();//何ターン目かを表示してくれる
        }

        if (this.turnManager.Turn > 0 || this.TimeText != null && !IsShowingResults)//ターンが0以上、TimeTextがnullでない、結果が見えていない場合。
        {

            this.TimeText.text = this.turnManager.RemainingSecondsInTurn.ToString("F1") + " ";//小数点以下1桁の残り時間を表示。"seconds "

            TimerFillImage.anchorMax = new Vector2(1f - this.turnManager.RemainingSecondsInTurn / this.turnManager.TurnDuration, 1f);//残り時間のバーの表示。
        }

        if (this.turnManager.IsCompletedByAll) //両方のプレイヤーがターンを終了しているか
        {
            //後に処理を書く予定
        }
    }

    public void OnPlayerFinished(PhotonPlayer photonPlayer, int turn, object move)//1
    {
        //Debug.Log("OnTurnFinished: " + photonPlayer + " turn: " + turn + " action: " + move);
    }

    public void OnPlayerMove(PhotonPlayer photonPlayer, int turn, object move)//2
    {
        //Debug.Log("OnPlayerMove: " + photonPlayer + " turn: " + turn + " action: " + move);
    }

    public void OnTurnBegins(int turn)//3 ターンが開始した場合
    {
        //Debug.Log("OnTurnBegins() turn: " + turn);

        IsShowingResults = false;
    }

    public void OnTurnCompleted(int obj)//4ターン終了時に呼ばれるメソッド　（あなたのターン開始・終了みたいな文字を出す）
    {
       // Debug.Log("OnTurnCompleted: " + obj);
        this.OnEndTurn();//エンドターンに必要な処理をします
        this.StartTurn();
    }

    public void OnTurnTimeEnds(int turn)//5　タイマーが終了した場合
    {
        //this.StartTurn();
    }

    public void StartTurn()//ターン開始メソッド（シーン開始時にRPCから呼ばれる呼ばれるようにしてあります。）
    {
       if (PhotonNetwork.isMasterClient)
       {
            Debug.Log("StartTurn");

            if(number == this.turnManager.Turn)//BeginTurnが1ターンに1回しか回らないことのチェックをする。
            {
                this.turnManager.BeginTurn();//turnmanagerに新しいターンを始めさせる
                PhotonView.RPC("RPC_AutomaticSend", PhotonTargets.All);
                number++;//BeginTurnが2回目以降1ターンに回る場合にはこの変数がターンと一致しないようにする
            }
 
       }

        //turnChecker.TurnCheck();
    }

    public void MakeTurn(int index)//手を決めるメソッド
    {
        this.turnManager.SendMove(index, true);//アクションを送るときに呼ぶ（アクション,ターンを終了するかどうか(true)）
    }

    public void OnEndTurn()//エンドターンのメソッド
    {
        //ターンエンドで必要な処理を書く(後で使うかもしれません）
        
        redFill = GameObject.Find("Red Fill").GetComponent<Image>();
        redFill.enabled = true;

        koma = GameObject.FindGameObjectsWithTag("koma");


        int i;
        for (i = 0; i < koma.Length; i++)
        {
            var newOwner = koma[i].GetComponent<PhotonView>().ownerId;//相手の駒のownerID

            if (PhotonNetwork.player.ID == newOwner)
            {
                if(koma[i].GetComponent<Mouse>() == null)
                {
                    koma[i].AddComponent<Mouse>();
                }
              
               
                Debug.Log("mouse on");
            }
        }

        flagNumber = 0;

        for (i = 0; i < koma.Length; i++)
        {
            var newOwner = koma[i].GetComponent<PhotonView>().ownerId;//駒のownerID
            var komaModel = koma[i].GetComponent<KomaModel>();
            if (komaModel.flag == false && PhotonNetwork.player.ID == newOwner)
            {
                flagNumber++;
            }
        }

        if (flagNumber == 0 && this.turnManager.Turn > 2 )
        {
            if ((this.turnManager.Turn % 2)== PhotonNetwork.player.ID)
            {
                this.ShoumeiText.text = "王将がいないことがしょうめいされました";
                this.LoseText.text = "あなたのまけです";

                PhotonView.RPC("RPC_WinLoseInfo", PhotonTargets.Others);
            }
        }

    }

    [PunRPC]
    public void RPC_WinLoseInfo()
    {
        this.WinText.text = "あなたのかちです";
    }


    [PunRPC]
    public void RPC_AutomaticSend()
    {
        Debug.Log(turnManager.Turn);

        if ((this.turnManager.Turn % 2) + 1 == PhotonNetwork.player.ID)//2ターンに1回自分のターンを無条件で終わらせる
        {
            int index = 0;
            this.turnManager.SendMove(index, true);　//無条件でターン終了
            this.WaitingText.text = "あいてのてばんです...";　//待ちの表示テキスト
            this.YourTurnText.text = "";

            redFill = GameObject.Find("Red Fill").GetComponent<Image>();//赤いバーを表示しない
            redFill.enabled = false;


            koma = GameObject.FindGameObjectsWithTag("koma");

     
            int i;
            for (i = 0; i < koma.Length; i++)
            {
                var newOwner = koma[i].GetComponent<PhotonView>().ownerId;//相手の駒のownerID

                if (PhotonNetwork.player.ID == newOwner)
                {
                    mouse = koma[i].GetComponent<Mouse>();
                    Destroy(mouse);


                    Debug.Log("mouse off");
                }
            }
        


                Debug.Log("RPC_AutomaticSend");
        }
        else
        {
            this.WaitingText.text = "";
            this.YourTurnText.text = "あなたのてばんです";
        }
    }
}
