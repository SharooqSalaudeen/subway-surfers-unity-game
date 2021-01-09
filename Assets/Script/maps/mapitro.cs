using UnityEngine;
using System.Collections;

public class mapitro : MonoBehaviour {
    public static mapitro instance;
    public GameObject muvingship, CSSidie, CSSrun;
    public GameObject mapitroativer;
	// Use this for initialization
	void Start () {
        instance = this;

    }
  public	void Muvingship()
    {
        CSSidie.SetActive(false);
        muvingship.GetComponent<ShipMuvinginItro>().enabled = true;
    }
	 public void HidemapItro()
    {
        mapitroativer.SetActive(false);
    }
}
