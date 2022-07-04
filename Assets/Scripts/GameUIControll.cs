using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIControll : MonoBehaviour
{
    public GameObject GameEndUI;
    public GameObject GameOnUI;

    public void RestartPressed()
    {
        GameEndUI.SetActive(false);
        GameOnUI.SetActive(true);
        SceneManager.LoadSceneAsync("GameScene",LoadSceneMode.Single);
    }

    public void BackToMenuPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}
