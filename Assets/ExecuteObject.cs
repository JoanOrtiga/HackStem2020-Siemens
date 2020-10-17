using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteObject : MonoBehaviour
{
    public void StartMoving()
    {
        print(Physics2D.Raycast(transform.position, Vector2.down, 10).collider.gameObject.name);
    }
}
