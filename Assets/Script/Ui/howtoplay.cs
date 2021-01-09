using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class howtoplay : MonoBehaviour {
    public GameObject howtostyle;
    public GameObject howtostylerotay;
    public static howtoplay Howtoplay;
    // Use this for initialization
    void Start () {
        Howtoplay = this;
        howtostyle = transform.Find("stylemuving").gameObject;
        howtostylerotay = howtostyle.transform.Find("img").gameObject;

    }
	public IEnumerator ringht()
    {
        howtostyle.transform.position = new Vector3(Screen.width/4- Screen.width / 4, Screen.height/2, 0);
        howtostylerotay.transform.eulerAngles = new Vector3(0,0,0);
        yield return new WaitForSeconds(0.001f);
        Color cl = new Color();
        cl.a = 1;
        cl.b = 1;
        cl.g = 1;
        cl.r = 1;
        for (int i = 0; i < 70; i++)
        {
            yield return new WaitForSeconds(0.004f);
            howtostyle.transform.Translate(new Vector3(20, 0, 0));
            cl.a -= 0.01f;
            howtostylerotay.gameObject.GetComponent<Image>().color = cl;
            if (Leftbol==false)
            {
                break;
            }
        }

    }
    public IEnumerator left()
    {
        Color cl = new Color();
        cl.a = 1;
        cl.b = 1;
        cl.g = 1;
        cl.r = 1;
        howtostyle.transform.position = new Vector3(Screen.width, Screen.height / 2, 0);
        howtostylerotay.transform.eulerAngles = new Vector3(0, 0, 180);
        yield return new WaitForSeconds(0.001f);
        for (int i = 0; i < 70; i++)
        {
            yield return new WaitForSeconds(0.004f);
            howtostyle.transform.Translate(new Vector3(-20, 0, 0));
            cl.a -= 0.01f;
            howtostylerotay.gameObject.GetComponent<Image>().color = cl;
            if (upbol == false)
            {
                break;
            }
        }
    }
    public IEnumerator up()
    {
        Color cl = new Color();
        cl.a = 1;
        cl.b = 1;
        cl.g = 1;
        cl.r = 1;
        howtostyle.transform.position = new Vector3(Screen.width/2, Screen.height / 2- Screen.height / 2, 0);
        howtostylerotay.transform.eulerAngles = new Vector3(0, 0, 90);
        yield return new WaitForSeconds(0.001f);
       
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.004f);
            howtostyle.transform.Translate(new Vector3(0, 20, 0));
            cl.a -= 0.01f;
            howtostylerotay.gameObject.GetComponent<Image>().color = cl;
        }
    }
    public IEnumerator down()
    {
        Color cl = new Color();
        cl.a = 1;
        cl.b = 1;
        cl.g = 1;
        cl.r = 1;
        howtostyle.transform.position = new Vector3(Screen.width / 2, Screen.height, 0);
        howtostylerotay.transform.eulerAngles = new Vector3(0, 0, -90);
        for (int i = 0; i < 100; i++)
        {
            cl.a -= 0.005f;
            howtostylerotay.gameObject.GetComponent<Image>().color = cl;
            yield return new WaitForSeconds(0.0015f);
            howtostyle.transform.Translate(new Vector3(0, -20, 0));
        }
        Time.timeScale = 0.8f;
        this.gameObject.SetActive(false);
    }
    bool rightbol = true;
    bool Leftbol = true;
    bool upbol = true;
    bool downbol = true;
    // Update is called once per frame
    void Update () {

        if (Makesupway.isnewgame)
        {
            if (Playermuving.isplay==true)
            {
                if (Playermuving.player.gameObject.transform.position.z>7.89f&& rightbol)
                {
                    rightbol = false;
                    StartCoroutine(ringht());
                }
                if (Playermuving.player.gameObject.transform.position.z > 28f && Leftbol)
                {
                    Leftbol = false;
                    StartCoroutine(left());
                }
                if (Playermuving.player.gameObject.transform.position.z > 40f && upbol)
                {
                    upbol = false;
                    StartCoroutine(up());
                }
                if (Playermuving.player.gameObject.transform.position.z > 55 && downbol)
                {
                    downbol = false;
                    StartCoroutine(down());
                }
            }
        }
        if (Playermuving.isplay==false)
        {
            this.gameObject.SetActive(false);
        }
	
	}
}
