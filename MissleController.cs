using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleController : MonoBehaviour
{
    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.name != "Floor")
        {
            Destroy(gameObject);
            //print(target.gameObject.transform.parent.gameObject.name);
            if (target.gameObject.name != "Wall"
                 &&  target.gameObject.transform.parent.gameObject.name != "StoneBlocks")
            {
                Destroy(target.gameObject);
            }
        }
    }
}
