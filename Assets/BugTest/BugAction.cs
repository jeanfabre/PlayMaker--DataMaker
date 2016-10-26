// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	public class BugAction : FsmStateAction
	{

		public FsmString myFsmString = new FsmString();
		
		public override void Reset()
		{
		}
		
		public override void OnEnter()
		{
			if (myFsmString!=null)
			{
			UnityEngine.Debug.Log(myFsmString.Value);
			}else{
				UnityEngine.Debug.Log("myFsmString is null");
			}

			Finish ();
		}
	}
}
