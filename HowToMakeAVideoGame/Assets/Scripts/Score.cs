using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Transform player;
	public Text scoreText;
    public int scoreCount;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update () {
        //Get score based on distance and points.
        int score = (int) Mathf.Round(player.position.z) + scoreCount;
        scoreText.text = score.ToString("0");
	}

    public void AddScore(int pointsToAdd) {
        scoreCount += pointsToAdd;
    }
}
