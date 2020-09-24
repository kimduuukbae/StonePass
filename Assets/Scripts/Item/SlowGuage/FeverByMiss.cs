using UnityEngine;
using System.Collections;

public class FeverByMiss : MonoBehaviour {
    FeverManager scFeverMng = null;
    Transform MyTransform;
    Manager MyManager = null;
    bool bSetSpeed = false;
    float fDt = 0.0f;
    float nPos = 0.0f;
    float PosY = 0.0f;
	// Use this for initialization
	void Start () {
        scFeverMng = GameObject.Find("Main Camera").GetComponent<FeverManager>();
        MyManager = GameObject.Find("Manager(Clone)").GetComponent<Manager>();
        MyTransform = transform;
	}

    // Update is called once per frame
    void Update()
    {
        if (scFeverMng.GetFeverMode() == true)
        {
            fDt += Time.deltaTime;
            if (fDt < 1.0f)
            {
                nPos += Time.deltaTime * 5.0f;
                PosY = Mathf.Sin(nPos * 10.0f) * Mathf.Pow(0.5f, nPos);
                MyTransform.position = new Vector3(MyTransform.position.x + PosY, MyTransform.position.y, MyTransform.position.z + PosY);
                if (scFeverMng.GetFeverSpeed() == false)
                {
                    scFeverMng.SetFeverSpeed(true);
                    MyManager.Set_Monster_Speed(0.0f);
                    Handheld.Vibrate();
                }

            }
            else
            {
                scFeverMng.SetFeverSpeed(false);
                MyManager.Return_Monster_Speed();
                MyManager.Return_Monster_Speed();
                GameObject.Find("FeverCoinObj").GetComponent<FeverObj>().SetActiveFeverCoin(true);
                scFeverMng.SetFeverMode(false);
                fDt = 0.0f;
                transform.gameObject.SetActiveRecursively(false);
            }
        }
	}
}
