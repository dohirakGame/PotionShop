using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class MenuScript : MonoBehaviour
{
    
    void Start()
    {
        
    }
    // Стартует игру(переходит на сцену игры по счелчку на соответствующую кнопку)
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Закрывает игру
    public void QuitGame()
    {
        Application.Quit();
    }

}
