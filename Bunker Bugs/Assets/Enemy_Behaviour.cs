using UnityEngine;
using System.Collections;

public class Enemy_Behaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate(0.01f, 0, 0);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "NPC_Bullet")
        {
            Destroy(other.gameObject);
            KillEnemy();
        }
    }

    //Use to run behaviour that triggers when the enemy is killed. e.g. enemy explodes on death.
    void KillEnemy()
    {
        Destroy(this.gameObject);
    }
}
