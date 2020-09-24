using UnityEngine;
using System.Collections;

public class Wider : MonoBehaviour {

    public float fDt = 0.0f;
    public bool bCheckWider = false;
    float CoolTime = GameSateData.I.myData.manage.ItemTimeUpgradeLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (bCheckWider == true)
        {
            fDt += Time.deltaTime;
            if (fDt > (5.0f + (CoolTime * 0.1f )))
            {
                fDt = 0.0f;
                bCheckWider = false;
                GameObject.Find("BackGround").GetComponent<tk2dSprite>().color = new Color(1.0f, 1.0f, 1.0f);
                GameObject.Find("Manager(Clone)").GetComponent<Manager>().fSpeed = 0.8f;
                Destroy(GameObject.Find("WiderObject(Clone)"));
            }
        }
	}
}
