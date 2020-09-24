using UnityEngine;
using System.Collections;

public class InStageMagnet : MonoBehaviour {
    float fDt = 0.0f;
	// Use this for initialization
    void Awake()
    {
        transform.Translate(Random.Range(3.0f, -4.0f), Random.Range(3.0f, -3.0f), 0.0f);
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        fDt += Time.deltaTime;
        if (fDt > 5.0f)
        {
            Destroy(GameObject.Find("MagnetObject(Clone)"));
        }
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Finish")
        {
            GameObject.Find("Magnet").GetComponent<MagnetCheck>().bMangetCheck = true;
            GameObject.Find("CoolImage").GetComponent<CoolTimeSettings>().bMagneTime = true;
            Destroy(transform.gameObject);
        }
    }
}
