using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_preferences : MonoBehaviour
{
    //public Transform startPos;
    public GameObject localObstaclesGroup;
    private void Start()
    {
        //startPos = transform.position;
        localObstaclesGroup = transform.GetChild(1).gameObject;
        localObstaclesGroup.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            localObstaclesGroup.SetActive(true);
        }
    }
}
