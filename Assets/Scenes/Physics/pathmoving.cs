using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class pathmoving : MonoBehaviour
{
    private PathCreator pathCreator;
    private singletone_script singletone;
    private Vector3 velocity = Vector3.down;
    private void Start()
    {
        pathCreator = this.gameObject.GetComponent<PathCreator>();
        for (int i = 0; i < pathCreator.path.vertices.Length; i++)
        {
            pathCreator.path.vertices[i] = new Vector3(pathCreator.path.vertices[i].x, (this.transform.position.y - pathCreator.path.vertices[i].y), pathCreator.path.vertices[i].z);
        }
            singletone = GameObject.FindObjectOfType<singletone_script>();
    }
    private void FixedUpdate()
    {
        for (int i=0; i< pathCreator.path.vertices.Length; i++)
        {
        pathCreator.path.vertices[i] = Vector3.SmoothDamp(pathCreator.path.vertices[i], new Vector3(pathCreator.path.vertices[i].x, pathCreator.path.vertices[i].y - (singletone.playerSpeed / 100f), pathCreator.path.vertices[i].z), ref velocity, 0.1F);
        }
    }
}
