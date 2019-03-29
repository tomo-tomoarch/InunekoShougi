using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : Photon.MonoBehaviour
{
    MasuHandler masuHandler;
    KomaModel komaModel;
    DirectionDeterminator directionDeterminator;
    TurnCheckerEnd turnCheckerEnd;
    TurnChecker turnChecker;

    public Transform[] spawnPoints;

    Collider2D m_ObjectCollider;
    GameObject[] koma;

    public float xzahyou;
    public float yzahyou;
    public int KomaShu;
    public int KomaNaru;


    public AudioSource dog;
    public AudioSource cat;

    //マウスでドラッグするスクリプト

    private Vector3 screenPoint;
    private Vector3 offset;

    private void Start()
    {
        directionDeterminator = GameObject.Find("DirectionDeterminator").GetComponent<DirectionDeterminator>();
        masuHandler = GameObject.Find("MasuHandler").GetComponent<MasuHandler>();
        komaModel = GetComponent<KomaModel>();
        turnCheckerEnd = GameObject.Find("TurnSystems").GetComponent<TurnCheckerEnd>();
        turnChecker = GameObject.Find("TurnSystems").GetComponent<TurnChecker>();
    }

    void OnMouseDown()
    {
            this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        xzahyou = transform.position.x;
        yzahyou = transform.position.y;
        KomaShu = komaModel.cardIndex;
        KomaNaru = komaModel.komaBackIndex;
       
        masuHandler.MasuCordinator(xzahyou, yzahyou, KomaShu, komaModel.naru,komaModel.komaNariField); //引数を加える。

       
        m_ObjectCollider = GetComponent<BoxCollider2D>();
        m_ObjectCollider.isTrigger = false;

        //Debug.Log("mousedown");

        turnChecker.TurnCheck();

    }

    void OnMouseDrag()
    {
        
         Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
         Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
         transform.position = currentPosition;
        
    }

    void OnMouseUp()
    {
        xzahyou = transform.position.x;
        yzahyou = transform.position.y;
        KomaShu = komaModel.cardIndex;
        KomaNaru = komaModel.komaBackIndex;

        masuHandler.MasuCordinator(xzahyou, yzahyou, KomaShu, komaModel.naru, komaModel.komaNariField);

        m_ObjectCollider = GetComponent<BoxCollider2D>();
        m_ObjectCollider.isTrigger = true;

        directionDeterminator.ResetAll(masuHandler.masuNum);

        
        koma = GameObject.FindGameObjectsWithTag("koma");
            

        int i;
        for (i = 0; i < koma.Length; i++)
            {
            if (Mathf.Abs(koma[i].transform.position.x - xzahyou) <= 0.2f && Mathf.Abs(koma[i].transform.position.y - yzahyou) <= 0.2f && Mathf.Abs(koma[i].transform.position.x - xzahyou) != 0)
            {
                    //Debug.Log(koma[i].transform.position.x - xzahyou);
                    //Debug.Log(koma[i].transform.position.y - yzahyou);

                    koma[i].GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.player.ID);
                    KomaModel komaModel = koma[i].GetComponent<KomaModel>();
                    int j = komaModel.cardIndex;

                int index = PhotonNetwork.player.ID - 1;

                if(index > 1)
                {
                    index = 1;
                }

                PhotonNetwork.Destroy(koma[i]);

                if (j < 5 && PhotonNetwork.player.ID == 1)
                {
                    dog = GetComponent<AudioSource>();
                    dog.Play(0);

                    Vector3 temp = new Vector3(4.3f, -1.5f, -1.0f);//(-3.1f, 1.5f, -1.0f)
                    GameObject cardCopy = (GameObject)PhotonNetwork.Instantiate("uchikoma", temp, spawnPoints[index].rotation, 0);

                    KomaModel cardModel = cardCopy.GetComponent<KomaModel>();
                    cardModel.cardIndex = j;
                    cardModel.ToggleFace(1);
                }
                else if(j < 5 && PhotonNetwork.player.ID != 1)
                {
                    cat= GetComponent<AudioSource>();
                    cat.Play(0);

                    Vector3 temp = new Vector3(-3.1f, 1.5f, -1.0f);
                    GameObject cardCopy = (GameObject)PhotonNetwork.Instantiate("uchineko", temp, spawnPoints[index].rotation, 0);

                    KomaModel cardModel = cardCopy.GetComponent<KomaModel>();
                    cardModel.cardIndex = j;
                    cardModel.ToggleFace(1);
                }
                else if(j == 5 && PhotonNetwork.player.ID == 1)
                {
                    dog = GetComponent<AudioSource>();
                    dog.Play(0);

                    Vector3 temp = new Vector3(4.3f, -1.5f, -1.0f);//(-3.1f, 1.5f, -1.0f)
                    GameObject cardCopy = (GameObject)PhotonNetwork.Instantiate("matatabi", temp, spawnPoints[index].rotation, 0);

                    KomaModel cardModel = cardCopy.GetComponent<KomaModel>();
                    cardModel.cardIndex = j;
                    cardModel.ToggleFace(1);
                }
                else if (j == 5 && PhotonNetwork.player.ID != 1)
                {
                    cat = GetComponent<AudioSource>();
                    cat.Play(0);

                    Vector3 temp = new Vector3(-3.1f, 1.5f, -1.0f);
                    GameObject cardCopy = (GameObject)PhotonNetwork.Instantiate("hone", temp, spawnPoints[index].rotation, 0);

                    KomaModel cardModel = cardCopy.GetComponent<KomaModel>();
                    cardModel.cardIndex = j;
                    cardModel.ToggleFace(1);
                }
            }
        }

        turnCheckerEnd.TurnCheckEnd();
    } 
}
