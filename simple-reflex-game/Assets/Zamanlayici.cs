using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zamanlayici : MonoBehaviour {

    public float ilkBekleme = 3.0f;
    public float ikinciBekleme;
    public float toplamBekleme;
    public float oyunIcindeGecenSure;
    public float baslangicZamani = 0;
    public bool oyunBasladi = false;
    


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        oyunIcindeGecenSure = Time.time;
        if ((oyunIcindeGecenSure - baslangicZamani) > toplamBekleme && oyunBasladi)
        {
            print("butona bas");
            GameObject.Find("yesilKutu").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("kirmiziKutu").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("Simdi").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("Bekle").GetComponent<MeshRenderer>().enabled = false;

            GameObject.Find("Scriptler").GetComponent<Klayve_kontrolleri>().tumButonlarBasilabilir = true;

        }
	}

    public void zamanBelirle()
    {
        ikinciBekleme = Random.Range(3.0f, 10.0f);
        toplamBekleme = ilkBekleme + ikinciBekleme;
    }
     

}
