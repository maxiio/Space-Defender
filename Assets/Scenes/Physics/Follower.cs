using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    public EndOfPathInstruction endOfPathInstruction;
    float distanceTravelled;
    private Rigidbody2D rb;


    public bool continueFollowing = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (continueFollowing)
        {
            distanceTravelled += speed* Time.deltaTime;
            rb.velocity = pathCreator.path.GetDirectionAtDistance(distanceTravelled, endOfPathInstruction)*speed;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            Debug.DrawRay(transform.position, pathCreator.path.GetDirectionAtDistance(distanceTravelled, endOfPathInstruction),Color.red);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        continueFollowing = false;
    }
}
