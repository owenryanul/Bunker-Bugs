using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC_Behaviour : MonoBehaviour {

    public GameObject bullet;
    float bulletTick;
    private List<GameObject> objectsInLineOfSight;
    

	// Use this for initialization
	void Start () {
        bulletTick = 0.1f;
        objectsInLineOfSight = new List<GameObject>();
        //position.set only affects the copy of position created by .position, not the transform of the gameobject itself.
	}
	
	// Update is called once per frame
	void Update () {

        //{SpotEnemy} Fires a Linecast that detects all objects to the right of the npc, then determines whether a solid tile or an enemy is closer, allowing the npc to determine whether or not to fire
        GameObject closestObjectInLineOfSight = null;
        RaycastHit2D[] allTargets = Physics2D.LinecastAll(this.gameObject.transform.position, new Vector2(-100000, this.gameObject.transform.position.y));
        foreach (RaycastHit2D atarget in allTargets)
        {
            if (atarget.transform.gameObject.tag == "Enemy" || atarget.transform.gameObject.tag == "SolidTile" || atarget.transform.gameObject.tag == "TerrianTile")
            {
                if(closestObjectInLineOfSight == null)
                {
                    //intialise closestObjectInLineOfSight to be the first enemy or solidtile or TerrianTile in the array
                    closestObjectInLineOfSight = atarget.transform.gameObject;
                }
                else if (Mathf.Abs(atarget.transform.position.x - this.gameObject.transform.position.x) < Mathf.Abs(closestObjectInLineOfSight.transform.position.x - this.gameObject.transform.position.x))
                {
                    closestObjectInLineOfSight = atarget.transform.gameObject;
                    //print("New Closest Object = " + closestObjectInLineOfSight.name);
                }
            }
        }
        //{/SpotEnemy}

        //{Shoot}
        if(closestObjectInLineOfSight != null && closestObjectInLineOfSight.tag == "Enemy")
        {
            if (bulletTick <= 0)
            {
                //print("Pew Pew");
                Instantiate(bullet, this.gameObject.transform.position, this.gameObject.transform.rotation);
                bulletTick = 0.1f;
            }
            else
            {
                bulletTick -= Time.deltaTime;
            }
        }
        //{/Shoot}
	}

    /*void OnTriggerEnter2D(Collider2D other)
    {
        //print("hey");
        //print("Triggered by " + other.gameObject.name);
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "SolidTile")
        {
            objectsInLineOfSight.Add(other.gameObject);
            print("Adding " + other.gameObject.name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //print("Triggered out by " + other.gameObject.name);
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "SolidTile")
        {
            objectsInLineOfSight.Remove(other.gameObject);
            print("Removing " + other.gameObject.name);
        }
    }*/
}
