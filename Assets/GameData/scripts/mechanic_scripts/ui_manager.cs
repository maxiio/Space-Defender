using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_manager : MonoBehaviour {
    public singletone_script singletone;

    public void Pause_Game()
    {
        singletone.tempSpeed = singletone.playerSpeed;
        singletone.playerSpeed = 0;

        singletone.shootingPS.SetActive(false);
        singletone.disable_control = true;
    }


    public void Continue_Game()
    {
        singletone.playerSpeed = singletone.tempSpeed;
        singletone.level_complete_canvas.enabled = false;
        singletone.shootingPS.SetActive(true);
        singletone.disable_control = false;
    }

    public void Tap_To_Play()
    {
        Continue_Game();
        singletone.main_menu_canvas.enabled = false;
    }

    public void Level_Finished()
    {
        singletone.player_info.level++;
        singletone.nextLevelText.text = singletone.player_info.level.ToString();
        singletone.level_complete_canvas.enabled = true;
        Pause_Game();
        singletone.NewLevel();
    }

    public void Game_Lost()
    {
        Pause_Game();

        singletone.NewLevel();

        singletone.main_menu_canvas.enabled = true;

        singletone.checker_Script.CheckAchievements();
        singletone.player_info.score = 0;

        Debug.Log("Game Lost");
    }

    private void Update()
    {
        singletone.scoreUI.text = singletone.player_info.score.ToString();
        singletone.highscoreUI.text = "your highscore: " + singletone.player_info.highscore.ToString();

    }
}
