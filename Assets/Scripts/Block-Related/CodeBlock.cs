using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBlock : MonoBehaviour
{
    public virtual void UpdateObject(GameObject codedObject = null)
    {
        print("This shouldn't be called.");
        print(codedObject.name);
    }
}
