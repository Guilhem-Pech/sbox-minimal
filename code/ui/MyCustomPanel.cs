using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace murder
{
	public class MyCustomPanel : Panel
	{
		public Label Label;

		public MyCustomPanel()
		{
			Label = Add.Label( "100", "value" );
		}
		
		public override void Tick()
		{
			var player = Local.Pawn;
			if ( player == null ) return;
			
			Label.Text = $"xXx{Local.Client.Name}xXx";
		}
	}
}
