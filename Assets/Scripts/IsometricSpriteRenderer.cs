using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class IsometricSpriteRenderer : MonoBehaviour {
	
	void Update () {
        GetComponent<Renderer>().sortingOrder = (int)(transform.position.y * -10);
	}
}
