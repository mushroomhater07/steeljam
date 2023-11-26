
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainScript : MonoBehaviour
{ 
    Tilemap[] Tiles;
    void Start()
    {
        Tiles = FindObjectsOfType<Tilemap>();
        foreach (var VARIABLE in Tiles)
        foreach (Vector3Int tilePosition in VARIABLE.cellBounds.allPositionsWithin)
            VARIABLE.RemoveTileFlags(tilePosition, TileFlags.LockColor);
    }

    public void ChangeColour(bool nether)
    {
        foreach (var VARIABLE in Tiles)
        {
           if (nether) VARIABLE.color =new Vector4(100 / 255f, 55 / 255f, 115 / 255f, 255 / 255f);
                   else VARIABLE.color = Color.white; 
        }
        
    }
}

