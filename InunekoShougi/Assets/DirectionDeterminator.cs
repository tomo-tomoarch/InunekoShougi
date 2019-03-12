using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDeterminator : MonoBehaviour
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
        if (Naru == false && Shu == 0)//金の場合
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

        }
        else if (Naru == false && Shu == 2)//飛車の場合
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
                    if(masuHandler.masuNum % 5 == 0)
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
        
        }else if(Naru == false && Shu == 3)//角の場合
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
                        if (masuHandler.masuNum > 13 && masuHandler.masuNum !=26)
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
                                    Masu[tokuiten1 - 4 * j].GetComponent<BoxCollider2D>().enabled = true;
                                    Masu[tokuiten1 - 4 * j].GetComponent<MeshRenderer>().enabled = true;
                                }
                            }
                        }
                        else if (masuHandler.masuNum < 14)
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
                            for (j = 0; j < 5; j++)
                            {
                                if ((tokuiten2 + 4 * j) > 0 && (tokuiten2 + 4 * j) < 26)
                                {
                                    Masu[tokuiten2 + 4 * j].GetComponent<BoxCollider2D>().enabled = true;
                                    Masu[tokuiten2 + 4 * j].GetComponent<MeshRenderer>().enabled = true;
                                }
                            }
                        }


                        Masu[i].GetComponent<BoxCollider2D>().enabled = false;
                        Masu[i].GetComponent<MeshRenderer>().enabled = false;
                    }

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
