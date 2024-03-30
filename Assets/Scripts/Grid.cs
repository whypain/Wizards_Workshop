using System.Collections.Generic;
using UnityEngine;

public class Grid: MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Sprite _borderSprite;
    [SerializeField] private Transform _cam;

    private Dictionary<Vector2?, Tile> tiles;

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2?, Tile>();
        for (int x = 0; x <= _width; x++)
        {
            for (int y = 0; y <= _height; y++)
            {

                if (x == 0|| y == 0 || x == _width || y == _height)
                {
                    var spawnedBorder = Instantiate(_tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                    spawnedBorder.GetComponent<SpriteRenderer>().sprite = _borderSprite;
                    spawnedBorder.tag = "gridBorder";
                    spawnedBorder.name = $"Border ({x}, {y})";
                }

                else
                {
                    var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                    spawnedTile.name = $"Tile ({x}, {y})";
                    tiles[new Vector2(x, y)] = spawnedTile;

                }

            }
        }

        
    }


}
