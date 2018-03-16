using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ExitButton : MonoBehaviour {

    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        button.onClick.AddListener(Exiting);
    }

    public void Exiting()
    {
        Application.Quit();
    }
}
