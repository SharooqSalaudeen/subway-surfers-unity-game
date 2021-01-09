using UnityEngine;
using System.Collections;

public class GoddCPUshow : MonoBehaviour {
    public GameObject   bumitem;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "bay" || coll.gameObject.tag == "baycao" || coll.gameObject.tag == "iteamgiay" || coll.gameObject.tag == "hopqua" || coll.gameObject.tag == "key" || coll.gameObject.tag == "namcham" || coll.gameObject.tag == "van"||coll.gameObject.tag == "x2coin")
        {
           // Instantiate(bumitem, coll.transform.position, transform.rotation);
            int load =  coll.gameObject.transform.GetChildCount();
            for (int i = 0; i < load; i++)
            {
                coll.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "bay" || coll.gameObject.tag == "baycao" || coll.gameObject.tag == "iteamgiay" || coll.gameObject.tag == "hopqua" || coll.gameObject.tag == "key" || coll.gameObject.tag == "namcham" || coll.gameObject.tag == "van")
        {
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "map")
        {
         //   coll.transform.root.gameObject.SetActive(false);
        }
    }
    
}
