using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoint : MonoBehaviour {

    //public int scoreToGive;
    //private PointScore scoreManager;
    public GameObject explode;
    GameObject player;
    GameObject e;
    //public Transform transform;

    // Use this for initialization
    void Start () {
        //scoreManager = FindObjectOfType<Score>();
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
       // scoreManager.AddScore(scoreToGive);
        FindObjectOfType<AudioManager>().Play("CoinCollect");
        Explode();
        FindObjectOfType<PointScore>().ChangeScore();
        gameObject.SetActive(false);
    }

    void Explode()
    {
        Debug.Log("WAZAAA");
        e = Instantiate(explode, transform.position, transform.rotation) as GameObject;
        e.transform.parent = player.transform;
        Invoke("toDestroy", 1);
    }
   
    void toDestroy()
    {
        Destroy(e);
    }
}

