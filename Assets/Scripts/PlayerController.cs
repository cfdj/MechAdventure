using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public bool Active;
    public MechController mech;

    public Camera mainCamera;

    private Vector2 additionalSpeed = new Vector2(0,0);
    // Start is called before the first frame update
    void OnEnable()
    {
        mainCamera.gameObject.transform.parent = gameObject.transform;
        mainCamera.gameObject.transform.localPosition = new Vector3(0, 0, -1);
    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Active)
        {
            rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), speed * Input.GetAxis("Vertical"))+additionalSpeed;
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);
            additionalSpeed = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision" + collision.collider.name);
        if(collision.collider.gameObject == mech.gameObject)
        {
            Active = false;
            mech.Active = true;
            mainCamera.gameObject.transform.parent = mech.gameObject.transform;
            mainCamera.gameObject.transform.localPosition = new Vector3(0, 0,-1);
            gameObject.SetActive(false);

        }
    }
    public void speedInfluences(Vector2 speedInfluence)
    {
        additionalSpeed = speedInfluence;
    }
}
