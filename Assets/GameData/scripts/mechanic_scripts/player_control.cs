using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax;
}

public class player_control : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundary;
    private float posY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posY = this.gameObject.transform.position.y;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");


        Vector3 movement = new Vector3(moveHorizontal, posY, rb.position.z);
        rb.velocity = movement * speed;

        rb.position = new Vector2
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                posY
            );
    }
}
