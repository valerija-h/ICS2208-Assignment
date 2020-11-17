using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;

	public float restartDelay = 1f;

	public GameObject completeLevelUI;
    public GameObject gameOverUI;
    public GameObject pauseUI;

	public void CompleteLevel ()
	{
		completeLevelUI.SetActive(true);
        FindObjectOfType<AudioManager>().Play("LevelComplete");
    }

	public void EndGame ()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
            gameOverUI.SetActive(true);
            //Invoke("Restart", 1);
		}
	}

    public void PauseUI ()
    {
        if (!pauseUI.activeInHierarchy)
        {
            pauseUI.SetActive(true);
        }
    }

    public void unPauseUI() {
        if (pauseUI.activeInHierarchy) {
            pauseUI.SetActive(false);
        }
    }


    void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
