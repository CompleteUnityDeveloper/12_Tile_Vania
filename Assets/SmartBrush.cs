using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor; // so we can inherit from GridBrush 

// required for brush to show at bottom-left of TilePalette
// parameters restrict to just the SO brush

[CustomGridBrush(false, true, false, "Smart Brush")]

public class SmartBrush : GridBrush
{
    [SerializeField] TileBase[] randomTiles; // on Scriptable Object

    [MenuItem("Assets/Create/Brushes/SmartBrush")]
    public static void CreateBrush()
    {
        string path = EditorUtility.SaveFilePanelInProject(
            "Save Smart Brush",
            "New Smart Brush",
            "asset",
            "Save Smart Brush",
            "Assets/Brushes"
        ); // todo clarify why this list
        AssetDatabase.CreateAsset(CreateInstance<SmartBrush>(), path);
    }

    // Note manual has wrong parameter name grid instead of gridLayout!
    public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
    {
        var randomTile = randomTiles[(int)(randomTiles.Length * Random.value)];
        var tilemap = brushTarget.GetComponent<Tilemap>();
        tilemap.SetTile(position, randomTile);
    }
}