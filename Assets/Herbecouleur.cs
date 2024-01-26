using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Herbemodif : MonoBehaviour
{

    public Tilemap interactiveTilemap; 
    public Tile newTile; 
    public TileBase originalTile;

    private Vector3Int lastPlayerCellPosition; 
    private bool tileChanged = false; 

    void Update()
    {
        Vector3Int playerCellPosition = interactiveTilemap.WorldToCell(transform.position);

   
        if (playerCellPosition != lastPlayerCellPosition)
        {
            if (tileChanged)
            {
                interactiveTilemap.SetTile(lastPlayerCellPosition, originalTile);
                tileChanged = false;
            }

            if (interactiveTilemap.GetTile(playerCellPosition) == originalTile)
            {
                interactiveTilemap.SetTile(playerCellPosition, newTile);
                tileChanged = true;
            }

            lastPlayerCellPosition = playerCellPosition;
        }
    }
}