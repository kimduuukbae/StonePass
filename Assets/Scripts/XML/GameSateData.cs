using UnityEngine;
using System.Collections;



public class GameSateData : MonoBehaviour 
{
    private static GameSateData m_Instance = null;

   
    public static GameSateData I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(GameSateData)) as GameSateData;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get Manager Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }

   public UILabel DebugLogLabel = null;

   public ManagerData myData; 
   private string _data; 

   void Awake () 
	{ 
	    myData=new ManagerData();
    }
	
    public void SaveData()
	{
        ManageData();
	    _data = GameStateXML.SerializeObject(myData,"ManagerData"); 
        GameStateXML.CreateXML("Test.xml", _data);
	}

    public void LoadData()
	{
        _data = GameStateXML.LoadXML("Test.xml");
		
        if(_data.ToString() != "") 
	    {
            myData = (ManagerData)GameStateXML.DeserializeObject(_data,"ManagerData");
	    }
	}

	
    public void ManageData()
    {
        if (Application.loadedLevelName == "stMenu")
        {
            myData.manage.Coin = (int)transform.GetComponent<Manager>().fCoinNum;
            myData.manage.ItemTimeUpgradeLevel = (int)GameObject.Find("ItemTimeUpgrade").GetComponent<ItemTimeUpgrade>().LevelVersion;
            myData.manage.ItemFastShowUpgradeLevel = (int)GameObject.Find("ItemFastShowUpgrade").GetComponent<ItemFastShowUpgrade>().LevelVersion;
            myData.manage.FastStartUpgradeLevel = (int)GameObject.Find("FastStartUpgrade").GetComponent<FastStartUpgrade>().LevelVersion;
        }
    }
}
