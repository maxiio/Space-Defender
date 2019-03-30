using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_manager : MonoBehaviour {
    public singletone_script singletone;

    public void Pause_Game()
    {
        singletone.tempSpeed = singletone.playerSpeed;
        singletone.playerSpeed = 0;
    }
    public void Continue_Game()
    {
        singletone.playerSpeed = singletone.tempSpeed;
        singletone.level_complete_canvas.enabled = false;
    }
    public void Start_Game()
    {
        Debug.Log("Start Game");
        singletone.playerSpeed = singletone.tempSpeed;
        singletone.main_menu_canvas.enabled = false;
    }
    public void Level_Complete_Window()
    {
        singletone.level_complete_canvas.enabled = true;
        Pause_Game();
    }

}
