using UnityEngine;
using System.Collections;

public class paintcans : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public GameObject PHUN;
    // Update is called once per frame
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "pain")
        {
            PHUN.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider coll)
    {

        if (coll.gameObject.name == "pain")
        {
            PHUN.gameObject.SetActive(false);
        }
    }

    }
