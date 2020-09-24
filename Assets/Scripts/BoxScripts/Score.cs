using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    UILabel Uiimage = null;
    GameObject PrefapStage = null;
    Manager scManager = null;
    MouseScripts goHero = null;
    public int num = 1;
    public int nSetDifficult = 1;
    public int ScoreX = 1;
    float fDt = 0.0f;
    int nPrefabNumber = 0;
    bool Prefab = false;
	// Use this for initialization
	void Start () {
        Uiimage = transform.GetComponent<UILabel>();
        scManager = GameObject.Find("Manager(Clone)").GetComponent<Manager>();
        goHero = GameObject.Find("HeroSprite").GetComponent<MouseScripts>();
        Prefab = false;
        num = 1;
	}
	// Update is called once per frame
	void Update () {
        if (goHero.GetHeroLive() == false)
        {
            fDt += Time.deltaTime;
            Uiimage.text = num.ToString();
            if (nSetDifficult > 1000)
            {
                Prefab = true;
                nSetDifficult = 1;
                CreatePrefabSpeedUp();
                scManager.fSpeed += 0.05f;
                scManager.fSaveMonsterSpeed += 0.05f;
            }
            if (fDt > 0.01f)
            {
                num += 1 * ScoreX;
                nSetDifficult += 1 * ScoreX;
                fDt = 0.0f;
                scManager.Score = num;
            }
            if (Prefab == true)
            {
                CraetePrefabStage();
                Prefab = false;
            }
        }
	}

    void CraetePrefabStage()
    {
        nPrefabNumber += 1;
        PrefapStage = Resources.Load("Prefabs/ClareObject_" + nPrefabNumber) as GameObject;
        Instantiate(PrefapStage, PrefapStage.transform.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

        if (nPrefabNumber == 2)
            nPrefabNumber = 0;
    }
    void CreatePrefabSpeedUp()
    {
        Instantiate(Resources.Load("Prefabs/SpeedUp"), new Vector3(0.0f,5.0f,0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
    }
}
