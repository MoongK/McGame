using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class In_InventoryMyBlock : MonoBehaviour {

    GameObject myBagPool;
    public int ItemCounter;
    string myTag;
    Text ButtonName;
    Text MyItemNum;

    private void Awake()
    {
        myTag = gameObject.tag;
        myBagPool = GameObject.FindGameObjectWithTag("BackPack");

        ButtonName = transform.Find("Name").GetComponent<Text>();
        MyItemNum = transform.Find("Num").GetComponent<Text>();
    }

    private void Update()
    {
        foreach(GameObject myOb in myBagPool.GetComponent<BagPooler>().itemInBag)
        {
            if (myOb.tag == myTag)
            {
                if (!myOb.GetComponent<BlockState>().isLinkedButton)
                {
                    myOb.GetComponent<BlockState>().isLinkedButton = true;
                    ItemCounter++;
                }
            }
        }

        MyItemNum.text = ItemCounter.ToString();
        ButtonName.text = gameObject.tag;
    }
}