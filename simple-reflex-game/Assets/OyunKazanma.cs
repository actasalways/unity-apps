using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKazanma : MonoBehaviour {

    public int oyunSkorUstLimit = 4;


	void Update () {

		if(GameObject.Find("skor1").GetComponent<Oyuncu1Skor>().skor1 > oyunSkorUstLimit) // 1. oyuncu kazandıysa 
        {
            GameObject.Find("birinciOyuncuKazandi").GetComponent<MeshRenderer>().enabled = true;
        }
        if (GameObject.Find("skor2").GetComponent<Oyuncu2Skor>().skor2 > oyunSkorUstLimit) // 2. oyuncu kazandıysa 
        {
            GameObject.Find("ikinciOyuncuKazandi").GetComponent<MeshRenderer>().enabled = true;
        }

    }
}
