 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish_script : MonoBehaviour {

    public singletone_script singletone;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("Trigger Entered");
            singletone.ui_manager.Level_Complete_Window();
        }
    }
}
