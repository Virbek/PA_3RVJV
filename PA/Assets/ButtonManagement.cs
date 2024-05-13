using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManagement : MonoBehaviour
{

    public Text MyText;

    public void QuitButton()
    {
        Application.Quit();

    }

    public void PlayButton()
    {
        MyText.text = "GAME PLAYING";
    }
    public void SettingButton()
    {
        MyText.text = "SETTING MENU";
    }
}    