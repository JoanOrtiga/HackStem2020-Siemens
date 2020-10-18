using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class For : CodeBlock
{
    public int timesToExecute = 90;


    public GameObject textField;

    private InputField fTimesToExecute;

    bool lookForEndFor = true;
    int finalIndex = 0;
    int currentIndex = 1;

    int executedTimes;

    public override void InitObject(GameObject codedObject = null)
    {
        try
        {
            timesToExecute = int.Parse(fTimesToExecute.text);
        }
        catch
        {
            timesToExecute = 1;
        }

        lookForEndFor = true;
        finalIndex = 0;
        currentIndex = 1;
        executedTimes = timesToExecute;
    }

    public override void UpdateObject(GameObject codedObject = null, Queue<CodeBlock> blockList = null)
    {
        if (lookForEndFor)
        {
            for (int i = 0; i < blockList.Count; i++)
            {
                if (blockList.ElementAt(i).CompareTag("EndFor"))
                {
                    finalIndex = i;
                    lookForEndFor = false;
                    break;
                }
            }
        }

        if (executedTimes > 0)
        {
            blockList.ElementAt(currentIndex).UpdateObject(codedObject, blockList);
            executedTimes--;
        }
        else
        {
            if (currentIndex < finalIndex)
            {
                blockList.Where((value, index) => index != currentIndex);
                currentIndex++;
                executedTimes = timesToExecute;
            }
            else
            {
                blockList.Dequeue();
            }
        }
    }

    public override void EditChildParameters(GameObject codedObject = null)
    {
        GameObject text = transform.GetChild(0).GetChild(0).gameObject;
        GameObject textX = Instantiate(text, text.transform.parent);

        textX.GetComponent<Text>().text = "| Execute";
        GameObject textF = Instantiate(textField, text.transform.parent);

        fTimesToExecute = textF.transform.GetChild(0).GetComponent<InputField>();

        GameObject textX2 = Instantiate(text, text.transform.parent);

        textX2.GetComponent<Text>().text = "times";
    }
}
