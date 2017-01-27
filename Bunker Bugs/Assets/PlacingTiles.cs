using UnityEngine;
using System.Collections;

public class PlacingTiles : MonoBehaviour {

    private int tileIndex;
    private GameObject steelTileGhost;//reference to the current instance of steel tile ghost
    private GameObject gruntTileGhost;//reference to the current instance of grunt tile ghost


    // Use this for initialization
    void Start () {
        tileIndex = 0;//0 means no tile selected
        steelTileGhost = GameObject.Find("Ghost_Wall");
        steelTileGhost.SetActive(false);
        gruntTileGhost = GameObject.Find("Ghost_Grunt");
        gruntTileGhost.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setSelectedTile_SteelTile()
    {
        switch (tileIndex)//deselects the currently selected tile
        {
            case 0: steelTileGhost.SetActive(true); tileIndex = 1; break;
            case 1: steelTileGhost.SetActive(false); tileIndex = 0; break;
            case 2: steelTileGhost.SetActive(true); gruntTileGhost.SetActive(false); tileIndex = 1; break;
            default: print("Error: Unknown tile being deselected, check PlacingTiles methods, are the switch statements filled?"); break;
        }
    }

    public void setSelectedTile_GruntTile()
    {
        switch (tileIndex)//deselects the currently selected tile
        {
            case 0: gruntTileGhost.SetActive(true); tileIndex = 2; break;
            case 1: gruntTileGhost.SetActive(true); steelTileGhost.SetActive(false); tileIndex = 2; break;
             case 2: gruntTileGhost.SetActive(false); tileIndex = 0;  break;
             default: print("Error: Unknown tile being deselected, check PlacingTiles methods, are the switch statements filled?"); break;
        }
    }

    public void DeSelectAllTiles()
    {
        switch (tileIndex)//deselects the currently selected tile
        {
            case 0: break;
            case 1: steelTileGhost.SetActive(false); tileIndex = 0; break;
            case 2: gruntTileGhost.SetActive(false); tileIndex = 0; break;
            default: print("Error: Unknown tile being deselected, check PlacingTiles methods, are the switch statements filled?"); break;
        }
    }






}
