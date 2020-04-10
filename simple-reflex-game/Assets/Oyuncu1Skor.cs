using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyuncu1Skor : MonoBehaviour {

    public int skor1 = 0;

    public void skor1Guncelle()
    {
        GetComponent<TextMesh>().text = skor1.ToString();

    }

}
