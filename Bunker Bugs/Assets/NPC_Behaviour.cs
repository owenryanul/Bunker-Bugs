using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC_Behaviour : MonoBehaviour {

    private List<GameObject> objectsInLineOfSight;
    private GameObject closestObjectInLineOfSight;

	// Use this for initialization
	void Start () {
        objectsInLineOfSight = new List<GameObject>();
        closestObjectInLineOfSight = new GameObject();
        closestObjectInLineOfSight.transform.Translate(100000, 0, 0);//position.set only affects the copy of position created by .position, not the transform of the gameobject itself.
	}
	
	// Update is called once per frame
	void Update () {

        //{SpotEnemy} Fires a Linecast that detects all objects to the right of the npc, then determines whether a solid tile or an enemy is closer, allowing the npc to determine whether or not to fire
        RaycastHit2D[] allTargets = Physics2D.LinecastAll(this.gameObject.transform.position, new Vector2(-100000, this.gameObject.transform.position.y));
        foreach(RaycastHit2D atarget in allTargets)
        {
            if (atarget.transform.gameObject.tag == "Enemy" || atarget.transform.gameObject.tag == "SolidTile")
            {
                if (Mathf.Abs(atarget.transform.position.x - this.gameObject.transform.position.x) < Mathf.Abs(closestObjectInLineOfSight.transform.position.x - this.gameObject.transform.position.x))
                {
                    closestObjectInLineOfSight = atarget.transform.gameObject;
                    //print("New Closest Object = " + closestObjectInLineOfSight.name);
                }
            }
        }
        //{/SpotEnemy}

        if(closestObjectInLineOfSight.tag == "Enemy")
        {
            print("Pew Pew");
        }
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
