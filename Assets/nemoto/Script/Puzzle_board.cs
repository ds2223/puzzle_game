using UnityEngine;
using Random = UnityEngine.Random;

public class Puzzle_board : MonoBehaviour
{

    //8*8のゲームボードを作るので縦の段を8、横の列を8
    public int columns = 8;
    public int rows = 8;

    public GameObject[] Tiles;
    private GameObject[,] instance;

    //オブジェクトの位置情報を保存する変数


    void PuzzleSetup()
    {
        //Boardというオブジェクトを作成し、transform情報をboardHolderに保存
        instance = new GameObject[columns,rows];
        //x = -1〜8をループ
        for (int x = 0; x < columns; x++)
        {
            //y = -1〜8をループ
            for (int y = 0; y < rows; y++)
            {
                //床をランダムで選択
                GameObject toInstantiate = Tiles[Random.Range(0, Tiles.Length)];
                //床or外壁を生成し、instance変数に格納
                instance[x, y] = Instantiate(toInstantiate, new Vector3(x,y, 0),
                    Quaternion.identity) as GameObject;  
            }   
        }
    }

    public void Start()
    {
        PuzzleSetup();
        Destroy(this.instance[2, 4]);
    }
}