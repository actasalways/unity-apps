using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuslamlarinCiktigiYer : MonoBehaviour
{

    public GameObject dusmanPrefabi;
    public float genislik = 15f;
    public float yukseklik = 6f;
    private float hiz = 4f;

    private bool SagaHareket = true;
    private float xmax;
    private float xmin;
    public float yaratmayiGeciktirmeSuresi = 0.5f;

    // Use this for initialization
    void Start()
    {
        float objeIleKameraninZsininfarki = transform.position.z - Camera.main.transform.position.z;
        Vector3 kameraninSolTarafi = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, objeIleKameraninZsininfarki));
        Vector3 kameraninSagTarafi = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, objeIleKameraninZsininfarki));
        xmax = kameraninSagTarafi.x;
        xmin = kameraninSolTarafi.x;

        DusmanlarinTekTekYaratilmasi();

    }

    void DusmanlarinYaratilmasi()
    {
        foreach (Transform cocuk in transform)
        {
            GameObject dusman = Instantiate(dusmanPrefabi, cocuk.transform.position, Quaternion.identity) as GameObject;
            dusman.transform.parent = cocuk;
        }
    }

    void DusmanlarinTekTekYaratilmasi()
    {
        Transform uygunPozisyon = sonrakiUygunPozisyon();
        if (uygunPozisyon)
        {
            GameObject dusman = Instantiate(dusmanPrefabi, uygunPozisyon.transform.position, Quaternion.identity) as GameObject;
            dusman.transform.parent = uygunPozisyon;
        }
        if (sonrakiUygunPozisyon())
        {
            Invoke("DusmanlarinTekTekYaratilmasi", yaratmayiGeciktirmeSuresi);
        }

    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(genislik, yukseklik));
    }

    // Update is called once per frame
    void Update()
    {
        if (SagaHareket)
        {
            //transform.position += new Vector3(hiz * Time.deltaTime, 0);
            transform.position += hiz * Vector3.right * Time.deltaTime;
        }
        else
        {
            transform.position += hiz * Vector3.left * Time.deltaTime;
        }

        float sagSinir = transform.position.x + genislik / 2;
        float solSinir = transform.position.x - genislik / 2;

        if (sagSinir > xmax)
        {
            SagaHareket = false;
        }
        else if (solSinir < xmin)
        {
            SagaHareket = true;
        }

        if (butunDusmanlarOlduMu())
        {
            DusmanlarinTekTekYaratilmasi();
        }

    }

    Transform sonrakiUygunPozisyon()
    {
        foreach (Transform cocuklarinPozisyonu in transform)
        {
            if (cocuklarinPozisyonu.childCount == 0)
            {
                return cocuklarinPozisyonu;
            }
        }

        return null;
    }

    bool butunDusmanlarOlduMu()
    {
        foreach (Transform cocuklarinPozisyonu in transform)
        {
            if (cocuklarinPozisyonu.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }


}

