using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    static public bool istrgger;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "points")
        {
            istrgger = true;
            Debug.Log("Çarptý amk");
        }
    }

}
