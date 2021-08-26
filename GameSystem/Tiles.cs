using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tiles
{
    private Grid<Tiles> grid;
    private GameObject transform;

    public int x;
    public int y;

    public Tiles(Grid<Tiles> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void SetTransform(GameObject transform)
    {
        this.transform = transform;
        grid.TriggerGridObjectChanged(x, y);
    }

    public void ClearTransform()
    {
        transform = null;
        grid.TriggerGridObjectChanged(x, y);
    }

    public bool CanBuild()
    {
        return transform == null;
    }

    public override string ToString()
    {
        return x + ", " + y + "\n" + transform;
    }
}
