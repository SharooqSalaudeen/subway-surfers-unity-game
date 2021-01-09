using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Delaystart : MonoBehaviour {
    public Text delaysecon;
    // Use this for initialization
    void Start () {
        delaysecon.text = delaysecons.ToString();
        delaysecons = 3;
    }


   public static int delaysecons = 3;
    public void showdelaytext()
    {
        delaysecon.text = delaysecons.ToString();
        delaysecons--;
        if (delaysecons ==0)
        {
            delaysecons = 3;
            GetComponent<Animator>().enabled = false;
            Time.timeScale = inthepanelpause.datatime;
            this.gameObject.SetActive(false);
        }
    }
    public void Getvalue()
    {
        delaysecon.text = delaysecons.ToString();

    }
}
