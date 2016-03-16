using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
    private bool maguro;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        maguro = GetComponent<Collider2D>().gameObject.tag == "maguro";
        if (maguro)
        {
            Debug.Log("マグロおいしい");
            gameObject.SetActive(false);
        }
    }
}
