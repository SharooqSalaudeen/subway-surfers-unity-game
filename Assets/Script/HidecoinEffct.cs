using UnityEngine;
using System.Collections;

public class HidecoinEffct : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "hidecoin")
        {
            coll.gameObject.SetActive(false);
        }
    }
 
}
