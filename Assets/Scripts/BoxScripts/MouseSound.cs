using UnityEngine;
using System.Collections;

public class MouseSound : MonoBehaviour {
    ParticleManager scParMan = null;
	// Use this for initialization
	void Start () {

        scParMan = GameObject.Find("Main Camera").GetComponent<ParticleManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Coin")
        {
            scParMan.bParticle_Coin = true;
        }
    }
}
