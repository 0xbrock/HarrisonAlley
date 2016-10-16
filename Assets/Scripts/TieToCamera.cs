using UnityEngine;
using System.Collections;

public class TieToCamera : MonoBehaviour {
    
    public Camera cam;

    void Start () {
        if (cam == null)
        {
            cam = Camera.main;
        }

        if (cam != null)
        {
            // Tie this to the camera, and do not keep the local orientation.
            transform.SetParent(cam.GetComponent<Transform>(), true);
        }
    }
}
