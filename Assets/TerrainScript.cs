using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TerrainScript : MonoBehaviour
{
    [SerializeField] public Tilemap Tiles;
    private Color color1 = Color.white;
    private Color color2 = new Vector4(100 / 255f, 55 / 255f, 115 / 255f, 255 / 255f);

    // Start is called before the first frame update
    void Start()
    {
        Tiles = GetComponent<Tilemap>();
        /*Tiles.color = color2;*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeColor(bool nether)
    {
        
        Tiles.color = Color.white;
        if (nether)
        {
            Tiles.color = color2;
            Debug.Log(nether);
        }
        else
        {
            Tiles.color = Color.white;
            Debug.Log(nether);
        }

    }

}

