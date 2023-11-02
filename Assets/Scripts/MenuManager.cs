using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Gameplay;


    public void Start()
    {
        Gameplay.SetActive(false);
        Menu.SetActive(true);
        
    }

    public void Play()
    {
        Gameplay.SetActive(true);
        Menu.SetActive(false);
        Debug.Log("Gra sie rozpoczela");
    }
    public void ExitGame()
    {
        Application.Quit(); 
    }

}
