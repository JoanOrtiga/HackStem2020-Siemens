using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class PlcamentManager : MonoBehaviour
{
    public GameObject CharacterParent;
    public GameObject manager;
    public GameObject[] CharacterToPlace;
    public ARRaycastManager raymanager;
    public GameObject PointerObj;

    private int count;
    // Start is called before the first frame update
    void Start()
    {
        raymanager = FindObjectOfType<ARRaycastManager>();
        PointerObj = this.transform.GetChild(0).gameObject;
        PointerObj.SetActive(false);
        manager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        


        List<ARRaycastHit> hitpont = new List<ARRaycastHit>();
        raymanager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hitpont, TrackableType.Planes);
        if (hitpont.Count > 0)
        {
            transform.position = hitpont[0].pose.position;
            transform.rotation = hitpont[0].pose.rotation;

            if (!PointerObj.activeInHierarchy)
            {
                PointerObj.SetActive(true);
            }
        }
    }

    public void placeObject()
    {
        GameObject playerChoose;
        playerChoose = CharacterToPlace[manager.GetComponent<Manager>().PlayerChose];
        if (CharacterParent.transform.childCount > 0)
        {
            print("HEY");
            Destroy(CharacterParent.gameObject.transform.GetChild(0).gameObject);
        }

        var objIntant = Instantiate(playerChoose, this.transform.position, this.transform.rotation);
        objIntant.transform.parent = CharacterParent.transform;


    }
}
