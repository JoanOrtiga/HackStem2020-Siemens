using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForNextBlock : MonoBehaviour
{
    public void StartMoving(ProgramableObject programableObject)
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, (40 * transform.parent.localScale.x));

        if (ray)
        {
            programableObject.blockList.Enqueue(ray.collider.gameObject.GetComponent<CodeBlock>());

            ray.collider.gameObject.GetComponent<LookForNextBlock>().StartMoving(programableObject);
        }
    }
}
