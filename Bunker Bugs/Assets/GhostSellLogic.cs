using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSellLogic : MonoBehaviour {

    private GameObject objectToBeSold;
    private int numberOfSellableCollisions;
    private bool mouseOverSidebar;
    private GameObject sidebar;
    

    // Use this for initialization
    void Start()
    {
        //this.gameObject.SetActive(false);
        numberOfSellableCollisions = 0;
        sidebar = GameObject.Find("Sidebar Panel");
    }

    // Update is called once per frame
    void Update()
    {
        //[Ghost Positioning] Centres the ghost on the 1x1 space closest to the cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x = Mathf.RoundToInt(mousePosition.x);
        mousePosition.y = Mathf.RoundToInt(mousePosition.y);
        mousePosition.z = 0;

        this.gameObject.transform.position = mousePosition;
        //[/Ghost Positioning]

        //[UI Disables Ghost] Stops the ghost logic from running while the mouse is over ui.
        //!!!WARNING: Collider is a tempory fix and will not work with different screen sizes, use event system instead
        if (sidebar.GetComponent<Collider2D>().bounds.Contains(Input.mousePosition))
        {
            mouseOverSidebar = true;
        }
        else
        {
            mouseOverSidebar = false;
        }
        //[/UI Disables Ghost]


        //[Ghost Coloring] colours to the ghost green if they are over a sellable tile
        //                 and red if over an unsellable tile or air.
        if (numberOfSellableCollisions == 0 || mouseOverSidebar)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        //[/Ghost Coloring]

        //[Place tile] on a leftclick, destroys the sellable tile
        if (Input.GetMouseButtonDown(0) && numberOfSellableCollisions == 1 && !mouseOverSidebar)
        {
            sellObject();
        }
        //[/Place tile]
    }

    void sellObject()
    {
        Destroy(objectToBeSold);
        numberOfSellableCollisions--;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "SolidTile" || col.tag == "WindowTile" || col.tag == "NPC")
        {
            numberOfSellableCollisions++;
            if(numberOfSellableCollisions == 1)
            {
                objectToBeSold = col.gameObject;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "SolidTile" || col.tag == "WindowTile" || col.tag == "NPC")
        {
            numberOfSellableCollisions--;
        }
    }
}
