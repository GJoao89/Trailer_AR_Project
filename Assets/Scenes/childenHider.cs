using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childenHider : MonoBehaviour
{
    public GameObject parent;
    // Start is called before the first frame update
    public void hideChildren()
    {
        Renderer[] rs = parent.GetComponentsInChildren<Renderer>();
        foreach(Renderer r in rs)
        {
            r.enabled = !r.enabled;
        }
    }
}
