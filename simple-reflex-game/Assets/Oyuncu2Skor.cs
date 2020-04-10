using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyuncu2Skor : MonoBehaviour {

    public int skor2 = 0;

    public void skor2Guncelle()
    {
        GetComponent<TextMesh>().text = skor2.ToString();

    }

}
