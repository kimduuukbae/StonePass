using UnityEngine;
using System.Collections;

public class Continue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
      
	}

    void OnClick()
    {
        Time.timeScale = 1.0f;
        GameObject.Find("Manager(Clone)").GetComponent<Manager>().fSpeed = 0.8f;
        GameObject.Find("Option").transform.position = new Vector3(151.0f, -10.0f, -5.36f);
    }
}
