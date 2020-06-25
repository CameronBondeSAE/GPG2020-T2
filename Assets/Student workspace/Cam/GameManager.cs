using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public event Action startedEvent;
	public bool started;

	public void Start()
	{
		if (startedEvent != null)
		{
			startedEvent.Invoke();
		}
	}
}