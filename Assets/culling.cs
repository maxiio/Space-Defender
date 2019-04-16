using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class culling : MonoBehaviour
{
    bool wasSeen;
    private void OnBecameInvisible()
    {

           // GetComponent<SpriteRenderer>().color = Color.red;


        if (wasSeen == true && GetComponent<Follower>() == null)
        {
            Destroy(gameObject);
        }
        else if(wasSeen == true && GetComponent<Follower>().endOfPathInstruction != PathCreation.EndOfPathInstruction.Loop)
        {
            Destroy(gameObject);
        }

    }
    private void OnBecameVisible()
    {

            //GetComponent<SpriteRenderer>().color = Color.green;

        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        wasSeen = true;

    }
}
