using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class culling : MonoBehaviour
{
    bool wasSeen;
    private void OnBecameInvisible()
    {
        if (wasSeen == true && GetComponent<Follower>() == null)
        {
            Destroy(gameObject);
        }
        else if(wasSeen == true && GetComponent<Follower>().endOfPathInstruction == PathCreation.EndOfPathInstruction.Stop)
        {
            Destroy(gameObject);
        }

    }
    private void OnBecameVisible()
    {

        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        wasSeen = true;

    }
}
