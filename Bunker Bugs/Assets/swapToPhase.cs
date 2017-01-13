using UnityEngine;
using System.Collections;

public class swapToPhase : MonoBehaviour {

    private bool isActionPhase;

	// Use this for initialization
	void Start () {
        isActionPhase = false;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void swapToAction()
    {
        isActionPhase = true;
        print(this.gameObject.name + " swaping to action phase");
    }

    public void swapOffAction()
    {
        isActionPhase = false;
        print(this.gameObject.name + " swaping to setup phase");
    }
}
