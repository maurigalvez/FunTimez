using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
namespace Core
{
	public class Projectile : Action  {


		public Transform shotPos;
		public float shotForce = 5000f;
		public float moveSpeed = 50f;

		public Rigidbody projectile;

		public bool isRunning = false;
		
		public override void OnEnter() 
		{
			Debug.Log("Projectile action OnEnter");
		}

		public override ActionResult OnExecute()
		{
			Debug.Log ("Prjection action OnExecute");
				
			Rigidbody shot = projectile;
			shot.MovePosition (shotPos.position);
			shot.velocity = Vector3.zero;
			shot.angularVelocity = Vector3.zero;
			shot.AddForce (shotPos.forward * shotForce);

			return ActionResult.SUCCESS;
		}
		
		public void Test()
		{
			Debug.Log ("Test");
		}
		
		public override void OnExit() 
		{
			Debug.Log("Projectile action OnExit");
		}
		
		public override void OnEnable() 
		{
			Debug.Log("Projectile action OnEnable");
		}
		
		public override void OnDisable() 
		{
			Debug.Log("Projectile action OnDisable");
		}


		private int counter = 1;
		void Update()
		{
			if (Input.GetMouseButtonUp (0)) {
				OnExecute ();
			}
		}
	}
}