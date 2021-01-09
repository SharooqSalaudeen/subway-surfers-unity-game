using UnityEngine;
using System.Collections;

public class BollEffcts : MonoBehaviour {
    Material mt;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject,1f);
        mt = GetComponent<Material>();
	}
    float speed = 5;
	// Update is called once per frame
	void Update () {
        transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        transform.Rotate(new Vector3(5,5,5));
    }
}
