using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
	void Start()
	{
		// Custom Unity syntax for starting a timed/delay capable function
		StartCoroutine(DoSomethingCoroutine());
	}

	// Note the "IEnumerator" return type
	private IEnumerator DoSomethingCoroutine()
	{
		// I'm just doing a simple sequence of timed function calls
		DoSomething();
		yield return new WaitForSeconds(1);
		DoSomething();
		yield return new WaitForSeconds(2);
		DoSomething();
		yield return new WaitForSeconds(3);
		DoSomething();
		yield return new WaitForSeconds(4);
		DoSomething();
	}


	void DoSomething()
	{
		Debug.Log("I did something");
	}
}