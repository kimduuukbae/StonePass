using UnityEngine;
using System.Collections;

public class ColliderScripts : MonoBehaviour {

    public bool CheckCollider = false;
    bool CheckfDt = false;
    float fDt = 0.0f;
    GameObject goDiePart = null;
    MouseScripts HeroSP = null;
    Transform MainCamera = null;
    float PosY = 0.0f;
    float PosY_MainCamera = 0.0f;
    float nPos = 0.0f;

	// Use this for initialization
	void Start () {
        HeroSP = GameObject.Find("HeroSprite").GetComponent<MouseScripts>();
        goDiePart = GameObject.Find("Die_Sprite");
        MainCamera = GameObject.Find("Main Camera").transform;
        goDiePart.gameObject.SetActiveRecursively(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (CheckCollider == true)
        {
            HeroSP.SetHeroLive(true);
            goDiePart.gameObject.SetActiveRecursively(true);
            goDiePart.transform.position = new Vector3(HeroSP.transform.position.x , HeroSP.transform.position.y , HeroSP.transform.position.z);
            CheckCollider = false;
            CheckfDt = true;
            Time.timeScale = 0.2f;
            PosY_MainCamera = MainCamera.position.y;
            Handheld.Vibrate();
        }
        if (CheckfDt == true)
        {
            nPos += Time.deltaTime * 10.0f;
            PosY = Mathf.Sin(nPos * 10.0f) * Mathf.Pow(1.5f, nPos);
            MainCamera.position = new Vector3(MainCamera.position.x, PosY_MainCamera + PosY, MainCamera.position.z);
            fDt += Time.deltaTime;
        }

        if (fDt > 0.3f)
        {
            if (Time.timeScale < 0.9f)
                Time.timeScale = 1.0f;
        }

        if (fDt > 1.5f)
            Application.LoadLevel("stExit");
	}
}
