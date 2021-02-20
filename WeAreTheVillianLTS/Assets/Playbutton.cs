using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playbutton : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public static bool GameStarted;
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void PlayButton()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        GameStarted = true;
    }
}
