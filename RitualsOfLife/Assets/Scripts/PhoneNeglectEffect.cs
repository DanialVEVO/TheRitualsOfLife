using UnityEngine;
using System.Collections;

public class PhoneNeglectEffect : MonoBehaviour {
    public float vignetteValue;
    public float maxVignette;
    public float bloomValue;
    public float maxBloomValue;
    public float bloomRange;
    public float blurValue1;
    public float blurValue2;
    public float maxBlur1;
    public float maxBlur2;
    public float speed;
    public float insaneValue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        maxVignette = 0.02f * insaneValue;
        maxBloomValue = 0.1f * insaneValue;
        bloomRange = 0.1f * insaneValue;
        maxBlur1 = 0.2f * insaneValue;
        
        speed = (0.3f * insaneValue)+0.5f;
        if (insaneValue != 0)
        {
            vignetteValue = Mathf.Sin(Time.time * speed) * maxVignette;
            vignetteValue = vignetteValue + maxVignette + 0.2f;
            GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>().intensity = vignetteValue;
            bloomValue = Mathf.Sin(Time.time * speed) * bloomRange;
            bloomValue = bloomValue + maxBloomValue;
            GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity = bloomValue;
            blurValue1 = Mathf.Sin(Time.time * speed) * maxBlur1;
            blurValue1 = blurValue1 + maxBlur1;
            GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = blurValue1;
        }
        else
        {
            GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>().intensity = 0;
            GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity = 0.02f;
            GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = 0;
        }
        if (insaneValue >= 4) GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = true;
        else GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = false;

    }
}
