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

    int move;


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

        if (endkomaPosition[0] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition0"])//駒の現在値とルームカスタムプロパティの値を比べる
        {
            Debug.Log(endkomaPosition[0]);
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition0"] == 26)
            {
                komaModel = koma[0].GetComponent<KomaModel>();
                komaModel.flag = false;//フラグを折る
            }

            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition0"] != 26)//駒を打ってない場合
            {
                move = Mathf.Abs((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition0"] - endkomaPosition[0]);//移動したマスの絶対値が
                if (move != 1 && move != 4 && move != 5 && move != 6)//王の動ける範囲でない場合
                {
                    komaModel = koma[0].GetComponent<KomaModel>();
                    komaModel.flag = true;//フラグを立てる
                }
            }


            Debug.Log(move);

            insCore.MakeTurn(0);//値が違う場合ターンを回す
        }
        if (endkomaPosition[1] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition1"])
        {
            Debug.Log(endkomaPosition[1]);
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition1"] == 26)
            {
                komaModel = koma[1].GetComponent<KomaModel>();
                komaModel.flag = false;//フラグを折る
            }

            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition1"] != 26)
            {
                move = Mathf.Abs((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition1"] - endkomaPosition[1]);
                if (move != 1 && move != 4 && move != 5 && move != 6)
                {
                    komaModel = koma[1].GetComponent<KomaModel>();
                    komaModel.flag = true;
                }
            }


            Debug.Log(move);

            insCore.MakeTurn(1);
        }
        if (endkomaPosition[2] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition2"])
        {
            Debug.Log(endkomaPosition[2]);
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition2"] == 26)
            {
                komaModel = koma[2].GetComponent<KomaModel>();
                komaModel.flag = false;//フラグを折る
            }

            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition2"] != 26)
            {
                move = Mathf.Abs((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition2"] - endkomaPosition[2]);
                if (move != 1 && move != 4 && move != 5 && move != 6)
                {
                    komaModel = koma[2].GetComponent<KomaModel>();
                    komaModel.flag = true;
                }
            }


            Debug.Log(move);

            insCore.MakeTurn(2);
        }
        if (endkomaPosition[3] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition3"])
        {
            Debug.Log(endkomaPosition[3]);
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition3"] == 26)
            {
                komaModel = koma[3].GetComponent<KomaModel>();
                komaModel.flag = false;//フラグを折る
            }

            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition3"] != 26)
            {
                move = Mathf.Abs((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition3"] - endkomaPosition[3]);
                if (move != 1 && move != 4 && move != 5 && move != 6)
                {
                    komaModel = koma[3].GetComponent<KomaModel>();
                    komaModel.flag = true;
                }

            }

            Debug.Log(move);

            insCore.MakeTurn(3);
        }
        if (endkomaPosition[4] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition4"])
        {
            Debug.Log(endkomaPosition[4]);
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition4"] == 26)
            {
                komaModel = koma[4].GetComponent<KomaModel>();
                komaModel.flag = false;//フラグを折る
            }
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition4"] != 26)
            {
                move = Mathf.Abs((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition4"] - endkomaPosition[4]);
                if (move != 1 && move != 4 && move != 5 && move != 6)
                {
                    komaModel = koma[4].GetComponent<KomaModel>();
                    komaModel.flag = true;
                }
            }


            Debug.Log(move);

            insCore.MakeTurn(4);
        }
        if (endkomaPosition[5] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition5"])
        {
            Debug.Log(endkomaPosition[5]);
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition5"] == 26)
            {
                komaModel = koma[5].GetComponent<KomaModel>();
                komaModel.flag = false;//フラグを折る
            }

            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition5"] != 26)
            {
                move = Mathf.Abs((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition5"] - endkomaPosition[5]);
                if (move != 1 && move != 4 && move != 5 && move != 6)
                {
                    komaModel = koma[5].GetComponent<KomaModel>();
                    komaModel.flag = true;
                }
            }


            Debug.Log(move);

            insCore.MakeTurn(5);
        }
        if (endkomaPosition[6] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition6"])
        {
            Debug.Log(endkomaPosition[6]);
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition6"] == 26)
            {
                komaModel = koma[6].GetComponent<KomaModel>();
                komaModel.flag = false;//フラグを折る
            }

            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition6"] != 26)
            {
                move = Mathf.Abs((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition6"] - endkomaPosition[6]);
                if (move != 1 && move != 4 && move != 5 && move != 6)
                {
                    komaModel = koma[6].GetComponent<KomaModel>();
                    komaModel.flag = true;
                }
            }


            Debug.Log(move);

            insCore.MakeTurn(6);
        }
        if (endkomaPosition[7] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition7"])
        {
            Debug.Log(endkomaPosition[7]);
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition7"] == 26)
            {
                komaModel = koma[7].GetComponent<KomaModel>();
                komaModel.flag = false;//フラグを折る
            }
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition7"] != 26)
            {
                move = Mathf.Abs((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition7"] - endkomaPosition[7]);
                if (move != 1 && move != 4 && move != 5 && move != 6)
                {
                    komaModel = koma[7].GetComponent<KomaModel>();
                    komaModel.flag = true;
                }
            }


            Debug.Log(move);

            insCore.MakeTurn(7);
        }
        if (endkomaPosition[8] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition8"])
        {
            Debug.Log(endkomaPosition[8]);
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition8"] == 26)
            {
                komaModel = koma[8].GetComponent<KomaModel>();
                komaModel.flag = false;//フラグを折る
            }
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition8"] != 26)
            {
                move = Mathf.Abs((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition8"] - endkomaPosition[8]);
                if (move != 1 && move != 4 && move != 5 && move != 6)
                {
                    komaModel = koma[8].GetComponent<KomaModel>();
                    komaModel.flag = true;
                }
            }


            Debug.Log(move);

            insCore.MakeTurn(8);
        }
        if (endkomaPosition[9] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition9"])
        {
            Debug.Log(endkomaPosition[9]);
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition9"] == 26)
            {
                komaModel = koma[9].GetComponent<KomaModel>();
                komaModel.flag = false;//フラグを折る
            }
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition9"] != 26)
            {
                move = Mathf.Abs((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition9"] - endkomaPosition[9]);
                if (move != 1 && move != 4 && move != 5 && move != 6)
                {
                    komaModel = koma[9].GetComponent<KomaModel>();
                    komaModel.flag = true;
                }
            }


            Debug.Log(move);

            insCore.MakeTurn(9);
        }
        if (endkomaPosition[10] != (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition10"])
        {
            Debug.Log(endkomaPosition[10]);
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition10"] == 26)
            {
                komaModel = koma[10].GetComponent<KomaModel>();
                komaModel.flag = false;//フラグを折る
            }
            if ((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition10"] != 26)
            {
                move = Mathf.Abs((int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "komaPosition10"] - endkomaPosition[10]);
                if (move != 1 && move != 4 && move != 5 && move != 6)
                {
                    komaModel = koma[10].GetComponent<KomaModel>();
                    komaModel.flag = true;
                }
            }


            Debug.Log(move);

            insCore.MakeTurn(10);
        }
    }
}
