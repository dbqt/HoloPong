using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float ballSpeed = 1.0f;

	public AudioSource impact;

	// Use this for initialization
	void Start () {
		

		Vector3 initv = new Vector3 (Random.Range (0f, 1f), Random.Range (0f, 1f), 1f);
		initv.Normalize ();
		//Debug.Log (initv * ballSpeed);
		this.gameObject.GetComponent<Rigidbody> ().velocity = initv * ballSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (this.gameObject.GetComponent<Rigidbody> ().velocity);
		var v = this.gameObject.GetComponent<Rigidbody> ().velocity;
		this.gameObject.GetComponent<Rigidbody> ().velocity = v.normalized* ballSpeed;

		var d = Pong.GetInstance().gameObject.transform.position - this.transform.position;
		Debug.Log (d.magnitude);
		if (Mathf.Abs(d.magnitude) > 6f) {
			Destroy (this.gameObject);
		}

	}

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.CompareTag ("Hittable")) {
			var v = this.gameObject.GetComponent<Rigidbody> ().velocity;
			// hack 
			var p = c.gameObject.transform.position;
			if (p.x != 0f) {
				v.x = -v.x;
			} else if (p.y != 0f) {
				v.y = -v.y;
			} else {
				Debug.Log ("wth");
			}
			this.gameObject.GetComponent<Rigidbody> ().velocity = v;
			impact.Play ();


		} else if (c.gameObject.CompareTag ("Paddle")) {
			var v = this.gameObject.GetComponent<Rigidbody> ().velocity;
			var offset = new Vector3 (Random.Range (-0.5f, 0.5f), Random.Range (-0.5f, 0.5f), 0f);
			v.z = -v.z;
			this.gameObject.GetComponent<Rigidbody> ().velocity = v + offset;
			impact.Play ();
		}
	}
}
