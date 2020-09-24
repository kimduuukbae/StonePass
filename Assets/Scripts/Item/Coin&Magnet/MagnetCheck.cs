using UnityEngine;
using System.Collections;

public class MagnetCheck : MonoBehaviour {

    public bool bMangetCheck = false;
    Manager scMagnetCheck = null;
    float fDt = 0.0f;
	// Use this for initialization
	void Start () {
        scMagnetCheck = GameObject.Find("Manager(Clone)").GetComponent<Manager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (bMangetCheck == true)
        {
            if (scMagnetCheck.bStopMakeItem == false)
                scMagnetCheck.bStopMakeItem = true;
            else
            {
                fDt += Time.deltaTime;
                if (fDt > 2.0f)
                {
                    scMagnetCheck.bStopMakeItem = false;
                    Destroy(transform.gameObject);
                }
            }
        }
	}
}
