using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;

public class SubLights : MonoBehaviour
{

    public Light[] lights;

    public Material yellowMaterial;
    public Material redMaterial;
    public Material offMaterial;

    public float FlickerDelay = 0.3f;
    private Material currentMat;

    private bool continueFlicker = true;


    [YarnCommand("light_flicker")]
    public void LightFlicker(bool enable)
    {
        if (enable)
        {
            continueFlicker = true;
            StartCoroutine(Flicker());
            
        }
        else
        {
            continueFlicker = false;
            StopCoroutine(Flicker());
        }
        
    }

    [YarnCommand("set_light_color")]
    public void ChangeLightColor(string newColor)
    {
        switch (newColor)
        {
            case "yellow":
                foreach(Light light in lights)
                {
                    currentMat = yellowMaterial;
                    light.color = Color.yellow;
                    light.gameObject.GetComponentInParent<Renderer>().material = currentMat;
                }
            break;
            case "red":
                foreach(Light light in lights)
                {
                    currentMat = redMaterial;
                    light.color = Color.red;
                    light.gameObject.GetComponentInParent<Renderer>().material = currentMat;
                    
                }
            break;
            default:
                Debug.LogError("Color not recognized in yarn script");
            break;
        }
        
    }


    private IEnumerator Flicker()
    {
        while(continueFlicker){
            foreach(Light light in lights)
            {
                light.enabled = false;
                light.gameObject.GetComponentInParent<Renderer>().material = offMaterial;
            }
            yield return new WaitForSeconds(FlickerDelay);
                    foreach(Light light in lights)
            {
                light.enabled = true;
                light.gameObject.GetComponentInParent<Renderer>().material = currentMat;
            }
            yield return new WaitForSeconds(FlickerDelay);
        }
    }
}
