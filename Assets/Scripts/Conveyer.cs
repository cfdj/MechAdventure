using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyer : MonoBehaviour
{
    public Vector2 ConveyerSpeed;
    public int maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() == null){
            collision.attachedRigidbody.AddForce(ConveyerSpeed*2);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("On Conveyer");
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<PlayerController>().speedInfluences(ConveyerSpeed);
        }

    }
}
