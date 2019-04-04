using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class level_generator_script : MonoBehaviour
{
    public singletone_script singletone;
    public void BuildLevel()
    {
        ClearLevel(singletone.currentObstacles);
        singletone.currentObstacles = new GameObject[singletone.obstaclesNumber];

        var newObstaclePosition = singletone.startZone.transform.localPosition.y + ((singletone.startZone.GetComponent<SpriteRenderer>().bounds.size.y * .5f) 
                                                                            + (ObsctaclesDictionary(singletone.seed.obstaclesID[0]).GetComponent<SpriteRenderer>().bounds.size.y * .5f));
        for(int i=0; i<singletone.obstaclesNumber; i++)
        {
            var newObstacle = Instantiate(ObsctaclesDictionary(singletone.seed.obstaclesID[i]),this.gameObject.transform);
            newObstacle.transform.localPosition = new Vector3(singletone.startZone.transform.localPosition.x, newObstaclePosition,0);
            newObstaclePosition = CalculateY(newObstacle.transform.localPosition.y, newObstacle, i);

            singletone.currentObstacles[i] = newObstacle;
        }

        for (int i = 0; i < singletone.currentObstacles.Length; i++)
        {
            BuildGradients(i);
        }

    }
    private void BuildGradients(int i)
    {
        if (i == 0)//Start
        {
            singletone.currentObstacles[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
            singletone.currentObstacles[i].GetComponent<SpriteRenderer>().color = singletone.currentObstacles[i + 1].transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        }
        else if (i + 1 == singletone.currentObstacles.Length)//End
        {
            singletone.currentObstacles[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        }
        else //Usual
        {
            singletone.currentObstacles[i].GetComponent<SpriteRenderer>().color = singletone.currentObstacles[i + 1].transform.GetChild(0).GetComponent<SpriteRenderer>().color;

        }

    }
    private float CalculateY(float currentHeignt, GameObject lastObstacle, int i)
    {
        if (i+1 != singletone.obstaclesNumber) {
            return lastObstacle.transform.localPosition.y + ((lastObstacle.GetComponent<SpriteRenderer>().bounds.size.y * .5f) + (ObsctaclesDictionary(singletone.seed.obstaclesID[i+1]).GetComponent<SpriteRenderer>().bounds.size.y * .5f));
        } 
        singletone.finishZone.transform.localPosition = new Vector3(singletone.startZone.transform.localPosition.x,
                                                                    lastObstacle.transform.localPosition.y + ((lastObstacle.GetComponent<SpriteRenderer>().bounds.size.y * .5f) + (singletone.finishZone.GetComponent<SpriteRenderer>().bounds.size.y * .5f))
                                                                    ,0);
        Debug.Log(singletone.startZone.transform.localPosition.x + " " + lastObstacle.transform.localPosition.y + " " + (lastObstacle.GetComponent<SpriteRenderer>().bounds.size.y * .5f) + " " + (singletone.finishZone.GetComponent<SpriteRenderer>().bounds.size.y * .5f));
        return 0;
    }
    public void ClearLevel(GameObject[] arr)
    {
        singletone.startZone.transform.position = new Vector3(0, -0.6f, 0);
        singletone.finishZone.transform.position = new Vector3(0, 3, 0);
        for(int i=0; i<arr.Length; i++)
        {
            Destroy(arr[i]);
        }
    }
    public GameObject ObsctaclesDictionary(int id)
    {
        switch (id)
        {
            case 1:
                return singletone.obstaclesPrefabs[0];
            case 2:
                return singletone.obstaclesPrefabs[1];
            case 3:
                return singletone.obstaclesPrefabs[2];
            case 4:
                return singletone.obstaclesPrefabs[3];
            case 5:
                return singletone.obstaclesPrefabs[4];
            case 6:
                return singletone.obstaclesPrefabs[5];
            case 7:
                return singletone.obstaclesPrefabs[6];
            case 8:
                return singletone.obstaclesPrefabs[7];
            case 9:
                return singletone.obstaclesPrefabs[8];
            case 10:
                return singletone.obstaclesPrefabs[9];
        }
        return null;
    }

}
[System.Serializable]

public class Seed
{
    [HideInInspector]
    public int obstaclesNumber;

    public int[] obstaclesID;

    public Seed(int obstaclesNumber)
    {
        obstaclesID = new int[obstaclesNumber];
        obstaclesID = SmartRandom.GenerateSeed(obstaclesNumber);
    }

}
public static class SmartRandom
{
    public static int[] GenerateSeed(int obstaclesNumber)
    {
        int[] result = new int[obstaclesNumber];
        for (int i = 0; i < obstaclesNumber; i++)
        {
            result[i] = RandomUniqNumber(result);
        }
        return result;
    }
    private static bool CheckForDuplicate(int number, int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (number == arr[i]) return true;
        }
        return false;
    }
    private static int RandomUniqNumber(int[] arr)
    {
        var uniqueNumber = Random.Range(0, 10);
        if (CheckForDuplicate(uniqueNumber, arr))
        {
            return uniqueNumber = RandomUniqNumber(arr);
        }
        else
        {
            return uniqueNumber;
        }
    }
}
