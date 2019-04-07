using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCenter : MonoBehaviour
{
    public List<GameObject> encouterObjects;

    public float objectMass;

    private void Update()
    {
        foreach(GameObject item in encouterObjects)
        {
            Vector3 difference = this.transform.position - item.transform.position;

            float dist = difference.magnitude;
            Vector3 gravityDirection = difference.normalized;
            float gravity = 6.7f * (item.transform.localScale.x * objectMass) / (dist * dist);

            Vector3 gravityVector = (gravityDirection * gravity);
            item.transform.GetComponent<Rigidbody2D>().AddForce(gravityVector, ForceMode2D.Force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Asteroid")
        {
            encouterObjects.Add(collision.gameObject);
            collision.gameObject.GetComponent<Follower>().continueFollowing = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Asteroid")
        {
            encouterObjects.Remove(collision.gameObject);
        }
    }
}
