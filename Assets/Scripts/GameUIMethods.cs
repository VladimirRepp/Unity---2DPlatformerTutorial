using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIMethods : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadLevel(int indexLevel)
    {
        SceneManager.LoadScene(indexLevel);
    }
}
