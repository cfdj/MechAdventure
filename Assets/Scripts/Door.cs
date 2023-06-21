using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    public Sprite open;
    public Sprite closed;
    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        col = this.GetComponent<Collider2D>();
        isOpen = false;
    }

    public void Open()
    {
        spriteRenderer.sprite = open;
        col.enabled = false;
        isOpen = true;
    }
    public void Close()
    {
        spriteRenderer.sprite = closed;
        col.enabled = true;
        isOpen = false;
    }
}
