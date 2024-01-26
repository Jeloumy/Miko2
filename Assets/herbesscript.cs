using UnityEngine;
using UnityEngine.Tilemaps;

public class herbescript : MonoBehaviour
{

    public Tilemap sourceTilemap; 
    public Tile newTile; 
    public TileBase tileToChange; 

    private Vector3Int lastTilePosition; 
    private TileBase originalTile; 

    void OnCollisionStay2D(Collision2D collision)
    {
        Vector3 hitPosition = Vector3.zero;
        foreach (ContactPoint2D hit in collision.contacts)
        {
            hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
            hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
            Vector3Int cellPosition = sourceTilemap.WorldToCell(hitPosition);

            TileBase currentTile = sourceTilemap.GetTile(cellPosition);
            if (currentTile == tileToChange)
            {
                if (cellPosition != lastTilePosition)
                {
                    RestoreTile();
                    originalTile = currentTile;
                    sourceTilemap.SetTile(cellPosition, newTile);
                    lastTilePosition = cellPosition;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        RestoreTile();
    }

    private void RestoreTile()
    {
        if (originalTile != null)
        {
            sourceTilemap.SetTile(lastTilePosition, originalTile);
            originalTile = null;
        }
    }
}
