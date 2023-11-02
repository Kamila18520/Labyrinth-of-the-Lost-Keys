using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyScoreSystem : MonoBehaviour
{
    public int keys;
    public TextMeshProUGUI KeysUIText;
    public GameObject Menu;
    public GameObject GamePlay;
    public GameObject WinGameScreen;


    private void Start()
    {
        keys= 0;
    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Key"))
        {
            CollectKey(other.gameObject);
        }
        else if(other.CompareTag("Door") && keys ==10)
        {
            WinGame();
        }
    }


    private void CollectKey(GameObject key) 
    {
        keys++;
        Debug.Log("Zebrano klucz");
        KeysUIText.text = "Keys: " + keys;

        key.GetComponent<AudioSource>().Play();

        Destroy(key);

        if(keys== 10) 
        {
            KeysUIText.text = "Rush! Run to the door!";

        }

    }

    private void WinGame()
    {        
        
        Menu.SetActive(true);
        WinGameScreen.SetActive(true);
        GamePlay.SetActive(false);


        Invoke("ReloadCurrentScene", 3.0f);
    }

   
        public void ReloadCurrentScene()
        {

        SceneManager.LoadScene(0);

         }
    
        

}
