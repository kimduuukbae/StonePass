using UnityEngine;
using System.Collections;

public class MouseScripts : MonoBehaviour {

    float Speed = 11.0f;
    public bool bOption = false;
    private Transform MyTransform;
    bool bHeroDead = false;
    Vector3 curAc;
    Vector3 curScreenSpace;
    Vector3 curPosition;
    Vector3 lastMousePosition;
	// Use this for initialization
	void Start () {
        curAc = Vector3.zero;
        bOption = GameObject.Find("Manager(Clone)").GetComponent<Manager>().ControllerCheck;
        MyTransform = transform;
        MyTransform.rigidbody.sleepAngularVelocity = 0.0f;
        MyTransform.rigidbody.sleepVelocity = 0.0f;
	}
	
	void Update () {
        if (Time.timeScale > 0.9f )
        {
            if (bHeroDead == false)
            {
                curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 12.0f);
                curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace);

                if (bOption == false)
                {
                    curAc.x = -Input.acceleration.y;
                    curAc.y = Input.acceleration.x + 0.5f;

                    if (curAc.sqrMagnitude > 1)
                        curAc.Normalize();

                    curAc *= Time.deltaTime;
                    MyTransform.Translate(curAc * Speed);
                }
                else
                {
                    dragObject();
                }

                NonOutObject();
            }
            else
            {
                MyTransform.Translate(0.0f, 0.0f, 0.1f);
                MyTransform.Rotate(0.0f, 0.0f, 10.0f);
            }
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (MyTransform.tag == "Sabotua")
        {
            if (other.transform.tag == "Miss")
            {
                Destroy(other.transform.gameObject);
                GameObject.Find("Sabot").GetComponent<It_Sabot>().num -= 1;
            }
        }
    }

    void NonOutObject()
    {
        if (MyTransform.position.y > 7.0f)
        {
            MyTransform.position = new Vector3(MyTransform.position.x, 6.99f, MyTransform.position.z);
        }
        if (MyTransform.position.y < -5.6f)
        {
            MyTransform.position = new Vector3(MyTransform.position.x, -5.59f, MyTransform.position.z);
        }
        if (MyTransform.position.x < -4.0f)
        {
            MyTransform.position = new Vector3(-3.99f, MyTransform.position.y, MyTransform.position.z);
        }
        if (MyTransform.position.x > 4.0f)
        {
            MyTransform.position = new Vector3(3.99f, MyTransform.position.y, MyTransform.position.z);
        }
    }

    void dragObject()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePosition = Input.mousePosition;
            }
            if (Input.mousePosition.x < lastMousePosition.x)
            {
                MyTransform.Translate((Vector3.right * (Input.mousePosition.x - lastMousePosition.x)) * 1.0f * Time.smoothDeltaTime);
            }
            if (Input.mousePosition.x > lastMousePosition.x)
            {
                MyTransform.Translate((Vector3.right * (Input.mousePosition.x - lastMousePosition.x )) * 1.0f * Time.smoothDeltaTime);
            }
            if (Input.mousePosition.y > lastMousePosition.y)
            {
                MyTransform.Translate((Vector3.up * (Input.mousePosition.y - lastMousePosition.y)) * 1.5f * Time.smoothDeltaTime);
            }
            if (Input.mousePosition.y < lastMousePosition.y)
            {
                MyTransform.Translate((Vector3.up * (Input.mousePosition.y - lastMousePosition.y)) * 1.5f * Time.smoothDeltaTime);
            }

            lastMousePosition = Input.mousePosition;
        }
    }

    /// <summary>
    /// @TRUE = DEAD , @FALSE = LIVE
    /// </summary>
    /// <param name="bSet"></param>
    public void SetHeroLive(bool bSet)
    {
        bHeroDead = bSet;
    }
    public bool GetHeroLive()
    {
        return bHeroDead;
    }
    public void ReturnHeroTag()
    {
        MyTransform.tag = "Player";
    }
}

