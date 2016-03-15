using UnityEngine;
using System.Collections;

public class Puzzle_swap : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    

    void OnMouseDown()
    {
        //カメラから見たオブジェクトの現在位置を画面位置座標に変換
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        //取得したscreenPointの値を変数に格納
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        

        //オブジェクトの座標からマウス位置(つまりクリックした位置)を引いている。
        //これでオブジェクトの位置とマウスクリックの位置の差が取得できる。
        //ドラッグで移動したときのずれを補正するための計算だと考えれば分かりやすい
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(x, y, screenPoint.z));

        
    }

    void OnMouseDrag()
    {
        //ドラッグ時のマウス位置を変数に格納
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        //Debug.Log(x.ToString() + " - " + y.ToString());

        //ドラッグ時のマウス位置をシーン上の3D空間の座標に変換する
        Vector3 currentScreenPoint = new Vector3(x, y, screenPoint.z);

        //上記にクリックした場所の差を足すことによって、オブジェクトを移動する座標位置を求める
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;

        //オブジェクトの位置を変更する
        transform.position = currentPosition;
    }

    public void OnMouseUp()
    {
           
    }
}
