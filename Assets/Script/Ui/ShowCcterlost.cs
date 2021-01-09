using UnityEngine;
using System.Collections;

public class ShowCcterlost : MonoBehaviour {
    bool intshow;
	// Use this for initialization
	void Awake () {
        intshow = false;

    }
    void Start()
    {
        intshow = true;
    }
    void OnEnable()
    {
        if (intshow)
        {
            UImanager.uimanager.ShowCharacterLost(true);
        }
    }
     void OnDisable()
    {
          UImanager.uimanager.ShowCharacterLost(false);
    } 
   
}
