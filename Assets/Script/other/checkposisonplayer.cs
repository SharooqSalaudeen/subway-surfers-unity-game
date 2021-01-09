using UnityEngine;
using System.Collections;

public class checkposisonplayer : MonoBehaviour {
    public Transform taget;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Playermuving.isplay)
        {
            transform.position = new Vector3(transform.position.x, taget.transform.position.y, taget.position.z);
        }
    }
}
