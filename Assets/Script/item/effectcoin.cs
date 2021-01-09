using UnityEngine;
using System.Collections;

public class effectcoin : MonoBehaviour {

	// Use this for initialization
	void Start () {
      Destroy(this.gameObject,0.3f);
        if (this.name != "bum2")
        {
            if (managerdata.manager.getsetting() == 1)
            {
                GetComponent<AudioSource>().pitch = Soundmanager.pitchsound;
                GetComponent<AudioSource>().Play();
            }
        }
      

    }
	
	// Update is called once per frame

}
