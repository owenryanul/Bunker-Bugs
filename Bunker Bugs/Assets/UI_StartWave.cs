using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_StartWave : MonoBehaviour {

    private bool setupPhaseOn;

	// Use this for initialization
	void Start () {
        setupPhaseOn = true;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void swapToActionPhase()
    {
        this.setupPhaseOn = false;

        GameObject[] objectsInScene = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject anObject in objectsInScene)
        {
            try
            {
                anObject.GetComponent<swapToPhase>().swapToAction();
            }
            catch
            {
            }
        }
    }

    public void swapToSetupPhase()
    {
        this.setupPhaseOn = true;

        GameObject[] objectsInScene = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject anObject in objectsInScene)
        {
            try
            {
                anObject.GetComponent<swapToPhase>().swapOffAction();
            }
            catch
            {
            }
        }
    }
}
