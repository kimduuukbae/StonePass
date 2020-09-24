using UnityEngine;
using System.Collections;

public class UpMiss : MonoBehaviour {

    float fDt = 0.0f;
    bool bPax_1 = false;
    bool bPax_2 = false;
    private Transform MyTransform;
    bool MoveEvent = false;
    public float Speed = 1.0f;
    Manager csManager = null;
	// Use this for initialization
	void Start () {
        csManager = GameObject.Find("Manager(Clone)").GetComponent<Manager>();
        MyTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateSpeed();
        if (MyTransform.position.x < -3.9f)
            MoveEvent = false;

        if (MyTransform.position.x > 3.9f)
            MoveEvent = true;

        fDt += Time.deltaTime * Speed;
        if (bPax_1 == false && bPax_2 == false)
        {
            if (MoveEvent == false)
            {
                MyTransform.Translate(0.0f, Random.Range(-3.0f, -5.0f) * Speed * Time.deltaTime, 0.0f);
            }
            else
            {
                MyTransform.Translate(0.0f, Random.Range(3.0f, 5.0f) * Speed * Time.deltaTime, 0.0f);
            }
        }
        if (fDt > 4.0f && bPax_1 == false && bPax_2 == false)
        {
            bPax_1 = true;
            fDt = 0.0f;
        }

        if (bPax_1 == true)
        {
            bPax_1Check();
        }
        if (bPax_2 == true)
        {
            bPax_2Check();
        }
	}


    void bPax_1Check()
    {
        fDt += Time.deltaTime;
        if (fDt > 1.0f)
        {
            MyTransform.Translate(14.0f * Speed * Time.deltaTime, 0.0f, 0.0f);
            if (MyTransform.position.y < 0.3f)
            {
                bPax_1 = false;
                bPax_2 = true;
                fDt = 0.0f;
            }
        }
        else
        {
            MyTransform.Translate(-4.0f * Speed * Time.deltaTime, 0.0f, 0.0f);
        }
    }
    void bPax_2Check()
    {
        MyTransform.Translate(-15.0f * Speed * Time.deltaTime, 0.0f, 0.0f);
        if (MyTransform.position.y > 14.38201f)
        {
            bPax_2 = false;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            GameObject.Find("ClareObject").GetComponent<ColliderScripts>().CheckCollider = true;
        }
    }
    void UpdateSpeed()
    {
        Speed = csManager.fSpeed;
    }
}
