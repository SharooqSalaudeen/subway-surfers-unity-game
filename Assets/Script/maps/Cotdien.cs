using UnityEngine;
using System.Collections;

public class Cotdien : MonoBehaviour {
    public GameObject Child;
    float time;
    bool onoff;
	// Use this for initialization
	void Start () {
        Child = gameObject.transform.Find("cd").gameObject;

    }
	void OnOFF()
    {
        onoff = !onoff;
        if (onoff)
        {
            Child.SetActive(false);
        }
        else
        {
            Child.SetActive(true);
        }
    }
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >=0.5)
        {
            OnOFF();
            time = 0;
        }
	}
}
