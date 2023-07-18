using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    float gameOverDelay = 2f;

    public void LoadGame() {
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOver() {
        StartCoroutine(WaitAndLoad("GameOver", gameOverDelay));
    }

    IEnumerator WaitAndLoad(string sceneName, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
