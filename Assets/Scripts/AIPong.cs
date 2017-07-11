using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPong : MonoBehaviour {

	public Pong pong;
	public float moveSpeed = 0.5f;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (pong.currentball == null) {
			var newpos = this.transform.position;
			newpos.x = 0f;
			newpos.y = 0f;
			this.transform.position = newpos;
		} else {
			var d = this.transform.position - pong.currentball.transform.position;
			var newpos = this.transform.position;
			newpos.x -= d.x * moveSpeed;
			newpos.y -= d.y * moveSpeed;
			this.transform.position = newpos;
		}
	}
}
