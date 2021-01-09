using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {
    bool rotaychidcoi;
   public  GameObject rotaychidcoimian;
    // Use this for initialization
    void Start () {
        rotaychidcoi = false;
        
        StartCoroutine(timer());
    }
	IEnumerator timer()
    {
        float ran = Random.Range(0, 1f);
        yield return new WaitForSeconds(ran);
        rotaychidcoi = true;
    }
	// Update is called once per frame
	void Update () {
        if (rotaychidcoi)
        {
            
            rotaychidcoimian.transform.Rotate(new Vector3(0, 150 * Time.deltaTime, 0));
        }
        if (Playermuving.player)
        {
            if (transform.position.z < Playermuving.player.transform.position.z - 10)
            {
              // Destroy(this.gameObject);
            }
        }
        if (Playermuving.isplay == false&&Playermuving.player.gameObject.transform.position.z >10)
        {
           Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "ship")
        {
          //  Destroy(this.gameObject);
        }
    }
}
