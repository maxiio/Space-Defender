using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class singletone_script : MonoBehaviour
{
    [Header("-----------Build Mode----------------")]
    public bool debugMode;
    public GameObject fps;
    public GameObject console;
    [Header("-------------Level Settings----------------")]
    public float playerSpeed;
    public GameObject shootingPS;
    public bool disable_control;
    public Player_Info player_info;
    [HideInInspector]
    public float tempSpeed;
    public Boundary boundary;
    public GameObject player;

    //Hidden Classes
    [HideInInspector]
    public checker_script checker_Script;

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
    public Canvas game_lost_canvas;
    public Text scoreUI;
    public Text highscoreUI;
    public Text nextLevelText;



    private float timer;
    
    private void Start()
    {
        if (!debugMode)
        {
            fps.SetActive(false);
            console.SetActive(false);
        }

        NewLevel();
                
        ui_manager.Pause_Game();
        level_complete_canvas.enabled = false;


        player_info = data_base.Deserialize();

        checker_Script = new checker_script(GetComponent<singletone_script>());


    }

    public void OnApplicationQuit()
    {
        data_base.Serialize(player_info);
        Debug.Log(Application.persistentDataPath);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            data_base.Serialize(player_info);
            Debug.Log("Saved On Focus Lost");
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer>5)
        {
            checker_Script.CheckAchievements();
            data_base.Serialize(player_info);
            timer = 0;
            Debug.Log("System Data Save");
        }
    }

    public void NewLevel()
    {
        if (!debugMode)
        {
            seed = new Seed(obstaclesNumber);
        }
        level_generator.BuildLevel();
        player.transform.position = new Vector3(player.transform.position.x, -3.52f, 0);
    }
}
