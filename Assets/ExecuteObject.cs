using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteObject : MonoBehaviour
{
    public ProgramableObject programableObject;

    public void StartMoving()
    {
        programableObject.blockList.Clear();

        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, (40 * transform.parent.localScale.x));

        if (ray)
        {
            programableObject.blockList.Enqueue(ray.collider.gameObject.GetComponent<CodeBlock>());

            ray.collider.gameObject.GetComponent<LookForNextBlock>().StartMoving(programableObject);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, ((Vector2)transform.position + Vector2.down * (40 * transform.parent.localScale.x)) );
    }
}
