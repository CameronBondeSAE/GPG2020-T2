using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsExample : MonoBehaviour
{
	public GameManager gameManager;
	public bool started;
	
	// Start is called before the first frame update
	void Start()
	{
		gameManager.startedEvent += GameManagerStartedEvent;
	}

	
	private void GameManagerStartedEvent()
	{
		Debug.Log("Monster heard GameManager start");
	}

}
