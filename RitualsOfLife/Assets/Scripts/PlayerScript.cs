using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	
	}

    void Walking()
    {
        Vector2 nextPos = Vector2.zero;

        nextPos += new Vector2(Input.GetAxis("LeftX"), - Mathf.Clamp( Input.GetAxis("LeftY"), -1.0f, 0.0f) );

        GetComponent<Rigidbody>().AddForce(new Vector3(nextPos.x,0,nextPos.y)*1000*Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update () {

        Walking();
	}
}
