using murder.Utils.FSM;

namespace murder.Game.States
{
	public class WaitingForPlayers : State
	{
		public override void Enter( StateMachine _context )
		{
			Sandbox.Log.Info( " State started " );
		}
	}
}
