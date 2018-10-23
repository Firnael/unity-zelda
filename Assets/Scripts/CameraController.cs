using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float speed = 0.1f;
    Camera cam;

	void Start () {
        cam = GetComponent<Camera>();
	}
	
	void Update () {
        cam.orthographicSize = (Screen.height / 100f);
        if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speed) + new Vector3(0, 0, -10);
        }
	}
}
