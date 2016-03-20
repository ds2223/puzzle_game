using UnityEngine;
using System.Collections;

public class Puzzle_swap : MonoBehaviour
{
    public GameObject holdObj;
    public float holdPositionX;
    public float holdPositionY;
    public float holdPositionZ;

    // Use this for initialization
    void Start()
    {

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
        }
    }

    private void LeftClick()
    {
        Vector3 tapPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y,6.9f);
        if (holdObj == null)
        {
            Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(tapPoint));
            if (col != null)
            {
                this.holdObj = col.gameObject;
                holdPositionX = this.holdObj.transform.position.x;
                holdPositionY = this.holdObj.transform.position.y;
                holdPositionZ = 0;
                holdObj.transform.position = Camera.main.ScreenToWorldPoint(tapPoint);
            }
        }

    }
    private void LeftDrag()
    {
        Vector3 tapPoint = Input.mousePosition;
        if (holdObj != null)
        {
            this.holdObj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(tapPoint.x, tapPoint.y, 1f));
            Collider2D[] colSet = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(new Vector3(tapPoint.x, tapPoint.y,1f)));
            if (colSet.Length > 1)
            {
                foreach (Collider2D col in colSet)
                {
                    if (!col.gameObject.Equals(this.holdObj))
                    {
                        float tmpPositionX = holdPositionX;
                        float tmpPositionY = holdPositionY;
                        float tmpPositionZ = holdPositionZ;
                        holdPositionX = col.gameObject.transform.position.x;
                        holdPositionY = col.gameObject.transform.position.y;
                        col.gameObject.transform.position = new Vector2(tmpPositionX, tmpPositionY);

                    }
                }
            }
        }
    }
    private void LeftUp()
    {
        Vector3 tapPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        if (holdObj != null)
        {
            holdObj.transform.position = new Vector2(holdPositionX, holdPositionY);
            holdObj = null;
        }
    }
}
