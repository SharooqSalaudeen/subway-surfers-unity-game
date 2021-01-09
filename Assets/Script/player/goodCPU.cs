using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class goodCPU : MonoBehaviour
{
    public GameObject bum,bumleft,bumright,bumitem;
    public static goodCPU intance;
    void Start()
    {
        intance = this;
    }
   public void GetStartrotay(bool value)
    {
        if (value)
        {
            this.GetComponent<BoxCollider>().enabled = true;
            Camerafolow.camfolowplayer.GetComponent<Camera>().farClipPlane = 100;
        }
        else
        {
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "hidecoin")
        {
            coll.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (coll.gameObject.tag == "coin")
            {
                coll.gameObject.GetComponent<Chekdestroi>().enabled = true;
                coll.transform.GetChild(0).gameObject.SetActive(true);
            if (coll.transform.position.x <-0.1f)
            {
                bumleft.SetActive(true);
                bumleft.transform.position = coll.transform.position;
            }
            if (coll.transform.position.x>0.1f)
            {
                bumright.SetActive(true);
                bumright.transform.position = coll.transform.position;
            }
            if (coll.transform.position.x<0.1f&& coll.transform.position.x>-0.1f)
            {
                bum.SetActive(true);
                bum.transform.position = coll.transform.position;
            }
            
            //Instantiate(bum, coll.transform.position, transform.rotation);
        }
     
        if (coll.gameObject.tag == "bay" || coll.gameObject.tag == "baycao" || coll.gameObject.tag == "iteamgiay" || coll.gameObject.tag == "hopqua" || coll.gameObject.tag == "key" || coll.gameObject.tag == "namcham" || coll.gameObject.tag == "van")
            {
                coll.gameObject.GetComponent<Intheitem>().enabled = true;
            }
       
       
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "coin"|| coll.gameObject.tag == "bay"|| coll.gameObject.tag == "baycao" || coll.gameObject.tag == "iteamgiay" || coll.gameObject.tag == "hopqua" || coll.gameObject.tag == "key" || coll.gameObject.tag == "namcham"|| coll.gameObject.tag == "van")
        {
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "die" || coll.gameObject.tag == "ship" || coll.gameObject.tag == "shipnotdie" || coll.gameObject.tag == "thanhchan" || coll.gameObject.tag == "cau" || coll.gameObject.tag == "taucat")
        {
            if (Playermuving.player.transform.position.z > 30)
            {
                if (coll.transform.root.gameObject.name != "map4"&&coll.transform.root.gameObject.name != "mainmap" && coll.transform.root.gameObject.name != "maphd")
                {
                    coll.transform.root.gameObject.SetActive(false);
                }

            }

        }
    }


}