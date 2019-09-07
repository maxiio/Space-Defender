using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class app_state_manager : MonoBehaviour
{
    public singletone_script singletone;

    public bool IsAlreadyPaused { get; private set; }

    public void State_Losed()
    {
        Paused();

        singletone.ui_manager.Game_Lost();
        singletone.checker_Script.CheckAchievements();
        singletone.flyingPS.SetActive(false);

        Debug.Log("Game Lost");
    }

    public void State_Playing()
    {
        IsAlreadyPaused = false;
        singletone.playerSpeed = singletone.tempSpeed;

        singletone.shootingPS.SetActive(true);
        singletone.disable_control = false;

        singletone.flyingPS.SetActive(true);

        Debug.Log("Continue Game");
    }

    public void State_Menu()
    {
        singletone.startZone.GetComponent<dynamic_gradient>().RandomizeStartColors();
        Paused();
        singletone.startZone.GetComponent<dynamic_gradient>().isDynamic = true;
        singletone.flyingPS.SetActive(true);
    }

    public void State_Finished()
    {
        singletone.ui_manager.Level_Finished();
        singletone.startZone.GetComponent<dynamic_gradient>().isDynamic = true;
        singletone.player_info.level++;
        singletone.nextLevelText.text = singletone.player_info.level.ToString();
        singletone.flyingPS.SetActive(true);

        Paused();
            //singletone.NewLevel();
        Debug.Log("Level Finished");
    }


    public void Paused()
    {
        if (IsAlreadyPaused != true)
        {
            IsAlreadyPaused = true;

            singletone.tempSpeed = singletone.playerSpeed;
            singletone.playerSpeed = 0;

            singletone.shootingPS.SetActive(false);
            singletone.disable_control = true;

            Debug.Log("Pause Game");
        }
    }


}
