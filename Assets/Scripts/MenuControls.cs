using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject ChooseScreen;
    public void PlayPressed()
    {
        MainMenu.SetActive(false);
        ChooseScreen.SetActive(true);
        
    }
    public void BackPressed()
    {
        MainMenu.SetActive(true);
        ChooseScreen.SetActive(false);
    }
    public void HardModeChoosen()
    {
        DataHolder.FieldSize = 100;
        SceneManager.LoadScene("GameScene");
    }
    public void EasyModeChoosen()
    {
        DataHolder.FieldSize = 3;
        SceneManager.LoadScene("GameScene");
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
}
