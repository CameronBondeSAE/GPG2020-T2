using UnityEngine;

namespace AnthonyY
{
	public class AvoidBehaviour : SteeringBehaviourBase
	{
		public float      distance = 3f;
		public float      turnSpeed = 2f;
		public float      direction = 1f;
		RaycastHit        hit;
		private bool      raycast;
		private Transform t;
		public  float     feelerRadius = 1f;

		// public override void OnStartServer()
		// {
		// t = transform;
		// base.OnStartServer();
		// }

		private void Start()
		{
			t = transform;
		}

		private void FixedUpdate()
		{
//                if (isServer)
			{
				Ray ray                = new Ray(t.position, t.forward);
				raycast = Physics.SphereCast(ray, feelerRadius, out hit, distance);
				
				if (raycast)
				{
					rb?.AddTorque(0, turnSpeed * direction, 0);
					// Debug.DrawLine(t.position, t.forward,gameObject.name,distance,Color.green);
				}

				// Mathf.PerlinNoise(turnSpeed, distance);
			}
		}

		void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawCube(hit.point, new Vector3(0.1f, 0.1f, 0.1f));
		}
	}
}