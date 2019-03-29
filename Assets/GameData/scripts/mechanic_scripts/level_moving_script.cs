using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_moving_script : MonoBehaviour
{
    public singletone_script singletone;
    private Vector3 velocity = Vector3.down;
    private void Update()
    {
        var currentPos = this.transform.position;
       // this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(currentPos.x, currentPos.y - (singletone.playerSpeed/100),currentPos.z), 0.3F);
        this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(currentPos.x, currentPos.y - (singletone.playerSpeed / 100), currentPos.z),ref velocity, 0.1F);
    }
}
