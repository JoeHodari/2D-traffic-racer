using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRoad : MonoBehaviour {

    public float scrollSpeed;

    private Vector2 offset;

    private void Update()
    {
        offset = new Vector2(0, Time.time * scrollSpeed); //params OsX, OsY

        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
