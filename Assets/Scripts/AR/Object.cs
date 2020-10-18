using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public int ObjNumber;
    public GameObject objectManger;
    public GameObject openRIghtWindow;
    

    public void objectChose()
    {
        objectManger.GetComponent<ObjectManager>().playerChoseObj = ObjNumber;
        //openRIghtWindow.SetActive(false);
    }
}
