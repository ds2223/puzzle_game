using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    public Sprite[] tiles;

    // Use this for initialization
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        int test = Random.Range(0, 6);
        renderer.sprite = tiles[test];
    }
    // Update is called once per frame
    void Update()
    {

    }
}
