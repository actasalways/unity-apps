using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuslamlarinCiktigiYer : MonoBehaviour {

    public GameObject dusmanPrefabi;

	// Use this for initialization
	void Start () {
        foreach(Transform cocuk in transform)
        {
            GameObject dusman = Instantiate(dusmanPrefabi, cocuk.transform.position, Quaternion.identity) as GameObject;
            dusman.transform.parent = cocuk;

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
