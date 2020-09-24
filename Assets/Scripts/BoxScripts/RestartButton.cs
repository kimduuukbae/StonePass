using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

    Manager scManager = null;
	// Use this for initialization
	void Start () {
        scManager = GameObject.Find("Manager(Clone)").GetComponent<Manager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        Application.LoadLevel("stGame");
        scManager.stExitSaveData = false;
        System.GC.Collect();
        Resources.UnloadUnusedAssets();
    }
}
