using UnityEngine;
using UnityEngine.UI;

public class PointScore : MonoBehaviour
{
    public Text scoreText;
    public int scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0;
    }

    public void ChangeScore()
    {
        scoreCount += 10;
        scoreText.text = scoreCount.ToString("0");
        scoreText.color = Color.red;
        Invoke("ChangeTextColor", 1);


    }

     public void ChangeTextColor()
    {
        scoreText.color = Color.white;
    }
}
