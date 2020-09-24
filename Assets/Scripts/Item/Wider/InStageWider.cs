using UnityEngine;
using System.Collections;

public class InStageWider : MonoBehaviour {
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
            Destroy(GameObject.Find("WiderObject(Clone)"));
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Finish")
        {
            GameObject.Find("BackGround").GetComponent<tk2dSprite>().color = new Color(0.298f, 0.29f, 0.6f);
            GameObject.Find("Manager(Clone)").GetComponent<Manager>().fSpeed = 0.25f;
            GameObject.Find("Wider").GetComponent<Wider>().bCheckWider = true;
            GameObject.Find("CoolImage").GetComponent<CoolTimeSettings>().bWiderTime = true;
            Destroy(transform.gameObject);
        }
    }
}
