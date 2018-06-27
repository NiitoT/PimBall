using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {

    private float minium = 1.0f;

    private float magSpead = 10.0f;

    private float magnification = 0.07f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.localScale = new Vector3(this.minium + Mathf.Sin(Time.time * this.magSpead) * this.magnification, this.transform.localScale.y, this.minium + Mathf.Sin(Time.time * this.magSpead) * this.magnification);
		
	}
}
