using UnityEngine;
using System.Collections;

public class PlacingTiles : MonoBehaviour {

    private int tileIndex;
    private GameObject steelTileGhost;//reference to the current instance of steel tile ghost
    private GameObject gruntTileGhost;//reference to the current instance of grunt tile ghost
    private GameObject sellTileGhost;

    // Use this for initialization
    void Start () {
        tileIndex = 0;//0 means no tile selected
        steelTileGhost = GameObject.Find("Ghost_Wall");
        steelTileGhost.SetActive(false);
        gruntTileGhost = GameObject.Find("Ghost_Grunt");
        gruntTileGhost.SetActive(false);
        sellTileGhost = GameObject.Find("Ghost_Sell");
        sellTileGhost.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setSelectedTile_SteelTile()
    {
        DeSelectSelectedTile();
        if (tileIndex == 1)
        {
            tileIndex = 0;
        }
        else
        {
            steelTileGhost.SetActive(true);
            tileIndex = 1;
        }
    }

    public void setSelectedTile_GruntTile()
    {
        DeSelectSelectedTile();
        if (tileIndex == 2)
        {
            tileIndex = 0;
        }
        else
        {
            gruntTileGhost.SetActive(true);
            tileIndex = 2;
        }
    }

    public void setSelectedTile_Sell()
    {
        DeSelectSelectedTile();
        if (tileIndex == -1)
        {
            tileIndex = 0;
        }
        else
        {
            sellTileGhost.SetActive(true);
            tileIndex = -1;
        }
    }

    public void DeSelectSelectedTile()
    {
        switch (tileIndex)//deselects the currently selected tile
        {
            case -1: sellTileGhost.SetActive(false); break;
            case 0: break;
            case 1: steelTileGhost.SetActive(false); break;
            case 2: gruntTileGhost.SetActive(false); break;
            default: print("Error: Unknown tile being deselected, check PlacingTiles methods, are the switch statements filled?"); break;
        }
    }

    public void DeSelectAllTiles()
    {
        switch (tileIndex)//deselects the currently selected tile
        {
            case -1: sellTileGhost.SetActive(false); tileIndex = 0; break;
            case 0: break;
            case 1: steelTileGhost.SetActive(false); tileIndex = 0; break;
            case 2: gruntTileGhost.SetActive(false); tileIndex = 0; break;
            default: print("Error: Unknown tile being deselected, check PlacingTiles methods, are the switch statements filled?"); break;
        }
    }
}
