using UnityEngine;
using System.Collections; 
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 1f;

    void OnTriggerEnter2D(Collider2D other) {

        StartCoroutine(LoadNextLevel()); 
    }

    IEnumerator LoadNextLevel() {
        yield return new WaitForSeconds(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

}

