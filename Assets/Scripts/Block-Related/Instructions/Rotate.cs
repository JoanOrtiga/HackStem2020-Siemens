using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : CodeBlock
{
    public float degrees = 90;
    public float speed = 5f;

    private float timeMoving;

    public GameObject textField;

    private InputField fspeed, fdegrees;

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
            degrees = float.Parse(fdegrees.text);
        }
        catch
        {
            degrees = 0;
        }


        timeMoving = degrees / speed;
    }

    public override void UpdateObject(GameObject codedObject = null, Queue<CodeBlock> blockList = null)
    {
        timeMoving -= Time.deltaTime;

        if (timeMoving >= 0)
        {
            codedObject.transform.Rotate(new Vector3(0, speed*Time.deltaTime, 0));
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

        textX.GetComponent<Text>().text = "| Degrees:";
        GameObject textF = Instantiate(textField, text.transform.parent);

        fdegrees = textF.transform.GetChild(0).GetComponent<InputField>();

        GameObject textX2 = Instantiate(text, text.transform.parent);

        textX2.GetComponent<Text>().text = "m Speed:";
        GameObject textF2 = Instantiate(textField, text.transform.parent);

        fspeed = textF2.transform.GetChild(0).GetComponent<InputField>();
    }
}
