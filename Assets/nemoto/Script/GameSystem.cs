using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSystem : MonoBehaviour
{
    private const int TileLineNum = 5;
    private const int TileColNum = 6;
    private const float TileWidth = 0.5f;
    private const float TileHeight = 0.5f;
    private const float FirstTilePosX = -1.5f;
    private const float FirstTilePosY = -2;

    public GameObject holdObj;
    public float holdPositionX;
    public float holdPositionY;
    private float z = 10f;
    private GameObject[,] tileSet;

    // Use this for initialization
    void Start()
    {
        SetTileSet();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LeftClick();
        }
        if (Input.GetMouseButton(0))
        {
            LeftDrag();
        }
        if (Input.GetMouseButtonUp(0))
        {
            LeftUp();
            DeleteMatchTile();
        }
    }

    private void LeftClick()
    {
        Vector3 tapPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, z);
        if (holdObj == null)
        {
            Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(tapPoint));
            if (col != null)
            {
                this.holdObj = col.gameObject;
                holdPositionX = this.holdObj.transform.position.x;
                holdPositionY = this.holdObj.transform.position.y;
                holdObj.transform.position = Camera.main.ScreenToWorldPoint(tapPoint);
            }
        }

    }
    private void LeftDrag()
    {
        Vector3 tapPoint = Input.mousePosition;
        if (holdObj != null)
        {
            this.holdObj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(tapPoint.x, tapPoint.y, z));
            Collider2D[] colSet = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(new Vector3(tapPoint.x, tapPoint.y, z)));
            if (colSet.Length > 1)
            {
                foreach (Collider2D col in colSet)
                {
                    if (!col.gameObject.Equals(this.holdObj))
                    {
                        float tmpPositionX = holdPositionX;
                        float tmpPositionY = holdPositionY;
                        holdPositionX = col.gameObject.transform.position.x;
                        holdPositionY = col.gameObject.transform.position.y;
                        col.gameObject.transform.position = new Vector3(tmpPositionX, tmpPositionY, z);
                    }
                }
            }
        }
    }
    private void LeftUp()
    {
        if (holdObj != null)
        {
            holdObj.transform.position = new Vector3(holdPositionX, holdPositionY, z);
            holdObj = null;
        }
    }
    private void SetTileSet()
    {
        GameObject[,] tileSet = new GameObject[TileLineNum, TileColNum];
        for (int i = 0; i < TileLineNum; i++)
        {
            for (int j = 0; j < TileColNum; j++)
            {
                Collider2D col = Physics2D.OverlapPoint(new Vector2(FirstTilePosX + TileWidth * j, FirstTilePosY + TileHeight * i));
                if ("tile".Equals(col.tag))
                {
                    tileSet[i, j] = col.gameObject;
                }
            }
        }

        this.tileSet = tileSet;
    }

    private void DeleteMatchTile()
    {
        for (int i = 0; i < TileLineNum; i++)
        {
            for (int j = 0; j < TileColNum - 1; j++)
            {
                try
                {
                    GameObject nowObj = this.tileSet[i, j];
                    GameObject nextObj = this.tileSet[i, j + 1];
                    SpriteRenderer nowRenderer = nowObj.GetComponent<SpriteRenderer>();
                    SpriteRenderer nextRenderer = nextObj.GetComponent<SpriteRenderer>();
                    Sprite nowSprite = nowRenderer.sprite;
                    Sprite nextSprite = nextRenderer.sprite;
                    if (nowSprite.Equals(nextSprite))
                    {
                        Destroy(nowObj);
                        Destroy(nextObj);
                    }
                }
                catch
                {
                }
            }
        }
    }
}