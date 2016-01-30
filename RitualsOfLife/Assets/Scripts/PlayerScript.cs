using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    [SerializeField]
    float acceleration = 10f;

    [SerializeField]
    Vector2 maxSpeed = new Vector2(5.0f, 5.0f);

    [SerializeField]
    float maxCameraAngle = 45.0f;

    [SerializeField]
    Image phoneImage;

    float phoneLook = 0.0f;

	// Use this for initialization
	void Start () {
	    
	}

    void Walking()
    {
        Vector2 maxSpeedUpdated = new Vector2(maxSpeed.x * Mathf.Abs(Input.GetAxis("LeftX")), maxSpeed.y * Mathf.Abs(1-Mathf.Clamp(Input.GetAxis("LeftY"), 0.0f, 1.0f)));

        Vector2 nextPos = Vector2.zero;

        if(Mathf.Abs(GetComponent<Rigidbody>().velocity.x) < maxSpeedUpdated.x)
            nextPos += new Vector2(Input.GetAxis("LeftX"), 0);

        if (GetComponent<Rigidbody>().velocity.z < maxSpeedUpdated.y)
            nextPos += new Vector2(0, 1-Mathf.Clamp(Input.GetAxis("LeftY"), 0.0f, 1.0f));
       

        GetComponent<Rigidbody>().AddForce(new Vector3(nextPos.x,0,nextPos.y) * acceleration * 100 * Time.deltaTime);
    }

    void PhoneActive()
    {
       // Debug.Log("PHONE!");
    }

    void Phone()
    {
        if (Input.GetAxis("LeftBump") < 1.0f && phoneLook < 1.0f)
        {
            phoneLook += Time.deltaTime;
            if (phoneLook > 1)
                phoneLook = 1;

            Camera.main.transform.Rotate((maxCameraAngle * phoneLook) - Camera.main.transform.rotation.eulerAngles.x, 0, 0);
            phoneImage.GetComponent<RectTransform>().anchoredPosition = Vector3.down * 1080 * (1-phoneLook);
        }

        if (Input.GetAxis("LeftBump") > 0.0f && phoneLook > 0.0f)
        {
            phoneLook -= Time.deltaTime;
            if (phoneLook < 0)
                phoneLook = 0;

            Camera.main.transform.Rotate((maxCameraAngle * phoneLook) - Camera.main.transform.rotation.eulerAngles.x, 0, 0);
            phoneImage.GetComponent<RectTransform>().anchoredPosition = Vector3.down * 1080 * (1-phoneLook);
        }
            
        if (phoneLook >= 1.0f)
            PhoneActive();
                    
    }


	// Update is called once per frame
	void Update () {

        Walking();

        Phone();
	}
}
