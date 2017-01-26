using UnityEngine;
using System.Collections;

public class animateSidebar : MonoBehaviour {

    private Animator animater;
    private bool isOut;

    // Use this for initialization
    void Start() {
        animater = this.GetComponent<Animator>();
        animater.Play("Sidebar Out");
        isOut = true;
    }

    // Update is called once per frame
    void Update() {
    }

    public void toggleSidebar()
    {
        if (isOut)
        {
            slideInSidebar();
            isOut = false;
        }
        else
        {
            slideOutSidebar();
            isOut = true;
        }
    }

    public void slideOutSidebar()
    {
        animater.Play("Sidebar Out");
    }

    public void slideInSidebar()
    {
        animater.Play("Sidebar In");
    }
}
