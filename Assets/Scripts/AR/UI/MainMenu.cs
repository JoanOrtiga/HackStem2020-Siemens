using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject menu1;
    public GameObject menu2;
    public GameObject menu3;

    private GameObject manager;

    private void Start()
    {
        manager = GameObject.Find("GameManager");
    }
    public void ChangeMenu1To2()
    {
        menu1.SetActive(false);
        menu2.SetActive(true);
    }

    public void ChangeMenu2To3()
    {
        menu2.SetActive(false);
        menu3.SetActive(true);
    }


    public void AROn()
    {
        manager.GetComponent<Manager>().GameMode = 1;
        SceneManager.LoadScene(1);
    }

    public void AROff()
    {
        manager.GetComponent<Manager>().GameMode = 2;
        SceneManager.LoadScene(1);
    }
}
