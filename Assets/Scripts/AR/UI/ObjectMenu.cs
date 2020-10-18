using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenu : MonoBehaviour
{

    public bool IsOpen = false;

    
    public GameObject Open;
    // Start is called before the first frame update

    private void Start()
    {
        Open.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
                
       
    }


    public void OpenMenu()
    {
        if (IsOpen == false)
        {
            Open.SetActive(true);
            IsOpen = true;
        }
        else if (IsOpen == true)
        {
            Open.SetActive(false);
            IsOpen = false;

        }
    }
}
