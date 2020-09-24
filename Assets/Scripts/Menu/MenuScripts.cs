using UnityEngine;
using System.Collections;

public class MenuScripts : MonoBehaviour {

    bool bScriptCheck = false;
    bool bInOutCheck = false;
    float fDt = 0.0f;
	// Use this for initialization
	void Start () {
        bInOutCheck = GameObject.Find("Manager(Clone)").GetComponent<Manager>().bInOutTouch;
	}
	
	// Update is called once per frame
	void Update () {
        if (bInOutCheck == true)
        {
            if (bScriptCheck == false)
            {
                Destroy(GameObject.Find("In_Touch"));
                GameObject PrefapStage = Resources.Load("Prefabs/Out_Touch") as GameObject;
                Instantiate(PrefapStage, new Vector3(0.121842f, -0.338240f, 0.505840f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                GameObject.Find("Manager(Clone)").GetComponent<Manager>().bInOutTouch = true;
                bScriptCheck = true;
            }
        }
        else
        {
            fDt += Time.deltaTime;
            if (Input.anyKey && fDt > 2.5f)
            {
                bInOutCheck = true;
                fDt = 0.0f;
            }
        }
	}
}
