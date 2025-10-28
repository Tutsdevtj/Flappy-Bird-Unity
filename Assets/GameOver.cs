using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Animator gameOverAnimator;
    public GameObject gameOverPanelObject;
    void Start()
    {
        if (gameOverPanelObject != null)
        {
            gameOverPanelObject.SetActive(false);
        }
       

        Time.timeScale = 1;
    }

   public void GameOverActive()
{
    if (gameOverPanelObject != null && !gameOverPanelObject.activeSelf)
    {
        gameOverPanelObject.SetActive(true);
        SoundManager.instance.PlayMorte();

        
        int currentScore = Mathf.FloorToInt(Points.scoreValue);
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            PlayerPrefs.Save();
        }

        Debug.Log($"[GAME OVER] Score atual: {currentScore} | Best: {PlayerPrefs.GetInt("BestScore")}");
    }

    if (gameOverAnimator != null)
    {
        gameOverAnimator.SetTrigger("ShowGameOver");
    }

    Time.timeScale = 0;
}

    public void RestartGame()
    {

        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void VoltaMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("mainMenu");
    }
}
