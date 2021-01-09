using UnityEngine;
using System.Collections;

public class Shipmuving : MonoBehaviour {
    Vector3 savetranform;
     GameObject con;
	// Use this for initialization
	void Start () {
        //   savetranform = transform.position;
        alowmuving = true;
        con = transform.Find("tauchetdi").gameObject;
    }
    bool alowmuving;
	// Update is called once per frame
	void Update () {
       
        if (Playermuving.player)
        {
            if (Playermuving.isplay)
            {
                if (Playermuving.player.gameObject.transform.position.z>transform.position.z-50&& 
                    Playermuving.player.gameObject.transform.position.z< transform.position.z + 80)
                {
                    if (Playermuving.speedmuving >10)
                    {
                        con.transform.Translate(new Vector3(0, 0, -10 * Time.deltaTime));
                    }
                }
                if (Vector3.Distance(transform.position, con.transform.position) > 45 ||
                    (Playermuving.player.gameObject.transform.position.z < transform.position.z + 80&& 
                    transform.position.z + 78< Playermuving.player.gameObject.transform.position.z)&&
                    transform.position.z+8<Playermuving.player.gameObject.transform.position.z)
                {
                    con.transform.position = transform.position;
                    // get Unity Debug
                }
            }
        }
        if (Playermuving.backnowmuvingship)
        {
           // con.transform.position = transform.position;
        }
	}

    bool alowcallgetposition = true;
    IEnumerator backtolas()
    {
        yield return new WaitForSeconds(3);
        if (transform.position.z + 100> savetranform.z)
        {
            transform.position = savetranform;
        }
        alowmuving = true;
        alowcallgetposition = true;
    }
}
