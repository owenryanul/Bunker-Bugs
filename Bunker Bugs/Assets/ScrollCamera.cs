using UnityEngine;
using System.Collections;

public class ScrollCamera : MonoBehaviour {

    private Camera mainCamera;
    private Collider2D cameraBounds;
    private float cameraScrollTick;

	// Use this for initialization
	void Start () {
        mainCamera = this.gameObject.GetComponent<Camera>();
        cameraScrollTick = 0.01f;
        cameraBounds = GameObject.Find("CameraBounds").GetComponent<BoxCollider2D>();
        print(cameraBounds.gameObject.name);
	}
	

    //TODO: Add variable Scroll Speed relative to how close the cursor is to the edge of the screen.

	// Update is called once per frame
	void Update () {
        //note, screen space origin = bottom left corner

        //mouse is at the left edge of the screen, and camera's new position will still be within the camera's bounds        
        if (Input.mousePosition.x <= mainCamera.pixelWidth/10 && (cameraBounds.bounds.Contains((Vector2)(mainCamera.transform.position - new Vector3(0.25f, 0, 0)))))
        {
            if (cameraScrollTick <= 0)
            {
                mainCamera.transform.position -= new Vector3(0.25f, 0, 0);
            }          
        }
        //mouse is at the right edge of the screen, and the camera's new position will still be within the camera's bounds 
        else if(Input.mousePosition.x >= (mainCamera.pixelWidth/10) * 9 && (cameraBounds.bounds.Contains((Vector2)(mainCamera.transform.position + new Vector3(0.25f, 0, 0)))))
        {
            if (cameraScrollTick <= 0)
            {
                mainCamera.transform.position += new Vector3(0.25f, 0, 0);
            }
        }

        //mouse is at the bottom edge of the screen, and the camera's new position will still be within the camera's bounds 
        if (Input.mousePosition.y <= mainCamera.pixelHeight/ 8 && (cameraBounds.bounds.Contains((Vector2)(mainCamera.transform.position - new Vector3(0, 0.25f, 0)))))
        {
            if (cameraScrollTick <= 0)
            {
                mainCamera.transform.position -= new Vector3(0, 0.25f, 0);
            }
        }
        //mouse is at the top edge of the screen, and the camera's new position will still be within the camera's bounds 
        else if (Input.mousePosition.y >= (mainCamera.pixelHeight/8) * 7 && (cameraBounds.bounds.Contains((Vector2)(mainCamera.transform.position + new Vector3(0, 0.25f, 0)))))
        {
            if (cameraScrollTick <= 0)
            {
                mainCamera.transform.position += new Vector3(0, 0.25f, 0);
            }
        }

        //time the scroll to move the camera only 100 times a second
        if(cameraScrollTick <= 0)
        {
            cameraScrollTick = 0.01f;
        }
        cameraScrollTick -= Time.deltaTime;
	}
}
