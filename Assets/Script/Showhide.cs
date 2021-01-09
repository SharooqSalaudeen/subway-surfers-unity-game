using UnityEngine;
using System.Collections;

public class Showhide : MonoBehaviour {

    void OnBecameVisible()
    {
        Debug.Log("lock here");
       this.enabled = true;
    }
    void OnBecameInvisible()
    {
     //   Debug.Log(" ! here");

        this.enabled = false;
    }
}
