using UnityEngine;
using System.Collections;

public class PhoneNeglectEffect : MonoBehaviour {
    public float bloomValue;
    public float maxBloomValue;
    public float bloomRange;
    public float blurValue1;
    public float maxBlur1;
    public float overlayValue;
    public float maxOverlay;
    public float speed;
    public float insaneValue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        maxOverlay = 0.02f * insaneValue;
        maxBloomValue = 0.01f * insaneValue;
        bloomRange = 0.01f * insaneValue;
        maxBlur1 = 0.02f * insaneValue;

        if (insaneValue != 0)
        {
            if (GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity <= (1*insaneValue))
            {
                bloomValue = bloomValue + maxBloomValue*Time.deltaTime*10;
                GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity = bloomValue;
            }
            if (GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize <= (0.2f*insaneValue))
            {
                blurValue1 = blurValue1 + maxBlur1;
                GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = blurValue1;
            }
            if (GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity <= (0.2f * insaneValue))
            {
                overlayValue = overlayValue + maxOverlay*Time.deltaTime;
                GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity = blurValue1;
            }
        }
        else if (insaneValue == 0)
        {
            if (GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity <= (1 * insaneValue))
            {
                bloomValue = bloomValue - maxBloomValue * Time.deltaTime * 10;
                GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity = bloomValue;
            }
            if (GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize <= (0.2f * insaneValue))
            {
                blurValue1 = blurValue1 - maxBlur1;
                GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = blurValue1;
            }
            if (GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity <= (0.2f * insaneValue))
            {
                overlayValue = overlayValue - maxOverlay * Time.deltaTime;
                GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity = blurValue1;
            }
        }
        if (insaneValue >= 4) GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = true;
        else GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = false;

    }
}
