using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObject;
    public int pooledAmount; //Amount of objects we will pool.

    List<GameObject> pooledObjects;


	// Use this for initialization
	void Start () {
        pooledObjects = new List<GameObject>();
        //Create a list of pool objects.
        for (int i = 0; i < pooledAmount; i++) {
            GameObject obj = (GameObject) Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
	}

    public GameObject GetPooledObject() {
        //Get an inactive pooled object from the list.
        for (int i = 0; i < pooledObjects.Count; i++) {
            //Is the pooled object active at the moment.
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }
        //Other add a new object to the list.
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }

}
