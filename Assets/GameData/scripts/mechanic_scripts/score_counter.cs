using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_counter : MonoBehaviour
{
    private singletone_script singletone;
    private float timer;

    private void Start()
    {
        singletone = GetComponent<singletone_script>();
    }
    void Update()
    {
        var level_coef = (singletone.player_info.level * 0.1f) + 1;
        if (!singletone.disable_control)
        {
            timer += Time.deltaTime * level_coef;
            if (timer > .2f)
            {
                singletone.player_info.score += 1;
                timer = 0;
            }
        }
    }
}
