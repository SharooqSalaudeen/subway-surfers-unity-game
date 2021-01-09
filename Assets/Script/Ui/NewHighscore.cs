using UnityEngine;
using System.Collections;
/// <summary>
/// class character điểm cao mới  , cho character chạy dần từ xa
/// </summary>
public class NewHighscore : MonoBehaviour {
    public static NewHighscore newhigh;
    public Transform getnewPosition;
    // Use this for initialization
    void Start () {
        
        //  transform.localPosition = new Vector3(5,2.3f,-8.9f);
        newhigh = this;

    }
	
	// Update is called once per frame
	void Update () {
        //  Debug.Log(transform.position);
        //  Debug.Log(transform.position.z - getnewPosition.position.z);
     //   Debug.Log(Vector3.Distance(transform.position, getnewPosition.position));
        if (Vector3.Distance(transform.position, getnewPosition.position) >1f)
        {
            transform.Translate(new Vector3(0, 0, -1f * Time.deltaTime));

        }
    }
    public void backtotranform()
    {
        transform.Translate(new Vector3(0, 0,0.6f));
    }
}
