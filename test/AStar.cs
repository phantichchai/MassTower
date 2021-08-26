using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class AStar : MonoBehaviour
{
    private PathFinding pathFinding;
    private List<PathNode> path = new List<PathNode>();

    private void Start()
    {   
        pathFinding = new PathFinding(16, 9, 10f, GameMenu.OriginPosition);
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
        pathFinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
        if (Input.GetMouseButtonDown(0))
        {
            if (path != null)
            {
                path = pathFinding.FindPath(0, 0, x, y);

                for (int i = 0; i < path.Count - 1; i++)
                {
                    Vector3 startLine = pathFinding.GetGrid().GetWorldPosition(path[i].x, path[i].y) + Vector3.one * 5f;
                    Vector3 endLine = pathFinding.GetGrid().GetWorldPosition(path[i + 1].x, path[i + 1].y) + Vector3.one * 5f;
                    Debug.DrawLine(startLine, endLine, Color.green, 3f);
                    Debug.Log(path[i].x + ", "+ path[i].y);
                }

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            pathFinding.GetGrid().GetGridObject(x, y).SetIsWalkable();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (path.Count > 0)
            {
                Debug.Log(path);
            }
        }
    }
}
