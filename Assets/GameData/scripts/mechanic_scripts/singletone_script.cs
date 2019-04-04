using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class singletone_script : MonoBehaviour
{
    [Header("-------------Level Settings----------------")]
    public float playerSpeed;
    public GameObject shootingPS;
    public bool disable_control;
    public Player_Info player_info;
    [HideInInspector]
    public float tempSpeed;
    public Boundary boundary;
    public GameObject player;
    [Header("-------------------Seed----------------")]
    public int obstaclesNumber;
    public Seed seed;
    [Header("-------------------Obstacles----------------")]
    public GameObject startZone;
    public GameObject finishZone;
    public GameObject[] currentObstacles;
    public level_generator_script level_generator;
    public GameObject[] obstaclesPrefabs;
    [Header("-------------UI Manager----------------")]
    public ui_manager ui_manager;
    public Canvas main_menu_canvas;
    public Canvas level_complete_canvas;
    public Text scoreUI;
    public Text highscoreUI;
    public Text nextLevelText;
    
    private void Start()
    {
        seed = new Seed(obstaclesNumber);
        seed.obstaclesNumber = obstaclesNumber;
        
        ui_manager.Pause_Game();
        level_complete_canvas.enabled = false;

        level_generator.BuildLevel();

        player_info = data_base.Deserialize();
    }
    public void NewLevel()
    {
        seed = new Seed(obstaclesNumber);
        level_generator.BuildLevel();
        player.transform.position = new Vector3(player.transform.position.x, -3.52f, 0);
    }

    public void OnApplicationQuit()
    {
        data_base.Serialize(player_info);
        Debug.Log(Application.persistentDataPath);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ui_manager.LevelEnded();
        }
    }
}
