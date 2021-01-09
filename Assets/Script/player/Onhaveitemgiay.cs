using UnityEngine;
using System.Collections;
/// <summary>
/// xử lý tâng player lên khi có item giày
/// </summary>
public class Onhaveitemgiay : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag != "coin"&& coll.gameObject.tag != this.gameObject.tag)
        {
            if (Playermuving.isplay)
            {
 
                Playermuving.player.GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
                Physics.gravity = new Vector3(0, -15, 0);
            }
        }
     
    }

}
