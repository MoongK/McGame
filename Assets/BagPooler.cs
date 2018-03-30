using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BagPooler : MonoBehaviour {

    public List<GameObject> itemInBag;

    private void Awake()
    {
        itemInBag = new List<GameObject>();
    }

    public void BagPooling(GameObject ob)
    {
        ob.transform.SetParent(transform);
        ob.SetActive(false);
        itemInBag.Add(ob);
    }

    void OutofBag(GameObject ob)
    {

    }
}