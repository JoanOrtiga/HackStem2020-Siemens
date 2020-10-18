using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goBackScene()
    {
        Scene index;
        index = SceneManager.GetActiveScene();
       // SceneManager.LoadScene(index.);
    }
}
