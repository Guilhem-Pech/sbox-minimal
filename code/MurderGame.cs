using MinimalExample;
using murder.Game;
using murder.Game.States;
using murder.Utils.FSM;
using Sandbox;

//
// You don't need to put things in a namespace, but it doesn't hurt.
//
namespace murder
{

	/// <summary>
	/// This is your game class. This is an entity that is created serverside when
	/// the game starts, and is replicated to the client. 
	/// 
	/// You can use this to create things like HUDs and declare which player class
	/// to use for spawned players.
	/// 
	/// Your game needs to be registered (using [Library] here) with the same name 
	/// as your game addon. If it isn't then we won't be able to find it.
	/// </summary>
	[Library( "murder" )]
	public partial class MurderGame : Sandbox.Game
	{
		StateMachine gameState;
		MinimalHudEntity hud;
		
		public MurderGame()
		{
			if ( IsServer )
			{
				gameState = new StateMachine();
				Log.Info( "My Gamemode Has Created Serverside!" );
				gameState.SetState( new WaitingForPlayers() );
				hud = new MinimalHudEntity();
			}

			if ( IsClient )
			{
				Log.Info( "My Gamemode Has Created Clientside!" );
			}
		}

		/// <summary>
		/// A client has joined the server. Make them a pawn to play with
		/// </summary>
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var player = new BasePlayer();
			client.Pawn = player;

			player.Respawn();
		}

		[Event.Tick.Server]
		public void TickServer()
		{
			if(gameState.CurrentState != null)
				gameState.Update();
		}
	}

}
