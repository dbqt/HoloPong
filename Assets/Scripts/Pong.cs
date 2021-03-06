﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pong : MonoBehaviour {

	private static Pong instance;

	public static Pong GetInstance() {
		return instance;
	}

	public GameObject ballPrefab;

	public float ballSpeed = 1.0f;

	public Transform playerPaddle;
	public float maxPos, minPos;

	public GameObject currentball;

	public Text player, enemy;

	int scorePlayer = 0, scoreEnemy = 0;

	// Use this for initialization
	void Start () {
		instance = this;
		Reset();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void StartGame() {
		currentball = Instantiate (ballPrefab, playerPaddle.position, Quaternion.identity) as GameObject;
	}

	public void updatePlayer(Vector3 pos) {

		Vector3 d = pos - this.transform.position;
		var newpos = playerPaddle.transform.position;
		newpos.x = Mathf.Max(Mathf.Min(d.x, maxPos), minPos);
		newpos.y = Mathf.Max(Mathf.Min(d.y, maxPos), minPos);
		playerPaddle.transform.position = newpos;
	}

	public void incrementPoint(bool isPlayer) {
		if(isPlayer) scorePlayer++;
		else scoreEnemy++;

		updateScore();
	}

	public void Reset(){
		scorePlayer = 0;
		scoreEnemy = 0;
		updateScore();
	}

	void updateScore() {
		player.text = "Player: " + scorePlayer;
		enemy.text = "AI: " + scoreEnemy;
	}
}
