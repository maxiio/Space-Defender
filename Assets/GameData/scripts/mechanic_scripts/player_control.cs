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
    public Boundary boundary;
    Vector3 startClickPos;
    void FixedUpdate()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            startClickPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
        if (Input.GetMouseButton(0)) //Input.touchCount>0
        {
            Debug.DrawLine(this.transform.position, startClickPos, Color.blue);
            Debug.DrawLine(startClickPos, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.red);
            float posY = this.transform.position.y;
            float posX = this.transform.position.x + (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - startClickPos.x);
            this.transform.position = new Vector3(Mathf.Clamp(posX, boundary.xMin, boundary.xMax) , posY);
            startClickPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
      
    }


}
