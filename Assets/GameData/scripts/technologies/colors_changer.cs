using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colors_changer : MonoBehaviour
{
    public GameObject[] obstacles;
    void Start()
    {
        for(int i=0; i<obstacles.Length; i++)
        {
            BuildGradients(i);
        }
    }
    void BuildGradients(int i)
    {
        if (i == 0)//Start
        {
            Debug.Log("1.1");
            obstacles[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0,0,0);
            obstacles[i].GetComponent<SpriteRenderer>().color = obstacles[i + 1].transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        }
        else if (i + 1 == obstacles.Length)//End
        {
            Debug.Log("1.3");
            obstacles[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        }
        else //Usual
        {
            Debug.Log("1.2");
            obstacles[i].GetComponent<SpriteRenderer>().color = obstacles[i+1].transform.GetChild(0).GetComponent<SpriteRenderer>().color;
            
        }

    }

}
