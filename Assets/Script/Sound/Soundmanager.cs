using UnityEngine;
using System.Collections;

public class Soundmanager : MonoBehaviour {
    public GameObject backgrod;
    public GameObject police;
    public GameObject slide;
    public GameObject coin;
    public GameObject rung;
    public GameObject Getitem;
    public GameObject UIclick;
    public AudioSource Audiocoin;
    public GameObject PlayAgian;
    public GameObject newhighscore;
    public static Soundmanager soundmanager;
    // Use this for initialization
    void Start () {
        soundmanager = this;
        backgrod = gameObject.transform.Find("backgroud").gameObject;
        police = gameObject.transform.Find("police").gameObject;
        slide = gameObject.transform.Find("slide").gameObject;
        coin = gameObject.transform.Find("coin").gameObject;
        rung = gameObject.transform.Find("rung").gameObject;
        Getitem = gameObject.transform.Find("Getitem").gameObject;
        UIclick = gameObject.transform.Find("Uiclick").gameObject;
        PlayAgian = gameObject.transform.Find("PlayAgian").gameObject;
        newhighscore = gameObject.transform.Find("newhighscore").gameObject;
        backgrod.GetComponent<AudioSource>().Pause();
    }
    public void PlaynewHighscore()
    {
        if (managerdata.manager.getsetting() == 1)
        {
            newhighscore.GetComponent<AudioSource>().Play();
        }
    }
    public void PlayAgain()
    {
        if (managerdata.manager.getsetting() == 1)
        {
            PlayAgian.GetComponent<AudioSource>().Play();
        }
    } 

    public void PlayOnCoin()
    {
        AudioSource audio = new AudioSource();
        audio = coin.GetComponent<AudioSource>();
        audio.Play();

    }
    /// <summary>
    /// 
    /// </summary>
    public void OpenSoundClic()
    {
        if (managerdata.manager.getsetting() == 1)
        {
            UIclick.GetComponent<AudioSource>().Play();
        }
       
    }
    /// <summary>
    /// mở nhạc nền
    /// </summary>
	public void PlayBackgroudSound()
    {
    if (managerdata.manager.getsetting() == 1)
        {
            backgrod.GetComponent<AudioSource>().Play();
        }
        else if (managerdata.manager.getsetting() == 0)
        {
            backgrod.GetComponent<AudioSource>().Pause();
        }
    }
    public static float pitchsound = 0.75f;
    /// <summary>
    /// mở nhạc cảnh sat đuổi theo
    /// </summary>
    public void PlayPoliceSound()
    {
       if (managerdata.manager.getsetting() == 1)
        {
            police.GetComponent<AudioSource>().Play();

        }
    }
    /// <summary>
    /// bật âm thanh với coin hiệu ứng âm bổng dần
    /// </summary>
    public void PlayCoinSound()
    {
        if (managerdata.manager.getsetting() == 1)
        {
            pitchsound = pitchsound + 0.01f;
            if (pitchsound >= 1.3f)
            {
                pitchsound = 0.75f;
            }
        }
        
       
    }
    /// <summary>
    /// mở swipe
    /// </summary>
    public void PlaySwipe()
    {
        if (managerdata.manager.getsetting() == 1)
        {
            slide.GetComponent<AudioSource>().Play();
        }
    }
    /// <summary>
    /// rung camera
    /// </summary>
    public void Playruang()
    {
        if (managerdata.manager.getsetting() == 1)
        {
            rung.GetComponent<AudioSource>().Play();
        }
    }
    int countcall = 0;


    public void Getitemplay()
    {
        if (managerdata.manager.getsetting() == 1)
        {
            Getitem.GetComponent<AudioSource>().Play();
        }
    }

    public void Pause()
    {
        backgrod.GetComponent<AudioSource>().Pause();
        police.GetComponent<AudioSource>().Pause();


    }
    public void Continued()
    {
        if (managerdata.manager.getsetting() == 1)
        {
            backgrod.GetComponent<AudioSource>().Play();
        }
          
    }
}
