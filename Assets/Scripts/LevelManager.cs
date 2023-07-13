using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
    }
    public void LoadGame() {
        SceneManager.LoadScene(1);
    }
    public void LoadGameOver() {
        StartCoroutine(WaitAndLoad(2, sceneLoadDelay));
    }
    public void QuitGame() {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(int sceneId, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneId);
    }
}
