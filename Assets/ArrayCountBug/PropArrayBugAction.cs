using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class test {
		
		public string property;
		public bool variable;
	}
	
	
	public class PropArrayBugAction : FsmStateAction
	{


		public test[] properties;

		
		
		public override void Reset ()
		{
			
			properties = null;


		}
		
		public override void OnEnter ()
		{
			
			SelectSingleNode();
			
			Finish ();
		}
		
		
		private void SelectSingleNode ()
		{

			foreach (test prop in properties) 
			{
				UnityEngine.Debug.Log(prop.property+" "+prop.variable);

			}

			Finish ();
		}
		
	}
}