using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_Behaviour : MonoBehaviour {

    private bool isJumping;
    private float timeLeftInJump;
    private List<GameObject> blockingTiles;

	// Use this for initialization
	void Start () {
        isJumping = false;
        timeLeftInJump = 0.2f;
        blockingTiles = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        
        //{Gravity}
        if(!isGrounded())
        {
            this.gameObject.transform.Translate(0, -3 * Time.deltaTime, 0);
        }
        //{/Gravity}

        if(isJumping)
        {
            executeEnemyJump();
        }

        if(!isMovementBlocked()) 
        {
            this.gameObject.transform.Translate(1f * Time.deltaTime, 0, 0);
        }
        else if(!isJumping && isGrounded())
        {
            isJumping = true;
        }
	}

    //detects if there are any solid tiles below the enemy, by making two raycasts, 1 slightly in from the right edge of the enemy and another slightly in from the left edge of the enemy.
    bool isGrounded()
    {
        RaycastHit2D[] rightGroundRay = Physics2D.LinecastAll(this.gameObject.transform.position + new Vector3(0.2f, 0, 0), new Vector3(this.gameObject.transform.position.x + 0.2f, this.gameObject.transform.position.y - 0.5f, 0));
        foreach (RaycastHit2D atarget in rightGroundRay)
        {
            if (atarget.transform.gameObject.tag == "WindowTile" || atarget.transform.gameObject.tag == "SolidTile")
            {
                return true;
            }
        }
        RaycastHit2D[] leftGroundRay = Physics2D.LinecastAll(this.gameObject.transform.position - new Vector3(0.2f, 0, 0), new Vector3(this.gameObject.transform.position.x - 0.2f, this.gameObject.transform.position.y - 0.5f, 0));
        foreach (RaycastHit2D atarget in leftGroundRay)
        {
            if (atarget.transform.gameObject.tag == "WindowTile" || atarget.transform.gameObject.tag == "SolidTile")
            {
                return true;
            }
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "NPC_Bullet")
        {
            Destroy(other.gameObject);
            KillEnemy();
        }
        else if ((other.gameObject.tag == "SolidTile" || other.gameObject.tag == "WindowTile") && other.transform.position.y >= this.transform.position.y && other.transform.position.x > this.transform.position.x)
        {
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    }

    void executeEnemyJump()
    {
        if (timeLeftInJump > 0)
        {
            timeLeftInJump -= Time.deltaTime;
            this.transform.Translate(0, 12 * Time.deltaTime, 0);
        }
        else
        {
            isJumping = false;
            timeLeftInJump = 0.2f;
        }
    }

    bool isMovementBlocked()
    {
          //detects if there are any solid tiles to the right of the enemy, by casting a ray from near the bottom of the sprite right.
            RaycastHit2D[] forwardRay = Physics2D.LinecastAll(this.gameObject.transform.position - new Vector3(0, 0.3f, 0), new Vector3(this.gameObject.transform.position.x + 0.5f, this.gameObject.transform.position.y - 0.3f, 0));
            foreach (RaycastHit2D atarget in forwardRay)
            {
                if (atarget.transform.gameObject.tag == "WindowTile" || atarget.transform.gameObject.tag == "SolidTile")
                {
                    return true;
                }
            }
            return false;
    }

    //Use to run behaviour that triggers when the enemy is killed. e.g. enemy explodes on death.
    void KillEnemy()
    {
        Destroy(this.gameObject);
    }
}
