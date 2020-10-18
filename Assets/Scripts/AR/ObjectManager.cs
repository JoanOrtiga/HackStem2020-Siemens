using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    public GameObject[] objects;
    public int playerChoseObj = 0;
    public GameObject objectChose;

   

    // Update is called once per frame
    void Update()
    {
        objectChose = objects[playerChoseObj];
    }
}
