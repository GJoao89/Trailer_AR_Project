using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowObject : MonoBehaviour
{
    public Material newMaterial;
    public float val = 1;
    float lerp = 0f, duration = 2.0f;
    
    // Start is called before the first frame update

    private void Start()
    {
        newMaterial = GetComponent<Renderer>().material;
        
    }

    public void Changematerial(float amount)
    {
        //Call this function from a button
        //newMaterial.SetFloat("GlowAmount_01234", amount);      
        lerp += Time.deltaTime / duration;
        var lerpAmt = Mathf.Lerp(val, amount, lerp);
        newMaterial.SetFloat("GlowAmount_01234", lerpAmt);
        StartCoroutine(ResetMaterial(amount));
    }

    public IEnumerator ResetMaterial (float amount)
    {
        yield return new WaitForSeconds(2.0f);
        //newMaterial.SetFloat("GlowAmount_01234", val);
        lerp = 0; 

        //put inside a while loop
        lerp += Time.deltaTime / duration;
        var lerpAmt = Mathf.Lerp(amount, val, lerp);
        newMaterial.SetFloat("GlowAmount_01234", lerpAmt);
    }
      
}
