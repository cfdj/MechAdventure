using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldSwitch : Switch
{

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if (Big && collision.gameObject == mech.gameObject)
        {
            door.Open();
            gameObject.GetComponent<SpriteRenderer>().sprite = pressed;
        }

        if (!Big && collision.gameObject == player.gameObject)
        {
            door.Open();
            gameObject.GetComponent<SpriteRenderer>().sprite = pressed;
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (Big && collision.gameObject == mech.gameObject)
        {
            door.Close();
            gameObject.GetComponent<SpriteRenderer>().sprite = notPressed;
        }

        if (!Big && collision.gameObject == player.gameObject)
        {
            door.Close();
            gameObject.GetComponent<SpriteRenderer>().sprite = notPressed;
        }
    }
}
