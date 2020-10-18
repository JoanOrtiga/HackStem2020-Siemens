using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCharacter : MonoBehaviour
{
    public Material hitMaterial;
    public GameObject[] characters;
    public GameObject manager;

    private Touch touch;
    private Vector3 touchPos;
    

    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Instantiate(characters[manager.GetComponent<Manager>().PlayerChose], touchPos, Quaternion.identity);
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    print("CLICK");
        //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hitInfo;
        //    if (Physics.Raycast(ray, out hitInfo))
        //    {
        //        var rig = hitInfo.collider.GetComponent<Rigidbody>();
        //        if (rig != null)
        //        {
        //            //rig.GetComponent<MeshRenderer>().material = hitMaterial;
        //            Instantiate(characters[manager.GetComponent<Manager>().PlayerChose], hitInfo.transform.position, hitInfo.transform.rotation);
        //           // rig.AddForceAtPosition(ray.direction * 50f, hitInfo.point, ForceMode.VelocityChange);
        //        }
        //    }
        //}

    }
}
