using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : CodeBlock
{
    public float speed = 5f;

    public override void UpdateObject(GameObject codedObject = null)
    {
        codedObject.transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
    }
}
