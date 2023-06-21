using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Door door;
    public MechController mech;
    public PlayerController player;
    public bool Big;
    public bool hold;

    public Sprite pressed;
    public Sprite notPressed;

    private int numPressing = 0;

    private void Start()
    {
        notPressed = gameObject.GetComponent<SpriteRenderer>().sprite;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

       if(Big && collision.gameObject == mech.gameObject)
            {
                door.Open();
                gameObject.GetComponent<SpriteRenderer>().sprite = pressed;
            }
        
       if(!Big)
            {
            numPressing += 1;
            door.Open();
            gameObject.GetComponent<SpriteRenderer>().sprite = pressed;
       }
        
    }
    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (!Big)
        {
            numPressing -= 1;
            if (numPressing == 0 && hold)
            {
                door.Close();
                gameObject.GetComponent<SpriteRenderer>().sprite = notPressed;
            }
        }
    }
}
