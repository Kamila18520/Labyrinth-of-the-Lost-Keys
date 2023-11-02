using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMonsterController : MonoBehaviour
{
    public GameObject Light;

    public GameObject Monster;
    public bool isMonsterVisible;

    private void Start()
    {
        isMonsterVisible = false;
        Monster.SetActive(false);

        InvokeRepeating("Action1", 0f, 2f); // Rozpocznij powtarzanie Action1 co 2 sekundy (0s opóŸnienia).
        InvokeRepeating("Action2", 1f, 2f); // Rozpocznij powtarzanie Action2 co 2 sekundy (1s opóŸnienia).
    }


    private void Action1()
    {
        Light.GetComponent<Light>().intensity = 4f;

    }

    private void Action2()
    {
        Light.GetComponent<Light>().intensity = 0f;
        Debug.Log("Druga czynnoœæ.");
    }




    private void Update()
    {
        if(Light.GetComponent<Light>().intensity == 4f )
        {
            if(isMonsterVisible) 
            {
                Monster.SetActive(false);
                isMonsterVisible = false;
            }
            else if(!isMonsterVisible) 
            {
                Monster.SetActive(true);
                isMonsterVisible = true;
            
            }

        }
    }

}
