using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBlock : MonoBehaviour
{
    public virtual void InitObject(GameObject codedObject = null)
    {
        print("This shouldn't be called.");
        print(codedObject.name);
    }

    public virtual void UpdateObject(GameObject codedObject = null, Queue<CodeBlock> blockList = null)
    {
        print("This shouldn't be called.");
        print(codedObject.name);
    }

    public virtual void EditChildParameters(GameObject codedObject = null)
    {
        print("This shouldn't be called.");
        print(codedObject.name);
    }
}
