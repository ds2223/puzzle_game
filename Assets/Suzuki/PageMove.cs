using UnityEngine;
using System.Collections;

public class PageMove : MonoBehaviour {
    public GameObject inPagePos;
    public GameObject outPagePos;
    // Use this for initialization
    void Start () {

    }
	
    public void PageMove1()
    {

        transform.position = outPagePos.transform.position;
        GameObject target = GameObject.Find("Page2");
        target.transform.position = inPagePos.transform.position;
    }

    public void PageMove2()
    {

        transform.position = outPagePos.transform.position;
        GameObject target = GameObject.Find("Page1");
        target.transform.position = inPagePos.transform.position;
    }
}
