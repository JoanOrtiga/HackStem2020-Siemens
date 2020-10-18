using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public static Vector2 cellSize = new Vector2(45, 45);

    private static List<GameObject> blocks = new List<GameObject>();
    public static Vector2 GetGridPosition(Vector2 position)
    {
        int xCount = (int)(Mathf.RoundToInt(position.x / cellSize.x) * cellSize.x);
        int yCount = (int)(Mathf.RoundToInt(position.y / cellSize.y) * cellSize.y);

        return new Vector2(xCount, yCount);
    }
}
