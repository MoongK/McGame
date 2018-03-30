using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBlock : MonoBehaviour {

    public Object block;
    public int damagePow;
    int blockmask;

    GameObject worldPool;

    private void Start()
    {
        damagePow = 10;
        blockmask = 1 << LayerMask.NameToLayer("Block");

        worldPool = GameObject.Find("WorldPool");
    }

    void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        int ignoreMask = (1 << LayerMask.NameToLayer("ItemSkin")) | (1 << LayerMask.NameToLayer("Item"));
        ignoreMask = ~ignoreMask;
        
        if(Physics.Raycast(ray, out hit, 4f, ignoreMask))
        {
            if ((hit.collider.gameObject.layer == 9) && !(hit.collider.CompareTag("mantle")))
            {
                if (Input.GetMouseButton(0))
                    hit.transform.gameObject.GetComponent<BlockState>().Cracking();
                else
                    hit.transform.gameObject.GetComponent<BlockState>().Regeneration();
            }

            if (hit.collider.gameObject.layer == 15 /* planet*/)
            {
                if (Input.GetMouseButton(0))
                {
                    worldPool.GetComponent<WorldPooler>().Pooling(hit.transform.gameObject); // destroy
                }
                else
                    return;
            }
        }

        if (Physics.Raycast(ray, out hit, 4f, blockmask))
        {
            if (Input.GetMouseButtonDown(1)) {
                if (block != null)
                    MakeBlock(block, hit);
            }  
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
            block = Resources.Load("BlockInstance/DirtBlock");
        if(Input.GetKeyDown(KeyCode.Alpha2))
            block = Resources.Load("BlockInstance/StoneBlock");
        if(Input.GetKeyDown(KeyCode.Alpha3))
            block = Resources.Load("BlockInstance/HardBlock");
        if (Input.GetKeyDown(KeyCode.Alpha4))
            block = Resources.Load("BlockInstance/GrassBlock");
        if (Input.GetKeyDown(KeyCode.Alpha5))
            block = Resources.Load("BlockInstance/FlowerBlock");


        if (Input.GetKeyDown(KeyCode.Alpha0))
            block = null;
    }

    void MakeBlock(Object _block, RaycastHit _hit)
    {
        var tempBlock = Instantiate(_block);

        GameObject Blocking;
        Blocking = tempBlock as GameObject;
        Blocking.transform.position = _hit.transform.position + _hit.normal;
        Blocking.transform.rotation = Quaternion.identity;
    }
}
