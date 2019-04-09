using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_activator : MonoBehaviour
{
    public GameObject localObstaclesGroup;
    private void Start()
    {
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
