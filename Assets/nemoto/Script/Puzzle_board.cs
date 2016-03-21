using UnityEngine;
using Random = UnityEngine.Random;

public class Puzzle_board : MonoBehaviour
{

    //8*8のゲームボードを作るので縦の段を8、横の列を8
    public int columns = 8;
    public int rows = 8;

    public GameObject[] Tiles;
    private GameObject[,] instance;
    private int[,] tileTable;



    //オブジェクトの位置情報を保存する変数


    void PuzzleSetup()
    {
        //Boardというオブジェクトを作成し、transform情報をboardHolderに保存
        instance = new GameObject[columns, rows];
        //x = -1〜8をループ
        for (int x = 0; x < columns; x++)
        {
            //y = -1〜8をループ
            for (int y = 0; y < rows; y++)
            {
                //床をランダムで選択
                GameObject toInstantiate = Tiles[Random.Range(0, Tiles.Length)];
                //床or外壁を生成し、instance変数に格納
                instance[x, y] = Instantiate(toInstantiate, new Vector3(x, y, 0),
                    Quaternion.identity) as GameObject;
            }
        }
    }

    public void Start()
    {
        PuzzleSetup();
        DeleteMatchTile();
       
    }

    public void Update()
    {
        DeleteMatchTile();
        FallTile();
    }


    //パズルを消す処理
    public void DeleteMatchTile()
    {
        //横方向
        for (int x = 0; x < columns - 2; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                try
                {
                    GameObject first = instance[x, y];
                    GameObject second = instance[x + 1, y];
                    GameObject third = instance[x + 2, y];
                    SpriteRenderer firstRenderer = first.GetComponent<SpriteRenderer>();
                    SpriteRenderer secondRenderer = second.GetComponent<SpriteRenderer>();
                    SpriteRenderer thirdRenderer = third.GetComponent<SpriteRenderer>();
                    Sprite firstSprite = firstRenderer.sprite;
                    Sprite secondSprite = secondRenderer.sprite;
                    Sprite thirdSprite = thirdRenderer.sprite;
                    if (firstSprite.Equals(secondSprite) && secondSprite.Equals(thirdSprite))
                    {
                        Destroy(first);
                        Destroy(second);
                        Destroy(third);

                    }
                }
                catch
                {
                }
            }
        }

        //縦方向
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows - 2; y++)
            {
                try
                {
                    GameObject first = instance[x, y];
                    GameObject second = instance[x, y + 1];
                    GameObject third = instance[x + 2, y + 2];
                    SpriteRenderer firstRenderer = first.GetComponent<SpriteRenderer>();
                    SpriteRenderer secondRenderer = second.GetComponent<SpriteRenderer>();
                    SpriteRenderer thirdRenderer = third.GetComponent<SpriteRenderer>();
                    Sprite firstSprite = firstRenderer.sprite;
                    Sprite secondSprite = secondRenderer.sprite;
                    Sprite thirdSprite = thirdRenderer.sprite;
                    if (firstSprite.Equals(secondSprite) && secondSprite.Equals(thirdSprite))
                    {
                        Destroy(first);
                        Destroy(second);
                        Destroy(third);

                    }
                }
                catch
                {
                }
            }
        }
    }
    private void FallTile()
    {
        for (int x = 0; x < columns; x++)
        {
            for (int y = 1; y < rows; y++)
            {
                if (instance[x, y - 1] == null && instance[x, y] != null)
                {
                    GameObject obj = instance[x, y].gameObject;
                    obj.transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y - 1);
                    instance[x,y -1] = obj;
                    instance[x, y] = null;
                    y = 0;
                }
            }
        }
    }
}
