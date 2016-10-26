using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;
using UnityEditor;
using UnityEngine;
using System.Collections;

using System.Reflection;
using HutongGames.PlayMaker.Ecosystem.Utils;

namespace HutongGames.PlayMakerEditor
{
	[CustomActionEditor(typeof(BugAction))]
	public class BugActionCustomEditor : CustomActionEditor
	{


		public override bool OnGUI()
		{
			var _target = target as BugAction;

			/*
			var _editingObject_Field = typeof(ActionEditor).GetField("editingObject", 
			                                                         BindingFlags.Static | 
			                                                         BindingFlags.NonPublic);
			_editingObject_Field.SetValue(null, _target);
			
			var _editingField_Field = typeof(ActionEditor).GetField("editingField", 
			                                                        BindingFlags.Static | 
			                                                        BindingFlags.NonPublic);
			_editingField_Field.SetValue(null, _target.GetType().GetField("myFsmString"));
			*/
			
			//ActionEditor.editingObject = _target;
			//ActionEditor.editingField = _target.GetType().GetField("myFsmString");

			PlayMakerInspectorUtils.SetActionEditorVariableSelectionContext(_target,_target.GetType().GetField("myFsmString"));
			_target.myFsmString = VariableEditor.FsmStringField(new GUIContent("Fsm String"),_target.Fsm,_target.myFsmString,null);
			
			return GUI.changed;
		}


	}
}