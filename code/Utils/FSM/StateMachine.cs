using System.Collections.Generic;
using Sandbox;

namespace murder.Utils.FSM
{
	public class StateMachine
	{
		public State CurrentState { get; private set; }
		private readonly Dictionary<(State,int), State> _transitions = new(); // (from, transitionID) => to
		public void SetState(State state)
		{
			CurrentState.Exit( this );
			CurrentState = state;
			state.Enter( this );
		}

		public StateMachine AddTransition( State from, State to, int id )
		{
			_transitions[(from,id)]= to;
			return this;
		}
		
		public StateMachine RemoveTransition( State from, State to, int id )
		{
			_transitions[(from,id)]= null;
			return this;
		}

		public void TriggerTransition( int id )
		{
			if(_transitions.TryGetValue( (CurrentState,id), out State destination))
			{
				SetState( destination );
			}
		}
		
		public void Update()
		{
			CurrentState.Update( this );
		}
	}
}
