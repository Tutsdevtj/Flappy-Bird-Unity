using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{


    public void startGame()
    {
        SceneManager.LoadScene("flappy b");
    }

    public void exitGame()
    {
        Debug.Log("Saindo do jogo...");

        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

