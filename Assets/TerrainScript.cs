using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainScript : MonoBehaviour
{
    [SerializeField] public Tilemap Tiles;
    private Color color1 = new Vector4(1, 1, 1, 1);
    private Color color2 = new Vector4(100 / 255f, 55 / 255f, 115 / 255f, 255 / 255f);

    // Start is called before the first frame update
    void Start()
    {
        Tiles = GetComponent<Tilemap>();
        Tiles.color = color2;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
