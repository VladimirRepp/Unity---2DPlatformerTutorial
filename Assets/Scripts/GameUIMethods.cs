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
        Time.timeScale = 1f;
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

    public void OpenMenu(GameObject menu)
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseMenu(GameObject menu)
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }
}
