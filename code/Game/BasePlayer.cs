using System;
using System.Collections.Generic;
using Sandbox;

namespace murder.Game
{
	public class BasePlayer : Player
	{
		public override void Respawn()
		{
			Controller = new WalkController();
			Animator = new StandardPlayerAnimator();
			Camera = new FirstPersonCamera();
			
			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			base.Respawn();
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			//
			// If you have active children (like a weapon etc) you should call this to 
			// simulate those too.
			//
			SimulateActiveChild( cl, ActiveChild );
		}
		
		public override void OnKilled()
		{
			base.OnKilled();

			EnableDrawing = false;
		}
	}
}
