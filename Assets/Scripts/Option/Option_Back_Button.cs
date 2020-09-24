using UnityEngine;
using System.Collections;

public class Option_Back_Button : MonoBehaviour {

    GameObject CreditMenu = null;
	// Use this for initialization
	void Start () {
        CreditMenu = GameObject.Find("CreditMenu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        CreditMenu.transform.position = new Vector3(100.057151f, 39.77042f, -0.27f);
    }
}
