using UnityEngine;
using System.Collections;

public class ParticleManager : MonoBehaviour {

    public bool bParticle_Coin = false;
    GameObject[] Particle_Coin = new GameObject[2];
    tk2dAnimatedSprite[] Particle_Coin_Play = new tk2dAnimatedSprite[2];
    GameObject goHeroVec = null;
	// Use this for initialization
	void Start () {
        Particle_Coin[0] = GameObject.Find("Particle_Coin_1");
        Particle_Coin[1] = GameObject.Find("Particle_Coin_2");

        Particle_Coin_Play[0] = Particle_Coin[0].GetComponent<tk2dAnimatedSprite>();
        Particle_Coin_Play[1] = Particle_Coin[1].GetComponent<tk2dAnimatedSprite>();

        goHeroVec = GameObject.Find("HeroSprite");
	}
	void Update () {
        if (bParticle_Coin == true)
        {
            if (Particle_Coin[0].active == true)
            {
                Particle_Coin[1].SetActiveRecursively(true);
                Particle_Coin[1].transform.position = new Vector3(goHeroVec.transform.position.x,goHeroVec.transform.position.y,goHeroVec.transform.position.z);
                Particle_Coin_Play[1].Play();
            }
            else
            {
                Particle_Coin[0].SetActiveRecursively(true);
                Particle_Coin[0].transform.position = new Vector3(goHeroVec.transform.position.x, goHeroVec.transform.position.y, goHeroVec.transform.position.z);
                Particle_Coin_Play[0].Play();
            }
            bParticle_Coin = false;
        }
	}
}
