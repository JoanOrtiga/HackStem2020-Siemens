using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Move : CodeBlock
{
    public float speed = 5f;
    public float distance = 2f;

    private float timeMoving;

    public GameObject textField;

    private InputField fspeed, fdistance;

    public override void InitObject(GameObject codedObject = null)
    {
        try
        {
            speed = float.Parse(fspeed.text);
        }
        catch
        {
            speed = 0;
        }

        try
        {
            distance = float.Parse(fdistance.text);
        }
        catch
        {
            distance = 0;
        }

        timeMoving = distance / speed;
    }

    public override void UpdateObject(GameObject codedObject = null, Queue<CodeBlock> blockList = null)
    {
        timeMoving -= Time.deltaTime;
        
        if (timeMoving >= 0)
        {
            codedObject.GetComponent<Rigidbody>().MovePosition(codedObject.transform.position + transform.forward* speed * Time.deltaTime);
        }
        else
        {
            blockList.Dequeue();
        }
    }

    public override void EditChildParameters(GameObject codedObject = null)
    {
        GameObject text = transform.GetChild(0).GetChild(0).gameObject;
        GameObject textX = Instantiate(text, text.transform.parent);

        textX.GetComponent<Text>().text = "| Distance:";
        GameObject textF = Instantiate(textField, text.transform.parent);

        fdistance = textF.transform.GetChild(0).GetComponent<InputField>();

        GameObject textX2 = Instantiate(text, text.transform.parent);

        textX2.GetComponent<Text>().text = "m Speed:";
        GameObject textF2 = Instantiate(textField, text.transform.parent);

        fspeed = textF2.transform.GetChild(0).GetComponent<InputField>();
    }
}
