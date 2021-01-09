using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class openitrotxt : MonoBehaviour {
    public List<GameObject> text = new List<GameObject>();
    public GameObject load;
    public Animator amin;
	// Use this for initialization
	void Start () {
        amin = GetComponent<Animator>();
        foreach (Transform item in load.transform)
        {
            text.Add(item.gameObject);
        }
	
	}

    public void startopen()
    {
        StartCoroutine(Effcts());
    }

    IEnumerator Effcts()
    {
        for (int i = 0; i < text.Count; i++)
        {
            yield return new WaitForSeconds(0.05f);
            StartCoroutine(Effctsitem(text[i]));
        }
    }
    int x = 0;
    IEnumerator Effctsitem(GameObject oject)
    {
        x++;
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.001f);
            if (oject.transform.position.y < (Screen.height / 10) * 4)
            {
                oject.transform.Translate(0,15,0);
            }
            else
            {
                break;
            }
           
        }
        if (x== text.Count)
        {
            yield return new WaitForSeconds(1.5f);

            for (int i = 0; i < text.Count; i++)
            {
                yield return new WaitForSeconds(0.05f);
                StartCoroutine(Effctsback(text[i]));
            }
            amin.SetBool("exir", true);

        }

    }
    IEnumerator Effctsback(GameObject oject)
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
           
                oject.transform.Translate(-10, 0, 0);
            
        }
    }

    public void off()
    {
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
