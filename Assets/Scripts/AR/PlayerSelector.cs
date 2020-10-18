using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelector : MonoBehaviour
{
    public GameObject[] itemsToPlay; //0 car, 1 Robot, 2 ball, 3 hourse
    private GameObject manager;

    private int showing = 0;

    private void Start()
    {

        manager = GameObject.Find("GameManager");

        for (int i = 0; i < itemsToPlay.Length; i++)
        {
            itemsToPlay[i].SetActive(false);
        }
    }


    private void Update()
    {
        for (int i = 0; i < itemsToPlay.Length; i++)
        {
            if (i == showing)
            {
                itemsToPlay[i].SetActive(true);
            }
            else
            {
                itemsToPlay[i].SetActive(false);
            }
        }

        manager.GetComponent<Manager>().PlayerChose = showing;
    }


    public void LeftButton()
    {
        if (showing == 0) //in the limit
        {
            showing = 3;
        }
        else
        {
            showing = showing - 1;
        }
    }

    public void RIghtButton()
    {
        if (showing == 3) //in the limit
        {
            showing = 0;
        }
        else
        {
            showing = showing + 1;
        }
    }

    public void PlayGame()
    {
        if (manager.GetComponent<Manager>().GameMode == 1)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
}
