using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightSwitching : MonoBehaviour {

    GameObject Fps, Tps;
    bool isFps;

	void Awake () {
        Fps = GameObject.FindGameObjectWithTag("MainCamera");
        Tps = GameObject.FindGameObjectWithTag("TripleCam");
	}

    private void Start()
    {
        isFps = true;
        Fps.GetComponent<Camera>().depth = 1;
        Tps.GetComponent<Camera>().depth = 0;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (isFps)
            {
                Fps.GetComponent<Camera>().depth = 0;
                Tps.GetComponent<Camera>().depth = 1;
            
            }
            else
            {
                Fps.GetComponent<Camera>().depth = 1;
                Tps.GetComponent<Camera>().depth = 0;
            }
            isFps = !isFps;
        }
	}
}
