﻿using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour {

    bool rotateCamera;
    bool moveCamera;
    GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        print(Camera.main.transform.eulerAngles.y);
        if (rotateCamera == true && Camera.main.transform.eulerAngles.y <= 180.0f)
        {
            Camera.main.transform.Rotate(0, 1.0f * Time.deltaTime * 40, 0);
        }
        else if (Camera.main.transform.eulerAngles.y >= 180.0f)
        {
            Camera.main.transform.eulerAngles = new Vector3(0, 180, 0);
            moveCamera = true;
            player.GetComponent<Rigidbody>().isKinematic = true;
            player.GetComponent<Collider>().enabled = false;
        }
        if (moveCamera == true && player.transform.position.z >=0)
        {
            player.transform.Translate(0, 0, -1.0f * Time.deltaTime * 3);
        }
	}
    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<CameraShake>().enabled = false;
        other.GetComponent<PlayerScript>().enabled = false;
        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Blur>().enabled = false;
        Camera.main.transform.Rotate(-45.0f, 0, 0);
        var phoneImage = other.GetComponent<PlayerScript>().phoneImage;
        phoneImage.GetComponent<RectTransform>().anchoredPosition = Vector3.down * 1080;
        rotateCamera = true;
        player = other.gameObject;
    }
}
