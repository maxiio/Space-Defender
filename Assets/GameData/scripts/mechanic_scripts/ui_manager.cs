using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_manager : MonoBehaviour {
    public singletone_script singletone;


    public void Continue_Game()
    {
        singletone.app_State_Manager.State_Playing();
        singletone.level_complete_canvas.enabled = false;
        singletone.NewLevel();
    }

    public void Tap_To_Restart()
    {
        singletone.player_info.score = 0;
        singletone.main_menu_canvas.enabled = true;
        singletone.NewLevel();
        singletone.game_lost_canvas.enabled = false;
        singletone.player.transform.position = new Vector3(0, -3.52f, 0);
        singletone.app_State_Manager.State_Menu();
        Debug.Log("Tap To Restart");
    }

    public void Tap_To_Play()
    {

        //singletone.NewLevel();
        singletone.player_info.score = 0;
        Continue_Game();
        singletone.main_menu_canvas.enabled = false;
        Debug.Log("Tap To Play");
    }



    public void Level_Finished()
    {
            singletone.level_complete_canvas.enabled = true;
    }

    public void Game_Lost()
    {
            singletone.game_lost_canvas.enabled = true;
    }

    private void Update()
    {
        singletone.scoreUI.text = singletone.player_info.score.ToString();
        singletone.highscoreUI.text = "your highscore: " + singletone.player_info.highscore.ToString();

    }
}
