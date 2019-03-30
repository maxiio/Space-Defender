using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singletone_script : MonoBehaviour
{
    [Header("-------------Level Settings----------------")]
    public float playerSpeed;
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
    private void Start()
    {
        seed = new Seed(obstaclesNumber);
        seed.obstaclesNumber = obstaclesNumber;

        level_generator.BuildLevel();
    }
    public void NewLevel()
    {
        seed = new Seed(obstaclesNumber);
        level_generator.BuildLevel();
        player.transform.position = new Vector3(startZone.transform.position.x, -3.52f, 0);
    }
}
