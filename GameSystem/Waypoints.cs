using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Waypoints : MonoBehaviour
{
    private PathFinding pathFinding;
    private List<PathNode> path = new List<PathNode>();
    public static Transform[] points;
    public Transform node;

    private void Awake()
    {
        pathFinding = new PathFinding(GameMenu.GridWidth, GameMenu.GridHeight, GameMenu.CellSize, GameMenu.OriginPosition);
        if (path != null)
        {
            path = pathFinding.FindPath(0, 0, 9, 8);
            points = new Transform[path.Count];

            for (int i = 0; i < path.Count; i++)
            {
                
                Vector3 startLine = pathFinding.GetGrid().GetWorldPosition(path[i].x, path[i].y) + 5f * new Vector3(1, 1, 0);
                points[i] = Instantiate(node, startLine, Quaternion.identity);
                points[i].SetParent(transform);
            }

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = transform.GetChild(i);
            }

        }
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
        pathFinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
        
        if (Input.GetMouseButtonDown(1))
        {
            pathFinding.GetGrid().GetGridObject(x, y).SetIsWalkable();
        }
    }
}
