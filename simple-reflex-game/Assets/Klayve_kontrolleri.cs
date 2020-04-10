using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klayve_kontrolleri : MonoBehaviour {

    public bool oyuncu1Kazan = false;
    public bool oyuncu2Kazan = false;
    public bool tumButonlarBasilabilir = false;


    void Start () {
        GameObject.Find("yesilKutu").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("kirmiziKutu").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("sariKutu").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("Simdi").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Bekle").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Hazir").GetComponent<MeshRenderer>().enabled = true;

    }

    // Update is called once per 
    void Update () {

        //oyuncu1
        if (Input.GetKeyDown(KeyCode.Z) && !oyuncu2Kazan && !oyuncu1Kazan && tumButonlarBasilabilir)
        {
            //print("z ye basıldı");
            GameObject.Find("skor1").GetComponent<Oyuncu1Skor>().skor1 += 1;
            GameObject.Find("skor1").GetComponent<Oyuncu1Skor>().skor1Guncelle();
            //GameObject.Find("birinciOyuncuKazandi").GetComponent<MeshRenderer>().enabled = true;
            oyuncu1Kazan = true; // 1. oyuncu önce bastı
        }
        
        //oyuncu2
        if (Input.GetKeyDown(KeyCode.M) && !oyuncu1Kazan && !oyuncu2Kazan && tumButonlarBasilabilir)
        {
            //print("m ye basıldı");
            GameObject.Find("skor2").GetComponent<Oyuncu2Skor>().skor2 += 1;
            GameObject.Find("skor2").GetComponent<Oyuncu2Skor>().skor2Guncelle();
            //GameObject.Find("ikinciOyuncuKazandi").GetComponent<MeshRenderer>().enabled = true;
            oyuncu2Kazan = true; // 2. oyuncu önce bastı

        }

        //başlat
        if (Input.GetKeyDown(KeyCode.P))
        {
            //print("p ye basıldı");
            GameObject.Find("yesilKutu").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("kirmiziKutu").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("sariKutu").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("Simdi").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("Bekle").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("Hazir").GetComponent<MeshRenderer>().enabled = false;

            GameObject.Find("birinciOyuncuKazandi").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("ikinciOyuncuKazandi").GetComponent<MeshRenderer>().enabled = false;

            oyuncu1Kazan = false;
            oyuncu2Kazan = false;

            GetComponent<Zamanlayici>().ilkBekleme = 3.0f;
            GetComponent<Zamanlayici>().ikinciBekleme = 0.0f;
            GetComponent<Zamanlayici>().toplamBekleme = 0.0f;

            GetComponent<Zamanlayici>().zamanBelirle();
            GetComponent<Zamanlayici>().baslangicZamani = GetComponent<Zamanlayici>().oyunIcindeGecenSure;

            GetComponent<Zamanlayici>().oyunBasladi = true;
            tumButonlarBasilabilir = false;

        }


        //reset
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //print("y ye basıldı");
            GameObject.Find("skor1").GetComponent<Oyuncu1Skor>().skor1 = 0;
            GameObject.Find("skor1").GetComponent<Oyuncu1Skor>().skor1Guncelle();
            GameObject.Find("skor2").GetComponent<Oyuncu2Skor>().skor2 = 0;
            GameObject.Find("skor2").GetComponent<Oyuncu2Skor>().skor2Guncelle();
            GameObject.Find("sariKutu").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("kirmiziKutu").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("Hazir").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("Bekle").GetComponent<MeshRenderer>().enabled = false;

            GameObject.Find("birinciOyuncuKazandi").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("ikinciOyuncuKazandi").GetComponent<MeshRenderer>().enabled = false;

            oyuncu1Kazan = false;
            oyuncu2Kazan = false;

            GetComponent<Zamanlayici>().baslangicZamani = GetComponent<Zamanlayici>().oyunIcindeGecenSure;
            tumButonlarBasilabilir = false;
            GetComponent<Zamanlayici>().oyunBasladi = false;


        }


    }
}
