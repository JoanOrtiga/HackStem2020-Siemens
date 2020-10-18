using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public bool move  = false;
    public GameObject ParentObjects;
    private GameObject player;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   


    // Update is called once per frame
    void Update()
    {

        if (ParentObjects.transform.childCount > 0)
        {
            if (move)
            {
                player = ParentObjects.transform.GetChild(0).gameObject;
                player.GetComponent<Rigidbody>().velocity = player.GetComponent<Rigidbody>().transform.forward * speed * Time.deltaTime;

            }
            else
            {
                player = ParentObjects.transform.GetChild(0).gameObject;
                player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
        
    }
    public void MoveCharacter()
    {
        if (move == true)
        {
            move = false;
        }
        else
        {
            move = true;
        }
       
    }

}
