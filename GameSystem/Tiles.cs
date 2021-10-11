using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tiles
{
    private Grid<Tiles> grid;
    private GameObject tileGameObject;

    public int x;
    public int y;

    public Tiles(Grid<Tiles> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void SetTransform(GameObject tileGameObject)
    {
        this.tileGameObject = tileGameObject;
        grid.TriggerGridObjectChanged(x, y);
    }

    public void ClearTransform()
    {
        tileGameObject = null;
        grid.TriggerGridObjectChanged(x, y);
    }

    public bool CanBuild()
    {
        return tileGameObject == null;
    }

    public override string ToString()
    {
        return x + ", " + y + "\n" + tileGameObject + "\n";
    }
}
