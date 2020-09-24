using UnityEngine;
using System.Collections;

public class InStageSabot : MonoBehaviour {

    float fDt = 0.0f;
	// Use this for initialization
	void Start () {
        transform.Translate(Random.Range(3.0f, -4.0f), Random.Range(3.0f, -3.0f), 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        fDt += Time.deltaTime;
        if ( fDt > 5.0f )
            Destroy(GameObject.Find("SabotObject(Clone)"));
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Sabot").GetComponent<It_Sabot>().bSabotCheck = true;
            GameObject.Find("CoolImage").GetComponent<CoolTimeSettings>().bSabotTime = true;
            other.gameObject.tag = "Sabotua";
            Destroy(transform.gameObject);
        }
    }
}
