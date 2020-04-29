using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermiKontrolu : MonoBehaviour
{

    public float verdigiZarar = 20f;


    void carptigindaYolOl()
    {
        Destroy(gameObject);
    }

    public float zararVerme()
    {
        return verdigiZarar;
    }
}
