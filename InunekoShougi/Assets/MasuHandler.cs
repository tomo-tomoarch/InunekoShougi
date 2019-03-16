using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasuHandler : MonoBehaviour
{
    DirectionDeterminator directionDeterminator;
    public int masuNum;
    public int komaShu;
    public bool komaNaru;
    public int komanarifield;

    public void MasuCordinator(float x, float y,int cardIndex,bool Naru,int field)
    {
        if (-1.5f > x && x > -2.5f)
        {
            if (1.5f < y && y < 2.5f)
            {
                masuNum = 1;
                Debug.Log(masuNum);
            }
            else if (0.5f < y && y < 1.5f)
            {
                masuNum = 6;
                Debug.Log(masuNum);
            }
            else if (-0.5f < y && y < 0.5f)
            {
                masuNum = 11;
                Debug.Log(masuNum);
            }
            else if (-1.5f < y && y < -0.5f)
            {
                masuNum = 16;
                Debug.Log(masuNum);
            }
            else if (-2.5f < y && y < -1.5f)
            {
                masuNum = 21;
                Debug.Log(masuNum);
            }
            else
            {
                masuNum = 26;
            }
        }
        else if (-0.5f > x && x > -1.5f)
        {
            if (1.5f < y && y < 2.5f)
            {
                masuNum = 2;
                Debug.Log(masuNum);
            }
            else if (0.5f < y && y < 1.5f)
            {
                masuNum = 7;
                Debug.Log(masuNum);
            }
            else if (-0.5f < y && y < 0.5f)
            {
                masuNum = 12;
                Debug.Log(masuNum);
            }
            else if (-1.5f < y && y < -0.5f)
            {
                masuNum = 17;
                Debug.Log(masuNum);
            }
            else if (-2.5f < y && y < -1.5f)
            {
                masuNum = 22;
                Debug.Log(masuNum);
            }
            else
            {
                masuNum = 26;
            }
        }
        else if (0.5f > x && x > -0.5f)
        {
            if (1.5f < y && y < 2.5f)
            {
                masuNum = 3;
                Debug.Log(masuNum);
            }
            else if (0.5f < y && y < 1.5f)
            {
                masuNum = 8;
                Debug.Log(masuNum);
            }
            else if (-0.5f < y && y < 0.5f)
            {
                masuNum = 13;
                Debug.Log(masuNum);
            }
            else if (-1.5f < y && y < -0.5f)
            {
                masuNum = 18;
                Debug.Log(masuNum);
            }
            else if (-2.5f < y && y < -1.5f)
            {
                masuNum = 23;
                Debug.Log(masuNum);
            }
            else
            {
                masuNum = 26;
            }
        }
        else if (1.5f > x && x > 0.5f)
        {
            if (1.5f < y && y < 2.5f)
            {
                masuNum = 4;
                Debug.Log(masuNum);
            }
            else if (0.5f < y && y < 1.5f)
            {
                masuNum = 9;
                Debug.Log(masuNum);
            }
            else if (-0.5f < y && y < 0.5f)
            {
                masuNum = 14;
                Debug.Log(masuNum);
            }
            else if (-1.5f < y && y < -0.5f)
            {
                masuNum = 19;
                Debug.Log(masuNum);
            }
            else if (-2.5f < y && y < -1.5f)
            {
                masuNum = 24;
                Debug.Log(masuNum);
            }
            else
            {
                masuNum = 26; 
            }
        }
        else if (2.5f > x && x > 1.5f)
        {
            if (1.5f < y && y < 2.5f)
            {
                masuNum = 5;
                Debug.Log(masuNum);
            }
            else if (0.5f < y && y < 1.5f)
            {
                masuNum = 10;
                Debug.Log(masuNum);
            }
            else if (-0.5f < y && y < 0.5f)
            {
                masuNum = 15;
                Debug.Log(masuNum);
            }
            else if (-1.5f < y && y < -0.5f)
            {
                masuNum = 20;
                Debug.Log(masuNum);
            }
            else if (-2.5f < y && y < -1.5f)
            {
                masuNum = 25;
                Debug.Log(masuNum);
            }
            else
            {
                masuNum = 26;
            }
        }
        else
        {
            masuNum = 26;
        }

        komaShu = cardIndex;
        komaNaru = Naru;
        komanarifield =field;

    directionDeterminator.DirectionDetermine(komaNaru, komaShu,komanarifield);
    }

    // Start is called before the first frame update
    void Start()
    {
       directionDeterminator = GameObject.Find("DirectionDeterminator").GetComponent<DirectionDeterminator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
