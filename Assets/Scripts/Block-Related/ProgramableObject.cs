using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramableObject : MonoBehaviour
{
    public List<CodeBlock> blockList;

    private void Awake()
    {
//blockList = new List<CodeBlock>();
    }

    private void Start()
    {
        StartCoroutine(UpdateObject());
    }
    IEnumerator UpdateObject()
    {
        while (true)
        {
            for (int i = 0; i < blockList.Count; i++)
            {
                blockList[i].UpdateObject(gameObject);
                yield return null;
            }
        }

        
    }
}
