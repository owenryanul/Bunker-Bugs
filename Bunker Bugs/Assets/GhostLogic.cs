using UnityEngine;
using System.Collections;

public class GhostLogic : MonoBehaviour {

    public GameObject realObject;
    private int numberOfBlockingCollisions;
    private bool mouseOverSidebar;
    private GameObject sidebar;

	// Use this for initialization
	void Start () {
        //this.gameObject.SetActive(false);
        numberOfBlockingCollisions = 0;
        sidebar = GameObject.Find("Sidebar Panel");
	}
	
	// Update is called once per frame
	void Update () {
        //[Ghost Positioning] Centres the ghost on the 1x1 space closest to the cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x = Mathf.RoundToInt(mousePosition.x);
        mousePosition.y = Mathf.RoundToInt(mousePosition.y);
        mousePosition.z = 0;

        this.gameObject.transform.position = mousePosition;
        //[/Ghost Positioning]

        //[UI Disables Ghost] Stops the ghost logic from running while the mouse is over ui.
        //!!!WARNING: Collider is a tempory fix and will not work with different screen sizes, use event system instead
        if(sidebar.GetComponent<Collider2D>().bounds.Contains(Input.mousePosition))
        {
            mouseOverSidebar = true;
        }
        else
        {
            mouseOverSidebar = false;
        }
        //[/UI Disables Ghost]


        //[Ghost Coloring] colours to the ghost green if they can be safetly placed at their current position
        //                 and red if something is blocking it
        if(numberOfBlockingCollisions == 0 && !mouseOverSidebar)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        //[/Ghost Coloring]

        //[Place tile] on a leftclick, places the real version of the selected tile where the ghost was, if the location is unobstructed
        if (Input.GetMouseButtonDown(0) && numberOfBlockingCollisions == 0 && !mouseOverSidebar)
        {
            placeRealObject();
        }
        //[/Place tile]
	}

    void placeRealObject()
    {
        Instantiate(realObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "SolidTile" || col.tag == "TerrianTile" || col.tag == "WindowTile" || col.tag == "NPC" || col.tag == "Enemy" || col.tag == "Drill")
        {
            numberOfBlockingCollisions++;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "SolidTile" || col.tag == "TerrianTile" || col.tag == "WindowTile" || col.tag == "NPC" || col.tag == "Enemy" || col.tag == "Drill")
        {
            numberOfBlockingCollisions--;
        } 
    }
}
