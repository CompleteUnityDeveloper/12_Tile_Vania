using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor; // so we can inherit from GridBrush 

[CustomGridBrush()] // required for brush to show at bottom-left of TilePalette
public class SmartBrush : GridBrush
{
    // Note manual has wrong parameter name grid instead of gridLayout!
    public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
    {
        Debug.Log("SmartBrush Paint called");
    }
}