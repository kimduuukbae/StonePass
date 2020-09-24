using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

    public int Score = 1;
    int nTempleRank = 0;
    public float fCoinNum = 0;
    public bool bStopMakeItem = false;
    public bool ControllerCheck = false;
    public bool bInOutTouch = false;
    public float fSpeed = 0.7f;
    public bool stExitSaveData = false;
    int[] nArrayTemple = new int[6];
    

    float ItemShowTime = 0.0f;
    // Item ////////////////
    float fDtPlane;
    float fWiderPlane;
    float fScorePlane;
    float fSabotPlane;
    float fItemPlane;
    float fMagPlane;

    float fDt = 0.0f;
    float fMagnet = 0.0f;
    float fWider = 0.0f;
    float fScore = 0.0f;
    float fSabot = 0.0f;
    float fItem = 0.0f;
    /////////////////////////

    public MouseScripts LiveHero = null;
    public float fSaveMonsterSpeed = 0.0f;

    void Awake()
    {
        useGUILayout = false;
        Screen.SetResolution(480, 800, true);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
	void Start () {
        DontDestroyOnLoad(this);

        fDtPlane = Random.Range(10.0f, 18.0f);
        fWiderPlane = Random.Range(15.0f, 25.0f);
        fScorePlane = Random.Range(12.0f, 24.0f);
        fSabotPlane = Random.Range(20.0f, 40.0f);
        fMagPlane = Random.Range(15.0f, 20.0f);

        GameSateData.I.LoadData();

        if ( GameSateData.I.myData.manage.bGiftCoin == false )
        {
            fCoinNum = 10000;
            GameSateData.I.myData.manage.bGiftCoin = true;
        }
        else
            fCoinNum = GameSateData.I.myData.manage.Coin;

        ItemShowTime = GameSateData.I.myData.manage.ItemFastShowUpgradeLevel;

        GameSateData.I.SaveData();
	}
	
	// Update is called once per frame
	void Update (){
        if ( bStopMakeItem == false )
            MakeItem_Sec();

        if (Application.loadedLevelName == "stExit"){
            GameObject.Find("ScoreLabel").GetComponent<UILabel>().text = Score.ToString(); fDt = 0.0f; fSpeed = 0.8f; fWider = 0.0f; fScore = 0.0f; fSabot = 0.0f; fItem = 0.0f; fMagnet = 0.0f; bStopMakeItem = false;
            
            if (stExitSaveData == false)
            {
                nTempleRank = Score;
                RankSort();
                stExitSaveData = true;
                GameSateData.I.SaveData();
                Resources.UnloadUnusedAssets();
            }
        }
	}

    void MakeItem_Sec()
    {
        if (Application.loadedLevelName == "stMenu")
        {
            if (stExitSaveData == true)
            {
                stExitSaveData = false;
                GameSateData.I.SaveData();
                Resources.UnloadUnusedAssets();
                System.GC.Collect();
            }
        }
        if (Application.loadedLevelName == "stGame" && GetLiveCheckHero() == 1)
        {
            fMagnet += Time.deltaTime;
            fDt += Time.deltaTime;
            fWider += Time.deltaTime;
            fScore += Time.deltaTime;
            fSabot += Time.deltaTime;
            fItem += Time.deltaTime;

            if (fMagnet > fMagPlane)
            {
                if (GameObject.Find("MagnetObject(Clone)") == null)
                    CraetePrefabItem_Magnet();

                fMagnet = 0.0f;
            }
            if (fItem > fItemPlane)
            {
                CraetePrefabItem_Item();

                fItem = 0.0f;
            }
            if (fDt > fDtPlane)
            {
                if (GameObject.Find("GuardObject(Clone)") == null)
                    CraetePrefabItem_Guard(new Vector3(Random.Range(8.0f, -9.0f), Random.Range(5.0f, -5.0f), 0.0f), false);

                fDt = 0.0f;
            }
            if (fWider > fWiderPlane)
            {
                if (GameObject.Find("WiderObject(Clone)") == null)
                    CraetePrefabItem_Wider();

                fWider = 0.0f;
            }
            if (fScore > fScorePlane)
            {
                if (GameObject.Find("ScoreObject(Clone)") == null)
                {
                    CraetePrefabItem_Score();
                }
                fScore = 0.0f;
            }
            if (fSabot > fSabotPlane)
            {
                if (GameObject.Find("SabotObject(Clone)") == null)
                    CraetePrefabItem_Sabot();

                fSabot = 0.0f;
            }

        }
    }
    int GetLiveCheckHero()
    {
        if ( LiveHero == null )
            LiveHero = GameObject.Find("HeroSprite").GetComponent<MouseScripts>();

            if (LiveHero.GetHeroLive() == false)
                return 1;
            else
                return 0;
    }

    public void CraetePrefabItem_Guard(Vector3 Position , bool FinishCheck)
    {
        GameObject PrefapStage = Resources.Load("Prefabs/GuardObject") as GameObject;
        GameObject PrefabItem = Instantiate(PrefapStage, PrefapStage.transform.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as GameObject;

        if (FinishCheck)
            PrefabItem.GetComponentInChildren<InStageGuard>().transform.position = new Vector3(Position.x,Position.y,Position.z);

        fDtPlane = Random.Range(10.0f, 18.0f) - ( 0.2f * ItemShowTime );
        fDt = 0.0f;
    }
    void CraetePrefabItem_Wider()
    {
        GameObject PrefapStage = Resources.Load("Prefabs/WiderObject") as GameObject;
        Instantiate(PrefapStage, PrefapStage.transform.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        fWiderPlane = Random.Range(15.0f, 25.0f) - (0.2f * ItemShowTime);
    }
    void CraetePrefabItem_Score()
    {
        GameObject PrefapStage = Resources.Load("Prefabs/ScoreObject") as GameObject;
        Instantiate(PrefapStage, PrefapStage.transform.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        fScorePlane = Random.Range(12.0f, 24.0f) - (0.2f * ItemShowTime);
    }
    void CraetePrefabItem_Sabot()
    {
        GameObject PrefapStage = Resources.Load("Prefabs/SabotObject") as GameObject;
        Instantiate(PrefapStage, PrefapStage.transform.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        fSabotPlane = Random.Range(20.0f, 40.0f) - (0.2f * ItemShowTime);
    }
    void CraetePrefabItem_Item()
    {
        GameObject PrefapStage = Resources.Load("Prefabs/Coin") as GameObject;
        Instantiate(PrefapStage, PrefapStage.transform.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        fItemPlane = Random.Range(0.4f, 0.4f);
    }

    void CraetePrefabItem_Magnet()
    {
        GameObject PrefapStage = Resources.Load("Prefabs/MagnetObject") as GameObject;
        Instantiate(PrefapStage, PrefapStage.transform.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        fMagPlane = Random.Range(15.0f, 20.0f) - (0.2f * ItemShowTime);
    }

    void RankSort()
    {
        nArrayTemple[0] = GameSateData.I.myData.manage.rank_1;
        nArrayTemple[1] = GameSateData.I.myData.manage.rank_2;
        nArrayTemple[2] = GameSateData.I.myData.manage.rank_3;
        nArrayTemple[3] = GameSateData.I.myData.manage.rank_4;
        nArrayTemple[4] = GameSateData.I.myData.manage.rank_5;
        nArrayTemple[5] = nTempleRank;

        Sort();

        GameSateData.I.myData.manage.rank_1 = nArrayTemple[0];
        GameSateData.I.myData.manage.rank_2 = nArrayTemple[1];
        GameSateData.I.myData.manage.rank_3 = nArrayTemple[2];
        GameSateData.I.myData.manage.rank_4 = nArrayTemple[3];
        GameSateData.I.myData.manage.rank_5 = nArrayTemple[4];
    }

    void Sort()
    {
        int i, j, temp;
        for (i = 0; i < 6; i++)
        {
            for (j = 0; j < 5; j++)
            {
                if (nArrayTemple[j] <= nArrayTemple[j + 1])
                {
                    temp = nArrayTemple[j];
                    nArrayTemple[j] = nArrayTemple[j + 1];
                    nArrayTemple[j + 1] = temp;
                }
            }

        }
    }
    /// <summary>
    /// 몬스터 스피드 조절후 다시 돌려줄때 함수입니다. Set_Monster_Speed 함수를 실행한 후 꼭 실행시켜주세요.
    /// </summary>
    public void Return_Monster_Speed()
    {
        fSpeed = fSaveMonsterSpeed;
    }
    /// <summary>
    /// 몬스터의 속도를 바꿔주는 함수입니다. 바꿀때 임시의 함수에서 전의 속도를 저장합니다.
    /// </summary>
    /// <param name="_Set_SPEED"></param>
    public void Set_Monster_Speed(float _Set_SPEED)
    {
        fSaveMonsterSpeed = fSpeed;
        fSpeed = _Set_SPEED;
    }
}
