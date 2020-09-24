using UnityEngine;
using System.Collections;

public class InStageGuard : MonoBehaviour {

    float fDt = 0.0f;
    void Awake()
    {
        transform.Translate(Random.Range(3.0f, -4.0f), Random.Range(3.0f, -3.0f), 0.0f);
    }
	void Start () {
	}
	void Update () {
        fDt += Time.deltaTime;
        if (fDt > 5.0f)
        {
            Destroy(GameObject.Find("GuardObject(Clone)"));
        }
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Guard").GetComponent<Guard>().bGuardShow = true;
            GameObject.Find("CoolImage").GetComponent<CoolTimeSettings>().bGuardTime = true;
            GameObject.Find("HeroSprite").tag = "Finish";
            Destroy(transform.gameObject);
        }
    }
}
