using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {
    public ObjectPooler obstaclesSmall;
    public ObjectPooler obstaclesBig;
    private GameObject small1, small2, big1, big2; //Temporarily store obstacles.

    public void SpawnObstacles(Vector3 platformPosition) {
        //Choose a random number for a random obstacle type.
        int choice = Random.Range(1,5);
        switch (choice)
        {
            //Small left, Two large mid and right.
            case 1:
                small1 = obstaclesSmall.GetPooledObject();
                small1.transform.position = new Vector3(-4,1, platformPosition.z);
                small1.SetActive(true);
                big1 = obstaclesBig.GetPooledObject();
                big1.transform.position = new Vector3(0, 1, platformPosition.z);
                big1.SetActive(true);
                big2 = obstaclesBig.GetPooledObject();
                big2.transform.position = new Vector3(4, 1, platformPosition.z);
                big2.SetActive(true);
                break;
            //Large mid-left, small mid-right.
            case 2:
                small1 = obstaclesSmall.GetPooledObject();
                small1.transform.position = new Vector3(-2, 1, platformPosition.z);
                small1.SetActive(true);
                big1 = obstaclesBig.GetPooledObject();
                big1.transform.position = new Vector3(2, 1, platformPosition.z);
                big1.SetActive(true);
                break;
            //Two large on mid-left, mid-right.
            case 3:
                big2 = obstaclesBig.GetPooledObject();
                big2.transform.position = new Vector3(-2, 1, platformPosition.z);
                big2.SetActive(true);
                big1 = obstaclesBig.GetPooledObject();
                big1.transform.position = new Vector3(2, 1, platformPosition.z);
                big1.SetActive(true);
                break;
            //Two small on the sides, large in the middle.
            case 4:
                small1 = obstaclesSmall.GetPooledObject();
                small1.transform.position = new Vector3(-4, 1, platformPosition.z);
                small1.SetActive(true);
                big1 = obstaclesBig.GetPooledObject();
                big1.transform.position = new Vector3(0, 1, platformPosition.z);
                big1.SetActive(true);
                small2 = obstaclesSmall.GetPooledObject();
                small2.transform.position = new Vector3(4, 1, platformPosition.z);
                small2.SetActive(true);
                break;
            default:
                break;
        }
    }
}
