using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightSwitching : MonoBehaviour {

    GameObject Fps, Tps;
    bool isFps;

	void Awake () {
        Fps = GameObject.Find("FirstPersonCam");
        Tps = GameObject.Find("TriplePersonCam");
    }

    private void Start()
    {
        isFps = true;
        Fps.GetComponent<Camera>().depth = 1;
        Tps.GetComponent<Camera>().depth = 0;
        
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isFps = !isFps;

            if (isFps)
            {
                Fps.GetComponent<Camera>().depth = 1;
                Tps.GetComponent<Camera>().depth = 0;
                Fps.GetComponent<InteractionBlock>().enabled = true;
                Tps.GetComponent<InteractionBlock>().enabled = false;
                Fps.gameObject.tag = "MainCamera";
                Tps.gameObject.tag = "SecondCam";
                print("Fps Mode");

            }
            else
            {
                Fps.GetComponent<Camera>().depth = 0;
                Tps.GetComponent<Camera>().depth = 1;
                Fps.GetComponent<InteractionBlock>().enabled = false;
                Tps.GetComponent<InteractionBlock>().enabled = true;
                Fps.gameObject.tag = "SecondCam";
                Tps.gameObject.tag = "MainCamera";
                print("Tps Mode");
            }


        }

        //print(isFps);
    }
}
