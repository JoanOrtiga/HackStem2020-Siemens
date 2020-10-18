using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowEditor : MonoBehaviour
{

    public GameObject Editor;
    public GameObject NoEditor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowEditor()
    {
        Editor.SetActive(true);
        NoEditor.SetActive(false);
    }

    
}
