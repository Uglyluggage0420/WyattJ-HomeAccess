using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    public SpriteRenderer spriteRend;

    private void Start()
    {
        
    }
    void UpdateAlpha(float alpha)
    {
        spriteRend.color = new Color(1f, 1f, 1f, alpha);
        alpha -= 0.05f;
    }
}
