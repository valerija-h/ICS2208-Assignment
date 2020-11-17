using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint; //The point where we need to know to generate more platforms.
    public float distanceBetween;

    private float platformWidth;

    public ObjectPooler theObjectPool;
    private CoinGenerator theCoinGenerator;
    private ObstacleGenerator theObstacleGenerator;
    public float randomCoinThreshold; //Chance of spawning a coin.

	// Use this for initialization
	void Start () {
        //platformWidth = thePlatform.GetComponent<Collider>().bounds.size.z; //How long the platform is.
        platformWidth = 20; //Collider not working from prefab object.

        theCoinGenerator = FindObjectOfType<CoinGenerator>();
        theObstacleGenerator = FindObjectOfType<ObstacleGenerator>();

    }
	
	// Update is called once per frame
	void Update () {
        //Need to create a new platform.
        if (transform.position.z < generationPoint.position.z) {
            //Move it one platform ahead.
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + platformWidth + distanceBetween);
            //Create a copy of the platform.
            //Instantiate(thePlatform, transform.position, transform.rotation);

            //Get a pooled object from the ObjectPooler script.
            GameObject newPlatform = theObjectPool.GetPooledObject();
            newPlatform.transform.position = transform.position; //Move object into place of platform generator.
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true); //And set it to active.

            if (Random.Range(0f, 100f) < randomCoinThreshold)
            {
                //Spawn a coin in a random x coo-rdinate.
                theCoinGenerator.SpawnCoins(new Vector3(Random.Range(-6f, 6f), transform.position.y + 1f, transform.position.z));
            } else {
                theObstacleGenerator.SpawnObstacles(new Vector3(transform.position.x, transform.position.y, transform.position.z));
            }
        }
	}
}
