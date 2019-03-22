using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatatabiModel : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Sprite matatabi;
    public Sprite hone;
    public int cardIndex;

    public void ToggleFace(bool showFace)　
    {

        if (showFace)　// もし showface がtrueであれば、
        {
            spriteRenderer.sprite = matatabi;
        }
        else
        {
            spriteRenderer.sprite = hone;
        }

    }
        void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
