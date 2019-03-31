using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCheckerEnd : Photon.MonoBehaviour
{
    INSCore insCore;
    KomaModel komaModel;
    GameObject[] koma;
    float x;
    float y;
    int masuNum;
    int owner;


    private void Start()
    {
        insCore = GameObject.Find("TurnSystems").GetComponent<INSCore>();
    }

    public void TurnCheckEnd()
    {
        var endkomaPosition = new List<int>();
        var endkomaIndex = new List<int>();
        var endkomaNari = new List<bool>();
        //var komaFlag = new List<bool>();

        koma = GameObject.FindGameObjectsWithTag("koma");


        int i;
        for (i = 0; i < koma.Length; i++)
        {
            x = koma[i].transform.position.x;
            y = koma[i].transform.position.y;

            KomaModel komaModel = koma[i].GetComponent<KomaModel>();
            endkomaIndex.Add(komaModel.cardIndex);
            endkomaNari.Add(komaModel.naru);

     

            if (-1.5f > x && x > -2.5f)
            {
                if (1.5f < y && y < 2.5f)
                {
                    masuNum = 1;
                    endkomaPosition.Add(masuNum);
                }
                else if (0.5f < y && y < 1.5f)
                {
                    masuNum = 6;
                    endkomaPosition.Add(masuNum);
                }
                else if (-0.5f < y && y < 0.5f)
                {
                    masuNum = 11;
                    endkomaPosition.Add(masuNum);
                }
                else if (-1.5f < y && y < -0.5f)
                {
                    masuNum = 16;
                    endkomaPosition.Add(masuNum);
                }
                else if (-2.5f < y && y < -1.5f)
                {
                    masuNum = 21;
                    endkomaPosition.Add(masuNum);
                }
                else
                {
                    masuNum = 26;
                    endkomaPosition.Add(masuNum);
                }
            }
            else if (-0.5f > x && x > -1.5f)
            {
                if (1.5f < y && y < 2.5f)
                {
                    masuNum = 2;
                    endkomaPosition.Add(masuNum);
                }
                else if (0.5f < y && y < 1.5f)
                {
                    masuNum = 7;
                    endkomaPosition.Add(masuNum);
                }
                else if (-0.5f < y && y < 0.5f)
                {
                    masuNum = 12;
                    endkomaPosition.Add(masuNum);
                }
                else if (-1.5f < y && y < -0.5f)
                {
                    masuNum = 17;
                    endkomaPosition.Add(masuNum);
                }
                else if (-2.5f < y && y < -1.5f)
                {
                    masuNum = 22;
                    endkomaPosition.Add(masuNum);
                }
                else
                {
                    masuNum = 26;
                    endkomaPosition.Add(masuNum);
                }
            }
            else if (0.5f > x && x > -0.5f)
            {
                if (1.5f < y && y < 2.5f)
                {
                    masuNum = 3;
                    endkomaPosition.Add(masuNum);
                }
                else if (0.5f < y && y < 1.5f)
                {
                    masuNum = 8;
                    endkomaPosition.Add(masuNum);
                }
                else if (-0.5f < y && y < 0.5f)
                {
                    masuNum = 13;
                    endkomaPosition.Add(masuNum);
                }
                else if (-1.5f < y && y < -0.5f)
                {
                    masuNum = 18;
                    endkomaPosition.Add(masuNum);
                }
                else if (-2.5f < y && y < -1.5f)
                {
                    masuNum = 23;
                    endkomaPosition.Add(masuNum);
                }
                else
                {
                    masuNum = 26;
                    endkomaPosition.Add(masuNum);
                }
            }
            else if (1.5f > x && x > 0.5f)
            {
                if (1.5f < y && y < 2.5f)
                {
                    masuNum = 4;
                    endkomaPosition.Add(masuNum);
                }
                else if (0.5f < y && y < 1.5f)
                {
                    masuNum = 9;
                    endkomaPosition.Add(masuNum);
                }
                else if (-0.5f < y && y < 0.5f)
                {
                    masuNum = 14;
                    endkomaPosition.Add(masuNum);
                }
                else if (-1.5f < y && y < -0.5f)
                {
                    masuNum = 19;
                    endkomaPosition.Add(masuNum);
                }
                else if (-2.5f < y && y < -1.5f)
                {
                    masuNum = 24;
                    endkomaPosition.Add(masuNum);
                }
                else
                {
                    masuNum = 26;
                    endkomaPosition.Add(masuNum);
                }
            }
            else if (2.5f > x && x > 1.5f)
            {
                if (1.5f < y && y < 2.5f)
                {
                    masuNum = 5;
                    endkomaPosition.Add(masuNum);
                }
                else if (0.5f < y && y < 1.5f)
                {
                    masuNum = 10;
                    endkomaPosition.Add(masuNum);
                }
                else if (-0.5f < y && y < 0.5f)
                {
                    masuNum = 15;
                    endkomaPosition.Add(masuNum);
                }
                else if (-1.5f < y && y < -0.5f)
                {
                    masuNum = 20;
                    endkomaPosition.Add(masuNum);
                }
                else if (-2.5f < y && y < -1.5f)
                {
                    masuNum = 25;
                    endkomaPosition.Add(masuNum);
                }
                else
                {
                    masuNum = 26;
                    endkomaPosition.Add(masuNum);
                }
            }
            else
            {
                masuNum = 26;
                endkomaPosition.Add(masuNum);
            }
           
        }

        if(endkomaPosition[0] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition0"])//駒の現在値とルームカスタムプロパティの値を比べる
        {
            Debug.Log(endkomaPosition[0]);
            insCore.MakeTurn(0);//値が違う場合ターンを回す
        }
        if (endkomaPosition[1] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition1"])
        {
            Debug.Log(endkomaPosition[1]);
            insCore.MakeTurn(1);
        }
           if (endkomaPosition[2] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition2"])
        {
            Debug.Log(endkomaPosition[2]);
            insCore.MakeTurn(2);
        }
           if (endkomaPosition[3] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition3"])
        {
            Debug.Log(endkomaPosition[3]);
            insCore.MakeTurn(3);
        }
           if (endkomaPosition[4] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition4"])
        {
            Debug.Log(endkomaPosition[4]);
            insCore.MakeTurn(4);
        }
           if (endkomaPosition[5] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition5"])
        {
            Debug.Log(endkomaPosition[5]);
            insCore.MakeTurn(5);
        }
           if (endkomaPosition[6] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition6"])
        {
            Debug.Log(endkomaPosition[6]);
            insCore.MakeTurn(6);
        }
           if (endkomaPosition[7] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition7"])
        {
            Debug.Log(endkomaPosition[7]);
            insCore.MakeTurn(7);
        }
           if (endkomaPosition[8] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition8"])
        {
            Debug.Log(endkomaPosition[8]);
            insCore.MakeTurn(8);
        }
           if (endkomaPosition[9] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition9"])
        {
            Debug.Log(endkomaPosition[9]);
            insCore.MakeTurn(9);
        }
           if (endkomaPosition[10] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition10"])
        {
            Debug.Log(endkomaPosition[10]);
            insCore.MakeTurn(10);
        }
    
    }
}
