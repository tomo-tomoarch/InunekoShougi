using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    MasuHandler masuHandler;
    public float xzahyou;
    public float yzahyou;

    //マウスでドラッグするスクリプト

    private Vector3 screenPoint;
    private Vector3 offset;

    private void Start()
    {
        masuHandler = GameObject.Find("MasuHandler").GetComponent<MasuHandler>();
    }

    void OnMouseDown()
    {
            this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        xzahyou = transform.position.x;
        yzahyou = transform.position.y;

        masuHandler.MasuCordinator(xzahyou, yzahyou);


    }

    void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }
}
