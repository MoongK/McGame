using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldPooler : MonoBehaviour {

    public void Pooling(GameObject pooled_ob)
    {
        pooled_ob.transform.parent = transform;
        pooled_ob.transform.localPosition = Vector3.zero;
        pooled_ob.gameObject.SetActive(false);
    }
}
