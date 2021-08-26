using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridTilesSystem : MonoBehaviour
{
    private  Grid<Tiles> grid;
    private GameObject buildTransform; 
    private void Awake()
    {
        grid = new Grid<Tiles>(GameMenu.GridWidth, GameMenu.GridHeight, GameMenu.CellSize, GameMenu.OriginPosition, (Grid<Tiles> g, int x, int y) => new Tiles(g, x, y));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.GetXY(UtilsClass.GetMouseWorldPosition(), out int x, out int y);

            Tiles tiles = grid.GetGridObject(x, y);

            if (tiles != null && GameMenu.Instance().ClickButton != null)
            {
                buildTransform = Instantiate(GameMenu.Instance().ClickButton.TowerPrefab, grid.GetWorldPosition(x, y), Quaternion.identity);

                if (tiles.CanBuild() && GameMenu.Instance().MoneyValue >= buildTransform.GetComponent<Tower>().GetPrice())
                {
                    tiles.SetTransform(buildTransform);
                    GameMenu.Instance().MoneyValue -= buildTransform.GetComponent<Tower>().GetPrice();
                    GameMenu.Instance().PlaceTower();
                }
                else
                {
                    UtilsClass.CreateWorldTextPopup("Money Not Enough", UtilsClass.GetMouseWorldPosition(), 1f);
                    GameMenu.Instance().ClickButton = null;
                    Destroy(buildTransform);
                }
                Hover.Instance().Deactivate();
            }
        }
 
        if (Input.GetMouseButtonDown(1))
        {
            if (GameMenu.Instance().ClickButton != null)
            {
                UtilsClass.CreateWorldTextPopup("Cancel Build", UtilsClass.GetMouseWorldPosition(), 1f);
                GameMenu.Instance().ClickButton = null;
                Hover.Instance().Deactivate();
            }
        }
    }
}
