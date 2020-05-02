using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanKontrolu : MonoBehaviour
{
    public GameObject mermi;
    public float mermiHizi = 8f;
    public float can = 100f;
    public float saniyeBasinaMermiAtma = 0.6f;
    private SkorKontrolu skorKontrolu;
    public AudioClip AtesSesi, OlumSesi;

    public int skorDegeri = 200;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mermiKontrolu carpanMermi = collision.gameObject.GetComponent<mermiKontrolu>();
        if (carpanMermi)
        {
            can -= carpanMermi.zararVerme();
            if (can <= 0)
            {
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(OlumSesi,transform.position);
                skorKontrolu.skoruArttir(skorDegeri);
            }
        }
    }

    void atesEtme()
    {
        Vector3 baslangicPozisyonu = transform.position + new Vector3(0, -0.8f, 0);
        GameObject dusmaninMermisi = Instantiate(mermi, baslangicPozisyonu, Quaternion.identity) as GameObject;
        dusmaninMermisi.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -mermiHizi);
        AudioSource.PlayClipAtPoint(AtesSesi,transform.position);
    }

    private void Start()
    {
        skorKontrolu = GameObject.Find("Skor").GetComponent<SkorKontrolu>();

    }

    void Update()
    {
        float atmaOlasiligi = Time.deltaTime * saniyeBasinaMermiAtma;
        if (Random.value < atmaOlasiligi)
            atesEtme();
    }


}
