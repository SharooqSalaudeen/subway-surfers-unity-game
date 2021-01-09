using UnityEngine;
using System.Collections;

public class ShipMuvinginItro : MonoBehaviour {
    float speed = 10;
	// Use this for initialization
	void Start () {
        if (this.gameObject.name == "Shipmuvingright")
        {
            speed = -10;
        }
        if (this.gameObject.name == "Shipmuvingleft")
        {
            speed = 10;
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0,0, speed * Time.deltaTime);
        if (transform.position.x >=10)
        {
            transform.position = new Vector3(transform.position.x - 100,transform.position.y,transform.position.z);

        }
      

    }
}
