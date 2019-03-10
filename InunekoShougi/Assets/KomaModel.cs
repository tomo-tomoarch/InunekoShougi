using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomaModel : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // SpriteRendererクラスを参照します。①（Cardmodelクラスが直接アタッチされているオブジェクトのクラスを参照void awakeの所とセット）

    public Sprite[] faces;　　// 外部から参照できる（インスペクターからいじれる）facesという表面のリストの宣言。
    public Sprite komaBack;
    public Sprite[] komaNaru;// 外部から参照できる（インスペクターからいじれる）cardBackという裏面の宣言。

    public int cardIndex;　// 外部から参照できるcardIndex という値の宣言。
    public int komaBackIndex;

    public void ToggleFace(int showFace)　//外部アクセス可能なToggleFaceというメソッドの定義　引数に真偽値としてshowFaceを取る。
    {

        if (showFace == 0)　// もし showface がtrueであれば、
        {
            spriteRenderer.sprite = faces[cardIndex];  //②で取得したspriteにfaces[与えられたインデックス値]をレンダーさせる。
        }
        else
        {
            if (showFace == 2)
            {
                spriteRenderer.sprite = komaNaru[komaBackIndex];
            }
            else
            {
                spriteRenderer.sprite = komaBack;　　//②で取得したspriteにcardbackをレンダーさせる。
            }

        }
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //このスクリプトがアタッチされているオブジェクトのインスペクター上のspriteRendererを取得します。①とセット。②
    }
}