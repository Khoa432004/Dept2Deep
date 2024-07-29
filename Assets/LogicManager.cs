using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LogicManager : MonoBehaviour
{
    public GameObject GameEndScene;
    // Start is called before the first frame update
    void Start()
    {
        GameEndScene.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameEnd()
    {
        GameEndScene.SetActive(true);
    }
}
