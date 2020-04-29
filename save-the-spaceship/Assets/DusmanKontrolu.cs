using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanKontrolu : MonoBehaviour
{
    public GameObject mermi;
    public float mermiHizi = 8f;
    public float can = 100f;
    public float saniyeBasinaMermiAtma = 0.6f;

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

    void atesEtme()
    {
        Vector3 baslangicPozisyonu = transform.position + new Vector3(0, -0.8f, 0);
        GameObject dusmaninMermisi = Instantiate(mermi, baslangicPozisyonu, Quaternion.identity) as GameObject;
        dusmaninMermisi.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -mermiHizi);
    }

    void Update()
    {
        float atmaOlasiligi = Time.deltaTime * saniyeBasinaMermiAtma;
        if (Random.value < atmaOlasiligi)
            atesEtme();
    }


}
