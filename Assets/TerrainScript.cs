
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainScript : MonoBehaviour
{ 
    Tilemap[] Tiles;

    public void ChangeColour(bool nether)
    {
        Tiles = FindObjectsOfType<Tilemap>();
        foreach (var VARIABLE in Tiles)
        foreach (Vector3Int tilePosition in VARIABLE.cellBounds.allPositionsWithin) VARIABLE.RemoveTileFlags(tilePosition, TileFlags.LockColor);
        foreach (var variable in Tiles)
            if (nether) variable.color =new Vector4(100 / 255f, 55 / 255f, 115 / 255f, 255 / 255f);else variable.color = Color.white; 
    }
}

