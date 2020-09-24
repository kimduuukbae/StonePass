using UnityEngine;
using System.Collections;

public class RightMiss : MonoBehaviour
{

    float fDt = 0.0f;
    private Transform MyTransform;
    public float Speed = 1.0f;
    bool bPax_1 = false;
    bool bPax_2 = false;
    bool MoveEvent = false;
    Manager csManager = null;
    void Start()
    {
        csManager = GameObject.Find("Manager(Clone)").GetComponent<Manager>();
        MyTransform = transform;
    }
    void Update()
    {
        UpdateSpeed();
        if (MyTransform.position.y < -6.0f)
            MoveEvent = false;

        if (MyTransform.position.y > 5.0f)
            MoveEvent = true;

        fDt += Time.deltaTime * Speed;
        if (bPax_1 == false && bPax_2 == false)
        {
            if (MoveEvent == false)
                MyTransform.Translate(0.0f, 10.0f * Speed * Time.deltaTime, 0.0f);
            else
                MyTransform.Translate(0.0f, -10.0f * Speed * Time.deltaTime, 0.0f);
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
            MyTransform.Translate(8.0f * Speed * Time.deltaTime, 0.0f, 0.0f);
            if (MyTransform.position.x < 0.0f)
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
        MyTransform.Translate(-10.0f * Speed * Time.deltaTime, 0.0f, 0.0f);
        if (MyTransform.position.x > 8.205549f)
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
