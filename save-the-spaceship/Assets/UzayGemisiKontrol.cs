using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisiKontrol : MonoBehaviour
{

    public float hiz = 10f;
    public float inceAyar = 0.7f;
    public GameObject Mermi;
    public float mermininHizi = 8f;
    public float can = 400f;
    public float atesEtmeAraligi = 0.3f;

    float xmin, xmax;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        mermiKontrolu carpanMermi = collision.gameObject.GetComponent<mermiKontrolu>();
        if (carpanMermi)
        {
            can -= carpanMermi.zararVerme();
            if (can <= 0)
            {
                Destroy(gameObject);
            }
        }
    }


    void Start()
    {
        float uzaklik = transform.position.z - Camera.main.transform.position.z;
        Vector3 solUc = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, uzaklik));
        Vector3 sagUc = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, uzaklik));
        xmin = solUc.x + inceAyar;
        xmax = sagUc.x - inceAyar;
    }

    void atesEtme()
    {
        GameObject gemimizinMermisi = Instantiate(Mermi, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        gemimizinMermisi.GetComponent<Rigidbody2D>().velocity = new Vector3(0, mermininHizi, 0);// y => merminin hızı
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("atesEtme", 0.000001f, atesEtmeAraligi);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("atesEtme");
        }

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
