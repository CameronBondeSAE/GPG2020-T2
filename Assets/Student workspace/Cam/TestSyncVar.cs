using System;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Camnumnum
{
	Numless,
	Num,
	Nummy,
	Nummiest
}

public class TestSyncVar : NetworkBehaviour
{
	[SyncVar]
	public bool boolTest;

	[SyncVar]
	public int intTest;

	[SyncVar]
	public Camnumnum camnumnum = Camnumnum.Numless;

	private void Start()
	{
		if (isServer)
		{
			InvokeRepeating("NUM", 0f, 1f);
		}
	}

	private void NUM()
	{
		// if (Random.Range(0, 60) == 0)
		{
			switch (Random.Range(0, 3))
			{
				case 0:
					camnumnum = Camnumnum.Numless;
					break;
				case 1:
					camnumnum = Camnumnum.Num;
					break;
				case 2:
					camnumnum = Camnumnum.Nummy;
					break;
				case 3:
					camnumnum = Camnumnum.Nummiest;
					break;
				default:
					Debug.Break();
					break;
			}
		}
	}
}