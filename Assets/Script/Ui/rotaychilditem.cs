using UnityEngine;
using System.Collections;

public class rotaychilditem : MonoBehaviour {
    GameObject child;
    public bool istrue;
	// Use this for initialization
	void Start () {
        istrue = false;
        child = transform.Find("item").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (istrue)
        {
            if (Canvatbuyshop.openshopcharacter)
            {
            child.transform.Rotate(new Vector3(0,0,1.5f));
            }
            else
            {
                child.transform.Rotate(new Vector3(0, 0, 4));
            }
        }
	
	}
}

