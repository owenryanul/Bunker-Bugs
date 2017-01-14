using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

    public Vector2 movementDirection = new Vector2(-1, 0);
    public float speed = 0.1f;
    private float moveTick;

	// Use this for initialization
	void Start () {
        moveTick = 0.01f;
	}
	
	// Update is called once per frame
	void Update () {
        if (moveTick <= 0)
        {
            this.transform.Translate(movementDirection * speed);
            moveTick = 0.01f;
        }
        else
        {
            moveTick -= Time.deltaTime;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "SolidTile")
        {
            Destroy(this.gameObject);
        }
    }
}
