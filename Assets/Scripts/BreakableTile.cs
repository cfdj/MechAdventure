using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableTile : MonoBehaviour
{
    public MechController mech;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == mech.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
