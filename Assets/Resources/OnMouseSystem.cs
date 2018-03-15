using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseSystem : MonoBehaviour {

    private void OnMouseEnter()
    {
        print("Mouse In!");
    }

    private void OnMouseOver()
    {
        print("Mouse Over!");
    }

    private void OnMouseExit()
    {
        print("Mouse Out!");
    }

}
