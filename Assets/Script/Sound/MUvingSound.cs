using UnityEngine;
using System.Collections;

public class MUvingSound : MonoBehaviour {
    public GameObject head;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        //tauchetdi
        //if (other.gameObject.tag == "ship"&& other.gameObject.name == "tauchetdi")
        //{
        //    head = other.gameObject.transform.FindChild("tauchetdi").gameObject;
        //    if (head != null)
        //    {
        //        head.gameObject.GetComponent<AudioSource>().Play();
        //    }
        //}
    }
}
