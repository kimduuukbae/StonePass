using UnityEngine;
using System.Collections;

public class FeverManager : MonoBehaviour {

    bool bFeverMode = false;            //@ FALSE = NON FEVER | @ TRUE = FEVER
    bool bDestroyMessage = false;
    bool bFeverSpeed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (bDestroyMessage == true)
        {
            CreatePrefabDestroy();
            bFeverMode = true;
            bDestroyMessage = false;
        }
	}
    /// <summary>
    /// First Fever Check
    /// </summary>
    public void DestroyMessage()
    {
        bDestroyMessage = true;
    }
    ///<summary> 
    ///  @ FALSE = NOT FEVER | @ TRUE = FEVER
    ///</summary>
    public bool GetFeverMode()
    {
        return bFeverMode;
    }
    /// <summary>
    ///  SET FEVER MODE @ FALSE = NOT FEVER | @ TRUE = FEVER
    /// </summary>
    /// <param name="bSetMode"></param>
    public void SetFeverMode(bool bSetMode)
    {
        bFeverMode = bSetMode;
    }
    public void SetFeverSpeed(bool bFever)
    {
        bFeverSpeed = bFever;
    }
    public bool GetFeverSpeed()
    {
        return bFeverSpeed;
    }
    void CreatePrefabDestroy()
    {
        Instantiate(Resources.Load("Prefabs/DestroyMiss"), new Vector3(0.0f, 5.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
    }
}
