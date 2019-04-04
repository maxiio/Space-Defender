using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_counter : MonoBehaviour
{
    private singletone_script singletone;

    private void Start()
    {
        singletone = GetComponent<singletone_script>();
    }
    void Update()
    {
        singletone.player_info.score = /*Score*/ 0;
    }
}
