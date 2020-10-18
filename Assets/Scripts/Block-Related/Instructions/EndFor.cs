using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFor : CodeBlock
{
    public override void InitObject(GameObject codedObject = null)
    {
        print("This shouldn't be called");
    }


    public override void UpdateObject(GameObject codedObject = null, Queue<CodeBlock> blockList = null)
    {
        print("This shouldn't be called");
    }


    public override void EditChildParameters(GameObject codedObject = null)
    {

    }
}
