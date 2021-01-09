using UnityEngine;
using System.Collections;

public class UiBoxEffct : MonoBehaviour {
    public GameObject intance;
    public Transform get;
	// Use this for initialization
	void Start () {
      
        if (this.gameObject.tag == "bum")
        {
            speedx = Random.Range(-15, 15);
            if (speedx <2 && speedx >-2)
            {
                speedx = 10;
            }
            speedy = Random.Range(-15, 15);
            if (speedy < 2 && speedy > -2)
            {
                speedy = 10;
            }
            Destroy(this.gameObject, 1.5f);
        }

    }
    float delay = 0.1f;
    float timer = 0;
    float speedx, speedy;
	// Update is called once per frame
	void Update () {
        if (this.gameObject.name == "imgshow")
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {

                GameObject effct = Instantiate(intance, transform.position,transform.rotation) as GameObject;
                effct.transform.parent = this.transform;
                timer = 0;
            }
        }

        if (this.gameObject.tag == "bum")
        {
            transform.Translate(new Vector2(speedx, speedy));
            // transform.Rotate(new Vector3(speedy, 0, 0));
        }

    }
}
