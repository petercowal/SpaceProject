using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject asteroidField;
	public GameObject enemyField;
	public GameObject planet;
	private Transform player;
	public int cellSize = 800;
	public Text scoreText;
	public Text shipText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;
	private int shipsKilled;
	float astProb = .3f;
	float enemyProb = .5f;
	float planetProb = .55f;

	Hashtable ht = new Hashtable();
	//string of three vals and gameobjects

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		//populate the first 9 sections, starting the player in the center
		for (int i = -2; i < 3; i++) {
			for (int j = -2; j < 3; j++) {
				for (int k = -2; k < 3; k++) {
					ht.Add ((i + "," + j + "," + k), spawnNew(cellSize * (new Vector3(i,j,k) + Random.insideUnitSphere * 0.5f)));
				}
			}
		}

		gameOver = false;
		restart = false;
		shipText.text = "";
		gameOverText.text = "";
		score = 0;
		shipsKilled = 0;
		UpdateScore ();

	}
	
	// Update is called once per frame
	void Update () {
		int xx, yy, zz;
		xx = (int)(player.position.x / cellSize);
		yy = (int)(player.position.y / cellSize);
		zz = (int)(player.position.z / cellSize);
		for (int i = xx-2; i < xx+3; i++) {
			for (int j = yy-2; j < yy+3; j++) {
				for (int k = zz-2; k < zz+3; k++) {
					//print ("Testing " + (i + "," + j + "," + k));
					if (!ht.ContainsKey (i + "," + j + "," + k)) {
						//print ("Generating");
						ht.Add ((i + "," + j + "," + k), spawnNew (cellSize * (new Vector3(i,j,k) + Random.insideUnitSphere * 0.5f)));
					}
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (gameOver)
		{
			if (Input.GetButton("Restart"))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void addKillShipScore (int newScoreValue){
		shipsKilled += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Asteroids Mined: " + score;
		shipText.text = "Ships Destroyed: " + shipsKilled;
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	GameObject spawnNew(Vector3 t){
		float whichOne = Random.value;
		Quaternion ang = Random.rotation;
		GameObject go = null;
		if (whichOne < astProb) {
			go = (GameObject)Instantiate (asteroidField, t, ang);
		} else if (whichOne < enemyProb) {
			go = (GameObject)Instantiate (enemyField, t, ang);
		} else if (whichOne < planetProb) {
			go = (GameObject)Instantiate (planet, t, ang);
		} 
		return go;
	}

}
