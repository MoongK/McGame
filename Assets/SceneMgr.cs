using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneMgr : MonoBehaviour {

    Button Startbutton;

	void Start () {
        Startbutton = GameObject.Find("StartButton").GetComponent<Button>();
	}
	
	void Update () {
        Startbutton.onClick.AddListener(Starter);
	}

    private void Starter()
    {
        SceneManager.LoadScene("McPlayer");
    }
}
