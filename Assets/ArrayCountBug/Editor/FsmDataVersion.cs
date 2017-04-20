using UnityEditor;
using UnityEngine;
using HutongGames.PlayMaker;

public class FsmDataVersion
{


	[MenuItem("PlayMaker/Tools/Addons/Update Fsm DataVersion")]
	static void UpdateDataVersion()
	{
		FsmTemplate _t = null;
		Fsm _fsm = null;


		GameObject _go = Selection.activeObject as GameObject;
		if (_go!=null)
		{
			PlayMakerFSM _pm = (PlayMakerFSM) _go.GetComponent<PlayMakerFSM>();

			if (_pm!=null)
			{
				_fsm = _pm.Fsm;
			}

		}


		if (_fsm==null)
		{

			_t =	Selection.activeObject as FsmTemplate;
			if (_t!=null)
			{
				_fsm = _t.fsm;
			}

		}

		if (_fsm==null)
		{
			Debug.LogWarning ("No Fsm Selected");
			return;
		}


		if (_fsm.DataVersion == 2) {
			Debug.Log ("fsm is already DataVersion 2. Nothing was executed.");
			return;
		}

		_fsm.UpdateDataVersion();

		_fsm.Preprocessed = false;

		if (_t!=null)
		{
			Debug.Log (_t.name +" FsmTemplate is now DataVersion "+_t.fsm.DataVersion+" and Preprocessing is resetted");
		}else
		{
			Debug.Log (_go.name +"/"+_fsm.Name+" is now DataVersion "+_fsm.DataVersion+" and Preprocessing is resetted");
		}

	}
}