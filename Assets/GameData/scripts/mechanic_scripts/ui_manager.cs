using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_manager : MonoBehaviour {
    public singletone_script singletone;
    private bool isAlreadyPaused;

    public void Pause_Game()
    {
            isAlreadyPaused = true;

            singletone.tempSpeed = singletone.playerSpeed;
            singletone.playerSpeed = 0;

            singletone.shootingPS.SetActive(false);
            singletone.disable_control = true;
            Debug.Log("Pause Game");   
    }


    public void Continue_Game()
    {
        isAlreadyPaused = false;

        singletone.playerSpeed = singletone.tempSpeed;
        singletone.level_complete_canvas.enabled = false;
        singletone.shootingPS.SetActive(true);
        singletone.disable_control = false;

        Debug.Log("Continue Game");
    }

    public void Tap_To_Restart()
    {
        singletone.main_menu_canvas.enabled = true;
        singletone.game_lost_canvas.enabled = false;
        singletone.NewLevel();
        singletone.player.transform.position = new Vector3(0, -3.52f, 0);
        Debug.Log("Tap To Restart");
    }

    public void Tap_To_Play()
    {
        Continue_Game();
        singletone.main_menu_canvas.enabled = false;
        Debug.Log("Tap To Play");
    }

    public void Level_Finished()
    {
        if (!isAlreadyPaused)
        {
            singletone.player_info.level++;
            singletone.nextLevelText.text = singletone.player_info.level.ToString();
            singletone.level_complete_canvas.enabled = true;
            Pause_Game();
            singletone.NewLevel();
            Debug.Log("Level Finished");
        }
    }

    public void Game_Lost()
    {
        if (!isAlreadyPaused)
        {
            Pause_Game();
            singletone.game_lost_canvas.enabled = true;
            singletone.checker_Script.CheckAchievements();
            singletone.player_info.score = 0;

            Debug.Log("Game Lost");
        }
    }

    private void Update()
    {
        singletone.scoreUI.text = singletone.player_info.score.ToString();
        singletone.highscoreUI.text = "your highscore: " + singletone.player_info.highscore.ToString();

    }
}
