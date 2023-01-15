using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {
	
	
	public GameObject player;
	public Transform spawnPoint;
	public GameObject enemySpawner;
	public GameObject inGameUI;
	public Text statusText;

	void Start() 
	{
		inGameUI.SetActive(true);
		enemySpawner.SetActive(true);
		enemySpawner.GetComponent<EnemySpawner>().target = player;
	}


}
