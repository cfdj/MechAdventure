using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public bool Active;
    public PlayerController player;
    private Animator animationController;
    public enum Facing
    {
        North,South,East,West
    };
    public Facing currentFacing = Facing.South;
    public List<GameObject> DisembarkPoint;
    public GameObject Lights;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animationController = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Active)
        {
            SetAnimationBools();
            //Currently Use a Player can only move in 1 direction approach with Facing
            if(Input.GetAxis("Horizontal") < 0)
            {
                currentFacing = Facing.West;
                rb.velocity = Vector2.left * speed;
                animationController.SetBool("West",true);
                animationController.speed = 1;
                SetLights();
            }
            else if(Input.GetAxis("Horizontal") > 0)
            {
                currentFacing = Facing.East;
                rb.velocity = Vector2.right * speed;
                animationController.SetBool("East",true);
                animationController.speed = 1;
                SetLights();
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                currentFacing = Facing.North;
                rb.velocity = Vector2.up * speed;
                animationController.SetBool("North",true);
                animationController.speed = 1;
                SetLights();
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                currentFacing = Facing.South;
                rb.velocity = Vector2.down * speed;
                animationController.SetBool("South",true);
                animationController.speed = 1;
                SetLights();
            }
            else
            {
                rb.velocity = Vector2.zero;
                animationController.speed = 0;
            }

            if (Input.GetButton("Jump"))
            {
                player.gameObject.SetActive(true);
                player.transform.position = DisembarkPoint[((int)currentFacing)].transform.position;
                player.Active = true;
                Active = false;
                SetAnimationBools();
                rb.velocity = Vector2.zero;
                //animationController.SetBool("Idle",true);
                animationController.speed = 0;
            }

        }
    }
    void SetAnimationBools()
    {
        animationController.SetBool("Idle", false);
        animationController.SetBool("North", false);
        animationController.SetBool("South", false);
        animationController.SetBool("East", false);
        animationController.SetBool("West", false);

    }
    void SetLights()
    {
        switch(currentFacing){
            case Facing.North:
                Lights.transform.rotation = new Quaternion(0, 0, 0, 0);
                break;
            case Facing.South:
                Lights.transform.rotation = new Quaternion(0, 0, 180, 0);
                break;
            case Facing.East:
                Lights.transform.rotation = Quaternion.Euler(0, 0, 270);
                Debug.Log("Lights East");
                break;
            case Facing.West:
                Lights.transform.rotation = Quaternion.Euler(0, 0, 90);
                Debug.Log("Lights West");
                break;
        }
    }
}
