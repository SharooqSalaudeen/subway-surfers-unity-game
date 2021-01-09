using UnityEngine;
using System.Collections;

public class Showandhide : MonoBehaviour {
    public GameObject MEnubuy;
    public GameObject thismenu;
    public GameObject player;
    public GameObject map;
    GameObject cam;
    // Use this for initialization
    void Start () {
	}
	public void backcameratobehigh()
    {
        MEnubuy.SetActive(true);
        thismenu.SetActive(false);
        Playermuving.player.OpenMenu3D();
        map.SetActive(false);
        cam = gameObject.transform.GetChild(2).gameObject;
        GetComponent<Animator>().enabled = false;
        cam.GetComponent<Camera>().orthographic = true;
        cam.GetComponent<Camera>().farClipPlane = 1.81f;
    }
    public void gotothemain()
    {
        #region MyRegion
        thismenu.SetActive(true);
        Playermuving.player.loadinganimation();
        MEnubuy.SetActive(false);
        map.SetActive(true);
        cam.GetComponent<Camera>().orthographic = false;
        cam.GetComponent<Camera>().farClipPlane = 100;
        transform.root.gameObject.GetComponent<Animator>().enabled = true;
        #endregion

    }

}
