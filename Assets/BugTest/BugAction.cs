// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	public class BugAction : FsmStateAction
	{

		public ClassWithFsmVariables myClass = new ClassWithFsmVariables();

		public override void Reset()
		{

		}

		public override void OnEnter()
		{
			if (myClass!=null)
			{
				UnityEngine.Debug.Log(myClass.MyName);
			}else{
				UnityEngine.Debug.Log("myFsmString is null");
			}

			Finish ();
		}
	}



	public class ClassWithFsmVariables : FsmStateAction
	{
		public FsmString MyName;

		[CompoundArray("Properties", "MyList", "MyVariable")] // that would be a good alternatice, but I can't make it work within this class.
		public FsmString[] MyList;
		public FsmVar[] MyVariables;
	}
}





