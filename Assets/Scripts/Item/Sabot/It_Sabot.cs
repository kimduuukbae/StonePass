using UnityEngine;
using System.Collections;

public class It_Sabot : MonoBehaviour {

    public bool bSabotCheck = false;
    public int num = 2;
    float fDt = 0.0f;
    float CoolTime = GameSateData.I.myData.manage.ItemTimeUpgradeLevel;
    GameObject hHeroVector = null;
	// Use this for initialization
	void Start () {
        hHeroVector = GameObject.Find("HeroSprite");
	}
	
	// Update is called once per frame
	void Update () {
        if (bSabotCheck == true)
        {
            if (num <= 0 || fDt > ( 4.0f + ( CoolTime * 0.1f )))
            {
                hHeroVector.GetComponent<MouseScripts>().ReturnHeroTag();
                Destroy(GameObject.Find("SabotObject(Clone)"));
                GameObject.Find("Manager(Clone)").GetComponent<Manager>().CraetePrefabItem_Guard(hHeroVector.transform.position, true);
            }
            else
            {
                fDt += Time.deltaTime;
            }
        }
	}
}
