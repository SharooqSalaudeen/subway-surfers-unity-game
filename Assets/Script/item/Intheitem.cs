using UnityEngine;
using System.Collections;

public class Intheitem : MonoBehaviour {
   public GameObject con;
	// Use this for initialization
	void Start () {
    //    Destroy(this.gameObject,20);
        con = gameObject.transform.Find("conitem").gameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (con.gameObject !=  null)
        {
            con.transform.Rotate( new Vector3(0,0,50*Time.deltaTime));
        }
        if (Playermuving.isplay == false)
        {
            Destroy(this.gameObject);
        }

    }
}
