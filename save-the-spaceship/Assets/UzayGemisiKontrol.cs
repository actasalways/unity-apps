using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisiKontrol : MonoBehaviour {

    public float hiz = 10f;
    public float inceAyar = 0.7f;
    float xmin,xmax;

    void Start(){
        float uzaklik = transform.position.z - Camera.main.transform.position.z;
        Vector3 solUc = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, uzaklik));
        Vector3 sagUc = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, uzaklik));
        xmin = solUc.x + inceAyar;
        xmax = sagUc.x - inceAyar;


    }

    void Update () {
        //geminin x teki sınırları
        float yeniX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(yeniX, transform.position.y, transform.position.z);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position += new Vector3(-hiz*Time.deltaTime,0,0);
            //Vector3.left -> (-1,0,0)
            transform.position += Vector3.left * hiz * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += new Vector3(hiz * Time.deltaTime, 0, 0);
            transform.position += Vector3.right * hiz * Time.deltaTime;

        }

    }
}
