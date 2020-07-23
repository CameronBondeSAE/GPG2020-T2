using UnityEngine;

namespace Student_workspace.Cam
{
	public interface IColourChanger
	{
		void ChangedColour(Color newColour);
	}

	public interface IHealth
	{
		int  health { get; set; }
		void ChangedHealth(int newHealth);
	}


	public class Thing : MonoBehaviour, IColourChanger, IHealth
	{
		[SerializeField]
		private int _health;

		public int health
		{
			get => _health;
			set => _health = value;
		}

		public void ChangedHealth(int newHealth)
		{
		}
		
		public void ChangedColour(Color newColour)
		{
			Debug.Log("Newcolour = "+newColour.ToString());
		}
	}
}

