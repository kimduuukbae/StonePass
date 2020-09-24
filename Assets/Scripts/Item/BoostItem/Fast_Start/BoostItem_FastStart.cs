using UnityEngine;
using System.Collections;

public class BoostItem_FastStart : MonoBehaviour {

    GameObject goHeroVector = null;
	// Use this for initialization
	void Start () {
        goHeroVector = GameObject.Find("HeroSprite");

        if (GameSateData.I.myData.manage.FastStartUpgradeLevel > 0)
        {
            CreateGuard_Boost();
            CreateScore_Boost();
            GameSateData.I.myData.manage.FastStartUpgradeLevel -= 1;
            GameSateData.I.SaveData();

            transform.GetComponent<BoostItem_FastStart>().enabled = false;
        }
        else
        {
            transform.GetComponent<BoostItem_FastStart>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CreateGuard_Boost()
    {
        GameObject PrefapStage = Resources.Load("Prefabs/GuardObject") as GameObject;
        GameObject PrefabItem = Instantiate(PrefapStage, new Vector3(0.0f,-0.5f,30.58828f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as GameObject;

        PrefabItem.GetComponentInChildren<InStageGuard>().transform.position = new Vector3(goHeroVector.transform.position.x,goHeroVector.transform.position.y,goHeroVector.transform.position.z);
        PrefabItem.GetComponentInChildren<Guard>().bBoostItem = true;
    }
    void CreateScore_Boost()
    {
        GameObject PrefapStage = Resources.Load("Prefabs/ScoreObject") as GameObject;
        GameObject PrefabItem = Instantiate(PrefapStage, new Vector3(0.0f, -0.5f, 30.58828f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as GameObject;

        PrefabItem.GetComponentInChildren<InStageScore>().transform.position = new Vector3(goHeroVector.transform.position.x, goHeroVector.transform.position.y, goHeroVector.transform.position.z);
        PrefabItem.GetComponentInChildren<It_Score>().fScoreDeletePlane = 8.0f;
    }
}
