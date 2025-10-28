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
