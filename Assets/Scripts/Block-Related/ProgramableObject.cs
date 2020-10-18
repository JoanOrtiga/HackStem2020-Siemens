using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProgramableObject : MonoBehaviour
{
    //public List<CodeBlock> blockList;

    [SerializeField] public Queue<CodeBlock> blockList;

    private void Awake()
    {
        blockList = new Queue<CodeBlock>();
    }

    public void StartObjects()
    {
        StopCoroutine(UpdateObject());
        StartCoroutine(UpdateObject());
    }

    IEnumerator UpdateObject()
    {
        bool infinite = true;

        for (int i = 0; i < blockList.Count; i++)
        {
            blockList.ElementAt(i).InitObject(gameObject);
            yield return null;
        }

        while (infinite)
        {
            if(blockList.Count != 0)
            {
                
                blockList.ElementAt(0).UpdateObject(gameObject, blockList);

                
            }

            yield return null;
        }
    }
}
