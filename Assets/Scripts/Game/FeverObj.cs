using UnityEngine;
using System.Collections;

public class FeverObj : MonoBehaviour {

    GameObject[] Coin_BOT = new GameObject[5];
    GameObject[] Coin_TOP = new GameObject[5];
    GameObject[] Coin_LEFT = new GameObject[5];
    GameObject[] Coin_RIGHT = new GameObject[5];

    bool[] Coin_Bot_bool = new bool[5];
    bool[] Coin_Top_bool = new bool[5];
    bool[] Coin_Left_bool = new bool[5];
    bool[] Coin_Right_bool = new bool[5];

    Vector3[] Coin_ZeroVector = new Vector3[4];
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 5; i++)
        {
            Coin_Bot_bool[i] = false;
            Coin_BOT[i] = GameObject.Find("FeverCoin_Bot_"+(i+1).ToString());
            Coin_TOP[i] = GameObject.Find("FeverCoin_Top_" + (i + 1).ToString());
            Coin_LEFT[i] = GameObject.Find("FeverCoin_Left_" + (i + 1).ToString());
            Coin_RIGHT[i] = GameObject.Find("FeverCoin_Right_" + (i + 1).ToString());

            Coin_BOT[i].SetActiveRecursively(false);
            Coin_TOP[i].SetActiveRecursively(false);
            Coin_LEFT[i].SetActiveRecursively(false);
            Coin_RIGHT[i].SetActiveRecursively(false);
            Coin_ZeroVector[0] = new Vector3(0.0f, -6.5f, -1.092103f);
            Coin_ZeroVector[1] = new Vector3(0.0f, 6.5f, -1.092103f);
            Coin_ZeroVector[2] = new Vector3(5.5f, 0.0f, -1.092103f);
            Coin_ZeroVector[3] = new Vector3(-5.5f, 0.0f, -1.092103f);
        }
	}

    // Update is called once per frame
    void Update()
    {

	}

    void UpdateVector()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Coin_BOT[i].active == false && Coin_Bot_bool[i] == true)
            {
                Coin_ZeroVector[0].x = Random.Range(-4.0f, 4.0f);
                Coin_BOT[i].transform.position = Coin_ZeroVector[0];
                Coin_Bot_bool[i] = false;
                break;
            }
            else if (Coin_TOP[i].active == false && Coin_Top_bool[i] == true)
            {
                Coin_ZeroVector[1].x = Random.Range(-4.0f, 4.0f);
                Coin_TOP[i].transform.position = Coin_ZeroVector[1];
                Coin_Top_bool[i] = false;
                break;
            }
            else if (Coin_LEFT[i].active == false && Coin_Left_bool[i] == true)
            {
                Coin_ZeroVector[3].y = Random.Range(-4.0f, 4.0f);
                Coin_LEFT[i].transform.position = Coin_ZeroVector[3];
                Coin_Left_bool[i] = false;
                break;
            }
            else if (Coin_RIGHT[i].active == false && Coin_Right_bool[i] == true)
            {
                Coin_ZeroVector[2].y = Random.Range(-4.0f, 4.0f);
                Coin_RIGHT[i].transform.position = Coin_ZeroVector[2];
                Coin_Right_bool[i] = false;
                break;
            }
        }
    }

    public void SetActiveFeverCoin(bool bSet)
    {
        for (int i = 0; i < 5; i++)
        {
            Coin_BOT[i].SetActiveRecursively(bSet);
            Coin_BOT[i].transform.Translate(0.0f, Random.Range(2.0f, 4.0f), 0.0f);
            Coin_TOP[i].SetActiveRecursively(bSet);
            Coin_TOP[i].transform.Translate(0.0f, Random.Range(-4.0f, -2.0f), 0.0f);
            Coin_LEFT[i].SetActiveRecursively(bSet);
            Coin_LEFT[i].transform.Translate(Random.Range(2.0f, 4.0f), 0.0f,0.0f);
            Coin_RIGHT[i].SetActiveRecursively(bSet);
            Coin_RIGHT[i].transform.Translate(Random.Range(-4.0f, -2.0f), 0.0f, 0.0f);
            Coin_Bot_bool[i] = true;
            Coin_Top_bool[i] = true;
            Coin_Left_bool[i] = true;
            Coin_Right_bool[i] = true;
        }
    }

    public void QuitActive(GameObject goGame)
    {
        goGame.SetActiveRecursively(false);
        UpdateVector();
    }
}
