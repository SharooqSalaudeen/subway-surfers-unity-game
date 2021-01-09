using UnityEngine;
using System.Collections;

public class DonDestroi : MonoBehaviour {
    DonDestroi intance;
    // Use this for initialization
    void Start () {

        //DontDestroyOnLoad(this.gameObject);
    }//
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
