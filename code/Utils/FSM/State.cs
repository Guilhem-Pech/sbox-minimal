namespace murder.Utils.FSM
{
	public abstract class State
	{
		public virtual void Enter(StateMachine _context){}
		public virtual void Update(StateMachine _context){}
		public virtual void Exit(StateMachine _context){}
	}
}
