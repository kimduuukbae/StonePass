using UnityEngine;
using System.Collections;

public class It_Score : MonoBehaviour {

    public bool bSetScoreTransform = false;
    float fDt = 0.0f;
    public float fScoreDeletePlane = 4.0f;
    float CoolTime = GameSateData.I.myData.manage.ItemTimeUpgradeLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (bSetScoreTransform)
        {
            if (transform.position.x > 7.2f)
            {
                transform.Translate(-0.1f, 0.0f, 0.0f);
            }

            fDt += Time.deltaTime;

            if (fDt > (fScoreDeletePlane + (CoolTime * 0.1f)))
            {
                fDt = 0.0f;
                GameObject.Find("Score").GetComponent<Score>().ScoreX = 1;
                Destroy(GameObject.Find("ScoreObject(Clone)"));
            }
        }
	}
}
