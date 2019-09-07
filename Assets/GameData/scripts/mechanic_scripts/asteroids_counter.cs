using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroids_counter : MonoBehaviour
{

    // Start is called before the first frame update
    public int asteroids_on_screen;

    public GameObject[] obstacles;

    private void Start()
    {

           
    }
    // Update is called once per frame
    void Update()
    {
        obstacles = new GameObject[this.transform.childCount];
        for (int i = 0; i > this.transform.childCount; i++)
        {

            obstacles[i] = this.transform.GetChild(i).gameObject;
        }
    }
}
