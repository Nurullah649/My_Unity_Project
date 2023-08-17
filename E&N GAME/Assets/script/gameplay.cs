using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class gameplay : MonoBehaviour
{
    int a;
    public GameObject[] fruit;
    static  GameObject[] points=new GameObject[60];
    public LayerMask mask1,mask2;
    bool isdragging=false;
    void Start()
    {
        for(int i = 0; i < points.Length; i++)
        {
            points[i] = GameObject.Find("point ("+i+")");
            a = UnityEngine.Random.Range(0, 7);
            points[i].GetComponent<SpriteRenderer>().sprite = fruit[a].GetComponent<SpriteRenderer>().sprite;
       
        }
        
    }
    
    void Update()
    {   
        Vector3 mousePositionInScreen = Input.mousePosition;
        mousePositionInScreen.z = 10;
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionInScreen);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0, mask1);
        if (Input.GetMouseButtonDown(0))
        {   
            isdragging = true;
            

            if (hit.collider != null)
            {
                hit.transform.position = mousePositionInWorld;
                Debug.Log(hit.transform.name);
                
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            isdragging = false;
        }
        if (isdragging==true)
        {
            mousePositionInScreen = Input.mousePosition;
            mousePositionInScreen.z = 10;

            mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionInScreen);

            hit.transform.position = mousePositionInWorld;
            
        }



    }
}
