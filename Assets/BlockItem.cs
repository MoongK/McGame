using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockItem : MonoBehaviour {

    GameObject myParent;
    GameObject backPack;

    private void Awake()
    {

        myParent = transform.parent.parent.gameObject;
        GetComponent<BoxCollider>().enabled = false;

        backPack = GameObject.Find("BagPool");
    }
    private void Update()
    {
    }

    public void DropItem()
    {
        Ray Mray = Camera.main.ScreenPointToRay(Input.mousePosition);

        transform.parent.SetParent(null);
        transform.parent.GetComponent<Rigidbody>().AddForce(Vector3.up * 120f);  // ForceUp
        //transform.parent.GetComponent<Rigidbody>().AddForce((Vector3.up + Mray.direction ) * 200f); // Force with direction
        GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(Wheeling());

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(Wheeling());

            GetComponent<BoxCollider>().enabled = false;
            transform.parent.SetParent(myParent.transform);
            backPack.GetComponent<BagPooler>().BagPooling(myParent);

            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            transform.parent.gameObject.SetActive(false);

        }
        
    }

    private IEnumerator Wheeling()
    {
        Vector3 upPos = transform.localPosition + Vector3.up * 0.2f;
        Vector3 downPos = transform.localPosition + Vector3.down * 0.2f;
        Vector3 dirPos = upPos;

        while (true)
        {
            if (transform.localPosition.y >= upPos.y)
                dirPos = downPos;
            else if(transform.localPosition.y <= downPos.y)
                dirPos = upPos;

            transform.Rotate(0f, 1f, 0f);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, dirPos, 0.01f);
            yield return null;
        }


    }

}
