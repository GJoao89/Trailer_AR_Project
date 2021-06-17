using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowObject : MonoBehaviour
{
    public Material newMaterial;
    public float val;
    float lerp = 0f, duration = .5f;//duration is the length of the effect
    int pulseAmounts = 3;
    
    // Start is called before the first frame update

    private void Start()
    {
        newMaterial = GetComponent<Renderer>().material;
        
    }

    public void Changematerial(float amount)
    {
        /* //Call this function from a button
         //newMaterial.SetFloat("GlowAmount_01234", amount);      
         lerp += Time.deltaTime / duration;
         var lerpAmt = Mathf.Lerp(val, amount, lerp);
         newMaterial.SetFloat("GlowAmount_01234", lerpAmt);
         StartCoroutine(ResetMaterial(amount));
        */
        newMaterial.SetFloat("GlowAmount_01234", val);
        
            lerp = 0;
            StartCoroutine(GlowEffect(amount));
 
    }
  
    public IEnumerator GlowEffect(float amount)
    {
        for (int i = 0; i < pulseAmounts; i++)
        {
            lerp = 0;//reset lerp every itteration so that glowvalue resets
            float timePassed = 0;
            newMaterial.SetFloat("GlowAmount_01234", val);
            while (timePassed <= duration)//glow increases
            {
                lerp += Time.deltaTime / duration;
                var lerpAmt = Mathf.Lerp(val, -amount, lerp);//negitive sign on amount accouts for negitive glow values make
                //the material glow
                newMaterial.SetFloat("GlowAmount_01234", lerpAmt);
                yield return null;
                timePassed += Time.deltaTime;

            }
           
            yield return new WaitForSeconds(.5f);//pause with the max glow
            lerp = 0;

            //put inside a while loop
            timePassed = 0;//reset time passed for effect
            while (timePassed <= duration)//glow decreses
            {
                lerp += Time.deltaTime / duration;
                var lerpAmt = Mathf.Lerp(-amount, val, lerp);
                newMaterial.SetFloat("GlowAmount_01234", lerpAmt);
                yield return null;
                timePassed += Time.deltaTime;
            }
            newMaterial.SetFloat("GlowAmount_01234", val);
            yield return new WaitForSeconds(.2f);//pause with no glow
        }
    }
    /*public IEnumerator ResetMaterial (float amount)
    {
        yield return new WaitForSeconds(1.0f);
        //newMaterial.SetFloat("GlowAmount_01234", val);
        lerp = 0;

        //put inside a while loop
        float timePassed = 0;
        while (timePassed <= duration)
        {
            lerp += Time.deltaTime / duration;
            var lerpAmt = Mathf.Lerp(-amount, val, lerp);
            newMaterial.SetFloat("GlowAmount_01234", lerpAmt);
            Debug.Log("GLow amount fall: " + newMaterial.GetFloat("GlowAmount_01234"));
            yield return null;
            timePassed += Time.deltaTime;
        }
        newMaterial.SetFloat("GlowAmount_01234", val);
    }
      */
}
