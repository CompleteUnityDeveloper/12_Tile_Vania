using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSetup : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        SetupCommonLayers();
        // could serialise and specialise certain layers too
    }

    private void SetupCommonLayers()
    {
        foreach (Transform child in transform)
        {
            AddCommonComponent(child.gameObject);
        }
    }

    private void AddCommonComponent(GameObject child)
    {
        child.AddComponent(typeof(TilemapCollider2D));

        var myRb = child.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        myRb.bodyType = RigidbodyType2D.Static;

        child.AddComponent(typeof(CompositeCollider2D));
    }
}
