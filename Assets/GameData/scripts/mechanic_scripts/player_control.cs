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
    public singletone_script singletone;
    Vector3 startClickPos;
    
    
    
    
    void FixedUpdate()
    {
        if (!singletone.disable_control)
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
                this.transform.position = new Vector3(Mathf.Clamp(posX, singletone.boundary.xMin, singletone.boundary.xMax), posY);
                startClickPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            }
        }

        //var currentPos = this.transform.position;
        //this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(currentPos.x, currentPos.y + (speed/100),currentPos.z), 10);
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Asteroid")
        {
            singletone.app_State_Manager.State_Losed();
        }
    }
}
