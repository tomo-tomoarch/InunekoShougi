using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDeterminator : Photon.MonoBehaviour
{
    MasuHandler masuHandler;
    MeshRenderer meshRenderer;

    public GameObject[] Masu;
    public int[] movableMasu;

    // Start is called before the first frame update
    void Start()
    {
        masuHandler = GameObject.Find("MasuHandler").GetComponent<MasuHandler>();
    }

    public void DirectionDetermine(bool Naru, int Shu)
    {
        if (Naru == false && Shu == 0 && PhotonNetwork.player.ID == 1)//金の場合
        {
            if (masuHandler.masuNum == 26 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 16; i < 26; i++)
                {
                    Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else if (masuHandler.masuNum < 6)//上段の場合
            {
                if (masuHandler.masuNum % 5 == 2 || masuHandler.masuNum % 5 == 3 || masuHandler.masuNum % 5 == 4)//真ん中にいるとき
                {
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                }
                else if (masuHandler.masuNum % 5 == 1) //左端にいるとき
                {
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                }
                else if (masuHandler.masuNum % 5 == 0 && masuHandler.masuNum != 0) //右端にいるとき
                {
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else if (masuHandler.masuNum > 20)//下段の場合
            {
                if (masuHandler.masuNum % 5 == 2 || masuHandler.masuNum % 5 == 3 || masuHandler.masuNum % 5 == 4)//真ん中にいるとき
                {
                    Masu[masuHandler.masuNum - 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                }
                else if (masuHandler.masuNum % 5 == 1) //左端にいるとき
                {
                    Masu[masuHandler.masuNum - 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;

                }
                else if (masuHandler.masuNum % 5 == 0 && masuHandler.masuNum != 0) //右端にいるとき
                {
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;

                }
            }
            else//中段の場合
            {
                if (masuHandler.masuNum % 5 == 2 || masuHandler.masuNum % 5 == 3 || masuHandler.masuNum % 5 == 4)//真ん中にいるとき
                {

                    Masu[masuHandler.masuNum - 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;

                }
                else if (masuHandler.masuNum % 5 == 1)//左端にいるとき
                {
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;

                }
                else if (masuHandler.masuNum % 5 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    Masu[masuHandler.masuNum - 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                }
            }

        }else if (Naru == false && Shu == 0 && PhotonNetwork.player.ID != 1)//金の場合
        {
            if (masuHandler.masuNum == 26 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i < 11; i++)
                {
                    Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else if (masuHandler.masuNum < 6)//上段の場合
            {
                if (masuHandler.masuNum % 5 == 2 || masuHandler.masuNum % 5 == 3 || masuHandler.masuNum % 5 == 4)//真ん中にいるとき
                {
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<MeshRenderer>().enabled = false;
                }
                else if (masuHandler.masuNum % 5 == 1) //左端にいるとき
                {
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<MeshRenderer>().enabled = false;
                }
                else if (masuHandler.masuNum % 5 == 0 && masuHandler.masuNum != 0) //右端にいるとき
                {
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else if (masuHandler.masuNum > 20)//下段の場合
            {
                if (masuHandler.masuNum % 5 == 2 || masuHandler.masuNum % 5 == 3 || masuHandler.masuNum % 5 == 4)//真ん中にいるとき
                {
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                }
                else if (masuHandler.masuNum % 5 == 1) //左端にいるとき
                {
                   
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;

                }
                else if (masuHandler.masuNum % 5 == 0 && masuHandler.masuNum != 0) //右端にいるとき
                {
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;                
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;

                }
            }
            else//中段の場合
            {
                if (masuHandler.masuNum % 5 == 2 || masuHandler.masuNum % 5 == 3 || masuHandler.masuNum % 5 == 4)//真ん中にいるとき
                {

                  
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<MeshRenderer>().enabled = false;

                }
                else if (masuHandler.masuNum % 5 == 1)//左端にいるとき
                {
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;               
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<MeshRenderer>().enabled = false;

                }
                else if (masuHandler.masuNum % 5 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<MeshRenderer>().enabled = false;
                }
            }

        }
        else if (Naru == false && Shu == 1 && PhotonNetwork.player.ID == 1 )//桂馬の場合
        {
            if (masuHandler.masuNum == 26 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 16; i < 26; i++)
                {
                    Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else if (masuHandler.masuNum == 12 || masuHandler.masuNum == 13 || masuHandler.masuNum == 14 ||
               masuHandler.masuNum == 17 || masuHandler.masuNum == 18 || masuHandler.masuNum == 19 ||
               masuHandler.masuNum == 22 || masuHandler.masuNum == 23 || masuHandler.masuNum == 24)
            {
                Masu[masuHandler.masuNum - 11].GetComponent<BoxCollider2D>().enabled = false;
                Masu[masuHandler.masuNum - 11].GetComponent<MeshRenderer>().enabled = false;
                Masu[masuHandler.masuNum - 9].GetComponent<BoxCollider2D>().enabled = false;
                Masu[masuHandler.masuNum - 9].GetComponent<MeshRenderer>().enabled = false;
            }
            else if (masuHandler.masuNum == 11 || masuHandler.masuNum == 16 || masuHandler.masuNum == 21)
            {
                Masu[masuHandler.masuNum - 9].GetComponent<BoxCollider2D>().enabled = false;
                Masu[masuHandler.masuNum - 9].GetComponent<MeshRenderer>().enabled = false;
            }
            else if (masuHandler.masuNum == 15 || masuHandler.masuNum == 20 || masuHandler.masuNum == 25)
            {
                Masu[masuHandler.masuNum - 11].GetComponent<BoxCollider2D>().enabled = false;
                Masu[masuHandler.masuNum - 11].GetComponent<MeshRenderer>().enabled = false;
            }

        }
        else if (Naru == false && Shu == 1 && PhotonNetwork.player.ID != 1)//桂馬の場合
        {
            if (masuHandler.masuNum == 26 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i < 11; i++)
                {
                    Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else if (masuHandler.masuNum == 12 || masuHandler.masuNum == 13 || masuHandler.masuNum == 14 ||
               masuHandler.masuNum == 7 || masuHandler.masuNum == 8 || masuHandler.masuNum == 9 ||
               masuHandler.masuNum == 2 || masuHandler.masuNum == 3 || masuHandler.masuNum == 4)
            {
                Masu[masuHandler.masuNum + 11].GetComponent<BoxCollider2D>().enabled = false;
                Masu[masuHandler.masuNum + 11].GetComponent<MeshRenderer>().enabled = false;
                Masu[masuHandler.masuNum + 9].GetComponent<BoxCollider2D>().enabled = false;
                Masu[masuHandler.masuNum + 9].GetComponent<MeshRenderer>().enabled = false;
            }
            else if (masuHandler.masuNum == 11 || masuHandler.masuNum == 1 || masuHandler.masuNum == 6)
            {
                Masu[masuHandler.masuNum + 11].GetComponent<BoxCollider2D>().enabled = false;
                Masu[masuHandler.masuNum + 11].GetComponent<MeshRenderer>().enabled = false;
            }
            else if (masuHandler.masuNum == 15 || masuHandler.masuNum == 10 || masuHandler.masuNum == 5)
            {
                Masu[masuHandler.masuNum + 9].GetComponent<BoxCollider2D>().enabled = false;
                Masu[masuHandler.masuNum + 9].GetComponent<MeshRenderer>().enabled = false;
            }

        }
        else if (Naru == false && Shu == 2 && PhotonNetwork.player.ID == 1)//飛車の場合
        {
            if (masuHandler.masuNum == 26 || masuHandler.masuNum == 0 )
            {
                int i;
                for (i = 16; i < 26; i++)
                {
                    Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else
            {
                int i;
                for (i = 1; i < 26; i++)
                {
                    if (masuHandler.masuNum % 5 == 0)
                    {
                        if (masuHandler.masuNum / 5 == (i + 5) / 5 || masuHandler.masuNum % 5 == i % 5)
                        {
                            Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                            Masu[i].GetComponent<MeshRenderer>().enabled = false;
                        }
                    }
                    else
                    {
                        if (masuHandler.masuNum / 5 == (i - 1) / 5 || masuHandler.masuNum % 5 == i % 5)
                        {
                            Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                            Masu[i].GetComponent<MeshRenderer>().enabled = false;
                        }
                    }
                }
            }

        }
        else if (Naru == false && Shu == 2 && PhotonNetwork.player.ID != 1)//飛車の場合
        {
            if (masuHandler.masuNum == 26 || masuHandler.masuNum == 0 )
            {
                int i;
                for (i = 1; i < 11; i++)
                {
                    Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else
            {
                int i;
                for (i = 1; i < 26; i++)
                {
                    if (masuHandler.masuNum % 5 == 0)
                    {
                        if (masuHandler.masuNum / 5 == (i + 5) / 5 || masuHandler.masuNum % 5 == i % 5)
                        {
                            Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                            Masu[i].GetComponent<MeshRenderer>().enabled = false;
                        }
                    }
                    else
                    {
                        if (masuHandler.masuNum / 5 == (i - 1) / 5 || masuHandler.masuNum % 5 == i % 5)
                        {
                            Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                            Masu[i].GetComponent<MeshRenderer>().enabled = false;
                        }
                    }
                }
            }

        }
        else if (Naru == false && Shu == 3 && PhotonNetwork.player.ID == 1)//角の場合　犬
        {
            if (masuHandler.masuNum == 26 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 16; i < 26; i++)
                {
                    Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else
            {
                int i;
                for (i = 1; i < 26; i++)
                {
                    int k;
                    int tokuiten1;
                    int tokuiten2;
                    if (masuHandler.masuNum % 6 == i % 6 || masuHandler.masuNum % 4 == i % 4)
                    {
                        Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                        Masu[i].GetComponent<MeshRenderer>().enabled = false;



                        if (masuHandler.masuNum < 10 || masuHandler.masuNum == 11 || masuHandler.masuNum == 12 || masuHandler.masuNum == 16)
                        {
                            for (k = 0; k < 6; k++)
                            {
                                if (((masuHandler.masuNum + 4 * k) - 1) / 5 == ((masuHandler.masuNum + 4 * (k + 1) - 1) / 5))
                                {
                                    break;
                                }
                            }
                            tokuiten2 = masuHandler.masuNum + (4 * (k + 1));
                            Debug.Log(tokuiten2 + "tokuiten2");

                            int j;
                            for (j = 0; j < 6; j++)
                            {
                                if (tokuiten2 + 4 * j > 0 && tokuiten2 + 4 * j < 26)
                                {
                                    if (tokuiten2 + 4 * j == masuHandler.masuNum + 12 || tokuiten2 + 4 * j == masuHandler.masuNum + 24)
                                    {

                                    }
                                    else
                                    {
                                        Masu[tokuiten2 + 4 * j].GetComponent<BoxCollider2D>().enabled = true;
                                        Masu[tokuiten2 + 4 * j].GetComponent<MeshRenderer>().enabled = true;
                                    }


                                }
                            }

                        }
                        else
                        {
                            for (k = 0; k < 6; k++)
                            {
                                if (((masuHandler.masuNum - 4 * k) - 1) / 5 == ((masuHandler.masuNum - 4 * (k + 1) - 1) / 5))
                                {
                                    break;
                                }
                            }
                            tokuiten1 = masuHandler.masuNum - (4 * (k + 1));

                            Debug.Log(tokuiten1 + "tokuiten1");

                            int j;
                            for (j = 0; j < masuHandler.masuNum / 4; j++)
                            {
                                if (tokuiten1 - 4 * j > 0 && tokuiten1 - 4 * j < 26)
                                {
                                    if (tokuiten1 - 4 * j == masuHandler.masuNum - 12 || tokuiten1 - 4 * j == masuHandler.masuNum - 24)
                                    {

                                    }
                                    else
                                    {
                                        Masu[tokuiten1 - 4 * j].GetComponent<BoxCollider2D>().enabled = true;
                                        Masu[tokuiten1 - 4 * j].GetComponent<MeshRenderer>().enabled = true;

                                    }

                                }
                            }


                        }

                        if (masuHandler.masuNum == 3)
                        {
                            Masu[21].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[21].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 4)
                        {
                            Masu[22].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[22].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 5)
                        {
                            Masu[1].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[1].GetComponent<MeshRenderer>().enabled = true;
                            Masu[11].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[11].GetComponent<MeshRenderer>().enabled = true;
                            Masu[23].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[23].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 9)
                        {
                            Masu[1].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[1].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 10)
                        {
                            Masu[16].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[16].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 11)
                        {
                            Masu[5].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[5].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 15)
                        {
                            Masu[21].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[21].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 16)
                        {
                            Masu[10].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[10].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 17)
                        {
                            Masu[25].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[25].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 21)
                        {
                            Masu[3].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[3].GetComponent<MeshRenderer>().enabled = true;
                            Masu[15].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[15].GetComponent<MeshRenderer>().enabled = true;
                            Masu[25].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[25].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 22)
                        {
                            Masu[4].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[4].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 23)
                        {
                            Masu[5].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[5].GetComponent<MeshRenderer>().enabled = true;
                        }
                    }

                }

            }
        }
        else if (Naru == false && Shu == 3 && PhotonNetwork.player.ID != 1)//角の場合 猫
        {
            if (masuHandler.masuNum == 26 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i < 11; i++)
                {
                    Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else
            {
                int i;
                for (i = 1; i < 26; i++)
                {
                    int k;
                    int tokuiten1;
                    int tokuiten2;
                    if (masuHandler.masuNum % 6 == i % 6 || masuHandler.masuNum % 4 == i % 4)
                    {
                        Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                        Masu[i].GetComponent<MeshRenderer>().enabled = false;



                        if (masuHandler.masuNum < 10 || masuHandler.masuNum == 11 || masuHandler.masuNum == 12 || masuHandler.masuNum == 16)
                        {
                            for (k = 0; k < 6; k++)
                            {
                                if (((masuHandler.masuNum + 4 * k) - 1) / 5 == ((masuHandler.masuNum + 4 * (k + 1) - 1) / 5))
                                {
                                    break;
                                }
                            }
                            tokuiten2 = masuHandler.masuNum + (4 * (k + 1));
                            Debug.Log(tokuiten2 + "tokuiten2");

                            int j;
                            for (j = 0; j < 6; j++)
                            {
                                if (tokuiten2 + 4 * j > 0 && tokuiten2 + 4 * j < 26)
                                {
                                    if (tokuiten2 + 4 * j == masuHandler.masuNum + 12 || tokuiten2 + 4 * j == masuHandler.masuNum + 24)
                                    {

                                    }
                                    else
                                    {
                                        Masu[tokuiten2 + 4 * j].GetComponent<BoxCollider2D>().enabled = true;
                                        Masu[tokuiten2 + 4 * j].GetComponent<MeshRenderer>().enabled = true;
                                    }


                                }
                            }

                        }
                        else
                        {
                            for (k = 0; k < 6; k++)
                            {
                                if (((masuHandler.masuNum - 4 * k) - 1) / 5 == ((masuHandler.masuNum - 4 * (k + 1) - 1) / 5))
                                {
                                    break;
                                }
                            }
                            tokuiten1 = masuHandler.masuNum - (4 * (k + 1));

                            Debug.Log(tokuiten1 + "tokuiten1");

                            int j;
                            for (j = 0; j < masuHandler.masuNum / 4; j++)
                            {
                                if (tokuiten1 - 4 * j > 0 && tokuiten1 - 4 * j < 26)
                                {
                                    if (tokuiten1 - 4 * j == masuHandler.masuNum - 12 || tokuiten1 - 4 * j == masuHandler.masuNum - 24)
                                    {

                                    }
                                    else
                                    {
                                        Masu[tokuiten1 - 4 * j].GetComponent<BoxCollider2D>().enabled = true;
                                        Masu[tokuiten1 - 4 * j].GetComponent<MeshRenderer>().enabled = true;

                                    }

                                }
                            }


                        }

                        if (masuHandler.masuNum == 3)
                        {
                            Masu[21].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[21].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 4)
                        {
                            Masu[22].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[22].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 5)
                        {
                            Masu[1].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[1].GetComponent<MeshRenderer>().enabled = true;
                            Masu[11].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[11].GetComponent<MeshRenderer>().enabled = true;
                            Masu[23].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[23].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 9)
                        {
                            Masu[1].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[1].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 10)
                        {
                            Masu[16].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[16].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 11)
                        {
                            Masu[5].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[5].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 15)
                        {
                            Masu[21].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[21].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 16)
                        {
                            Masu[10].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[10].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 17)
                        {
                            Masu[25].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[25].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 21)
                        {
                            Masu[3].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[3].GetComponent<MeshRenderer>().enabled = true;
                            Masu[15].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[15].GetComponent<MeshRenderer>().enabled = true;
                            Masu[25].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[25].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 22)
                        {
                            Masu[4].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[4].GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (masuHandler.masuNum == 23)
                        {
                            Masu[5].GetComponent<BoxCollider2D>().enabled = true;
                            Masu[5].GetComponent<MeshRenderer>().enabled = true;
                        }
                    }

                }

            }
        }
        else if (Naru == false && Shu == 4 && PhotonNetwork.player.ID == 1)//玉の場合 inu
        {
            if (masuHandler.masuNum == 26 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 16; i < 26; i++)
                {
                    Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else if (masuHandler.masuNum < 6)//上段の場合
            {
                if (masuHandler.masuNum % 5 == 2 || masuHandler.masuNum % 5 == 3 || masuHandler.masuNum % 5 == 4)//真ん中にいるとき
                {
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<MeshRenderer>().enabled = false;
                }
                else if (masuHandler.masuNum % 5 == 1) //左端にいるとき
                {
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<MeshRenderer>().enabled = false;
                }
                else if (masuHandler.masuNum % 5 == 0 && masuHandler.masuNum != 0) //右端にいるとき
                {
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else if (masuHandler.masuNum > 20)//下段の場合
            {
                if (masuHandler.masuNum % 5 == 2 || masuHandler.masuNum % 5 == 3 || masuHandler.masuNum % 5 == 4)//真ん中にいるとき
                {
                    Masu[masuHandler.masuNum - 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                }
                else if (masuHandler.masuNum % 5 == 1) //左端にいるとき
                {
                    Masu[masuHandler.masuNum - 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;

                }
                else if (masuHandler.masuNum % 5 == 0 && masuHandler.masuNum != 0) //右端にいるとき
                {
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;

                }
            }
            else//中段の場合
            {
                if (masuHandler.masuNum % 5 == 2 || masuHandler.masuNum % 5 == 3 || masuHandler.masuNum % 5 == 4)//真ん中にいるとき
                {

                    Masu[masuHandler.masuNum - 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<MeshRenderer>().enabled = false;

                }
                else if (masuHandler.masuNum % 5 == 1)//左端にいるとき
                {
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;

                }
                else if (masuHandler.masuNum % 5 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    Masu[masuHandler.masuNum - 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                }
            }

        }
        else if (Naru == false && Shu == 4 && PhotonNetwork.player.ID != 1)//玉の場合 neko 
        {
            if (masuHandler.masuNum == 26 || masuHandler.masuNum == 0)
            {
                int i;
                for (i = 1; i < 11; i++)
                {
                    Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else if (masuHandler.masuNum < 6)//上段の場合
            {
                if (masuHandler.masuNum % 5 == 2 || masuHandler.masuNum % 5 == 3 || masuHandler.masuNum % 5 == 4)//真ん中にいるとき
                {
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<MeshRenderer>().enabled = false;
                }
                else if (masuHandler.masuNum % 5 == 1) //左端にいるとき
                {
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<MeshRenderer>().enabled = false;
                }
                else if (masuHandler.masuNum % 5 == 0 && masuHandler.masuNum != 0) //右端にいるとき
                {
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else if (masuHandler.masuNum > 20)//下段の場合
            {
                if (masuHandler.masuNum % 5 == 2 || masuHandler.masuNum % 5 == 3 || masuHandler.masuNum % 5 == 4)//真ん中にいるとき
                {
                    Masu[masuHandler.masuNum - 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                }
                else if (masuHandler.masuNum % 5 == 1) //左端にいるとき
                {
                    Masu[masuHandler.masuNum - 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;

                }
                else if (masuHandler.masuNum % 5 == 0 && masuHandler.masuNum != 0) //右端にいるとき
                {
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;

                }
            }
            else//中段の場合
            {
                if (masuHandler.masuNum % 5 == 2 || masuHandler.masuNum % 5 == 3 || masuHandler.masuNum % 5 == 4)//真ん中にいるとき
                {

                    Masu[masuHandler.masuNum - 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<MeshRenderer>().enabled = false;

                }
                else if (masuHandler.masuNum % 5 == 1)//左端にいるとき
                {
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 6].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;

                }
                else if (masuHandler.masuNum % 5 == 0 && masuHandler.masuNum != 0)//右端にいるとき
                {
                    Masu[masuHandler.masuNum - 6].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 6].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 5].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum - 1].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 4].GetComponent<MeshRenderer>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<BoxCollider2D>().enabled = false;
                    Masu[masuHandler.masuNum + 5].GetComponent<MeshRenderer>().enabled = false;
                }
            }

        }
    }

    public void ResetAll(int a)
    {
        int i;
        for (i = 0; i < 26; i++)
        {
            if(i != a)
            {
                Masu[i].GetComponent<BoxCollider2D>().enabled = true;
                Masu[i].GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                Masu[i].GetComponent<MeshRenderer>().enabled = false;
            }
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
