using UnityEngine;
using System.Collections;

public class Option_Control_Touch : MonoBehaviour {
    Manager MotionManager = null;
	void Start () {
        MotionManager = GameObject.Find("Manager(Clone)").GetComponent<Manager>();

	    if (GameObject.Find("Manager(Clone)") != null)
        {
            if ( MotionManager.ControllerCheck == true)
                GameObject.Find("CheckBox").transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z - 0.3f);
        }
	}
	void Update () {
	
	}
    void OnClick()
    {
        GameObject.Find("CheckBox").transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z - 0.3f);
        GameObject.Find("Manager(Clone)").GetComponent<Manager>().ControllerCheck = true;
    }
}
