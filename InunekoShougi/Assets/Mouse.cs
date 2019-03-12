using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    MasuHandler masuHandler;
    KomaModel komaModel;
    DirectionDeterminator directionDeterminator;

    Collider2D m_ObjectCollider;

    public float xzahyou;
    public float yzahyou;
    public int KomaShu;
    public int KomaNaru;
    public int YukoGoma;

    //マウスでドラッグするスクリプト

    private Vector3 screenPoint;
    private Vector3 offset;

    private void Start()
    {
        directionDeterminator = GameObject.Find("DirectionDeterminator").GetComponent<DirectionDeterminator>();
        masuHandler = GameObject.Find("MasuHandler").GetComponent<MasuHandler>();
        komaModel = GetComponent<KomaModel>();
    }

    void OnMouseDown()
    {
            this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        xzahyou = transform.position.x;
        yzahyou = transform.position.y;
        KomaShu = komaModel.cardIndex;
        KomaNaru = komaModel.komaBackIndex;

        if (komaModel.naru)
        {
            YukoGoma = KomaNaru;
        }
        else
        {
            YukoGoma = KomaShu;
        }
       
        masuHandler.MasuCordinator(xzahyou, yzahyou,YukoGoma,komaModel.naru);

       
        m_ObjectCollider = GetComponent<BoxCollider2D>();
        m_ObjectCollider.isTrigger = false;

        Debug.Log("mousedown");

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

        if (komaModel.naru)
        {
            YukoGoma = KomaNaru;
        }
        else
        {
            YukoGoma = KomaShu;
        }

        masuHandler.MasuCordinator(xzahyou, yzahyou, YukoGoma, komaModel.naru);

        m_ObjectCollider = GetComponent<BoxCollider2D>();
        m_ObjectCollider.isTrigger = true;

        directionDeterminator.ResetAll(masuHandler.masuNum);
    }
}
