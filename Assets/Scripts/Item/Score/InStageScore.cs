using UnityEngine;
using System.Collections;

public class InStageScore : MonoBehaviour {
    float fDt = 0.0f;
	// Use this for initialization
   
	void Start () {
        transform.Translate(Random.Range(3.0f, -4.0f), Random.Range(3.0f, -3.0f), 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        fDt += Time.deltaTime;
        if (fDt > 5.0f)
        {
            Destroy(GameObject.Find("ScoreObject(Clone)"));
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Finish")
        {
            GameObject.Find("Score").GetComponent<Score>().ScoreX = 2;
            GameObject.Find("CoolImage").GetComponent<CoolTimeSettings>().bScoreTime = true;
            GameObject.Find("It_Score").GetComponent<It_Score>().bSetScoreTransform = true;
            Destroy(transform.gameObject);
        }
    }
}
