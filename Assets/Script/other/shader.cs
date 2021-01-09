using UnityEngine;
using System.Collections;

public class shader : MonoBehaviour {
    public Transform playertaget;

	
	// Update is called once per frame
	void Update () {

        if (Playermuving.player)
        {
            if (Playermuving.player.transform.position.y >4f)
            {
                transform.position = new Vector3(playertaget.transform.position.x, 3.0f, playertaget.transform.position.z);
                
            }
            if ( (Playermuving.player.transform.position.y <= 4f))
            {
                transform.position = new Vector3(playertaget.transform.position.x, -0.15f, playertaget.transform.position.z);
            }
        }
    }
  
}
