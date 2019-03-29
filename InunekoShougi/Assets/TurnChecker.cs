using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnChecker : Photon.MonoBehaviour
{
    KomaModel komaModel;
    GameObject[] koma;
    float x;
    float y;
    int masuNum;
    int owner;
  
    public void TurnCheck()
    {
        var komaPosition = new List<int>();
        var komaIndex = new List<int>();
        var komaNari = new List<bool>();
        //var komaFlag = new List<bool>();

        koma = GameObject.FindGameObjectsWithTag("koma");
      

        int i;
        for (i = 0; i < koma.Length; i++)
        {
            x = koma[i].transform.position.x;
            y = koma[i].transform.position.y;

            KomaModel komaModel = koma[i].GetComponent<KomaModel>();
            komaIndex.Add(komaModel.cardIndex);
            komaNari.Add(komaModel.naru);

            if (-1.5f > x && x > -2.5f)
            {
                if (1.5f < y && y < 2.5f)
                {
                    masuNum = 1;
                    komaPosition.Add(masuNum);
                }
                else if (0.5f < y && y < 1.5f)
                {
                    masuNum = 6;
                    komaPosition.Add(masuNum);
                }
                else if (-0.5f < y && y < 0.5f)
                {
                    masuNum = 11;
                    komaPosition.Add(masuNum);
                }
                else if (-1.5f < y && y < -0.5f)
                {
                    masuNum = 16;
                    komaPosition.Add(masuNum);
                }
                else if (-2.5f < y && y < -1.5f)
                {
                    masuNum = 21;
                    komaPosition.Add(masuNum);
                }
                else
                {
                    masuNum = 26;
                    komaPosition.Add(masuNum);
                }
            }
            else if (-0.5f > x && x > -1.5f)
            {
                if (1.5f < y && y < 2.5f)
                {
                    masuNum = 2;
                    komaPosition.Add(masuNum);
                }
                else if (0.5f < y && y < 1.5f)
                {
                    masuNum = 7;
                    komaPosition.Add(masuNum);
                }
                else if (-0.5f < y && y < 0.5f)
                {
                    masuNum = 12;
                    komaPosition.Add(masuNum);
                }
                else if (-1.5f < y && y < -0.5f)
                {
                    masuNum = 17;
                    komaPosition.Add(masuNum);
                }
                else if (-2.5f < y && y < -1.5f)
                {
                    masuNum = 22;
                    komaPosition.Add(masuNum);
                }
                else
                {
                    masuNum = 26;
                    komaPosition.Add(masuNum);
                }
            }
            else if (0.5f > x && x > -0.5f)
            {
                if (1.5f < y && y < 2.5f)
                {
                    masuNum = 3;
                    komaPosition.Add(masuNum);
                }
                else if (0.5f < y && y < 1.5f)
                {
                    masuNum = 8;
                    komaPosition.Add(masuNum);
                }
                else if (-0.5f < y && y < 0.5f)
                {
                    masuNum = 13;
                    komaPosition.Add(masuNum);
                }
                else if (-1.5f < y && y < -0.5f)
                {
                    masuNum = 18;
                    komaPosition.Add(masuNum);
                }
                else if (-2.5f < y && y < -1.5f)
                {
                    masuNum = 23;
                    komaPosition.Add(masuNum);
                }
                else
                {
                    masuNum = 26;
                    komaPosition.Add(masuNum);
                }
            }
            else if (1.5f > x && x > 0.5f)
            {
                if (1.5f < y && y < 2.5f)
                {
                    masuNum = 4;
                    komaPosition.Add(masuNum);
                }
                else if (0.5f < y && y < 1.5f)
                {
                    masuNum = 9;
                    komaPosition.Add(masuNum);
                }
                else if (-0.5f < y && y < 0.5f)
                {
                    masuNum = 14;
                    komaPosition.Add(masuNum);
                }
                else if (-1.5f < y && y < -0.5f)
                {
                    masuNum = 19;
                    komaPosition.Add(masuNum);
                }
                else if (-2.5f < y && y < -1.5f)
                {
                    masuNum = 24;
                    komaPosition.Add(masuNum);
                }
                else
                {
                    masuNum = 26;
                    komaPosition.Add(masuNum);
                }
            }
            else if (2.5f > x && x > 1.5f)
            {
                if (1.5f < y && y < 2.5f)
                {
                    masuNum = 5;
                    komaPosition.Add(masuNum);
                }
                else if (0.5f < y && y < 1.5f)
                {
                    masuNum = 10;
                    komaPosition.Add(masuNum);
                }
                else if (-0.5f < y && y < 0.5f)
                {
                    masuNum = 15;
                    komaPosition.Add(masuNum);
                }
                else if (-1.5f < y && y < -0.5f)
                {
                    masuNum = 20;
                    komaPosition.Add(masuNum);
                }
                else if (-2.5f < y && y < -1.5f)
                {
                    masuNum = 25;
                    komaPosition.Add(masuNum);
                }
                else
                {
                    masuNum = 26;
                    komaPosition.Add(masuNum);
                }
            }
            else
            {
                masuNum = 26;
                komaPosition.Add(masuNum);
            }

            /*
            Debug.Log(komaPosition.Count);

            int j;
            for (j = 0; j < komaPosition.Count; j++)
            {
                var properties = new ExitGames.Client.Photon.Hashtable();
                string card = PhotonNetwork.player.ID + "komaPosition" + j;
                properties.Add(card, komaPosition[j]);
                PhotonNetwork.room.SetCustomProperties(properties);
                Debug.Log(card + komaPosition[j]);
            }*/
        }

        int j;
        for (j = 0; j < komaPosition.Count; j++)
        {
            var properties = new ExitGames.Client.Photon.Hashtable();
            string card = PhotonNetwork.player.ID + "komaPosition" + j;
            properties.Add(card, komaPosition[j]);
            PhotonNetwork.room.SetCustomProperties(properties);
            //Debug.Log(card + komaPosition[j]);
        }
    }
}
