using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;
using HutongGames.Editor;
using HutongGames.PlayMaker;

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
			bool edited = false;

			VariableEditor.DebugVariables = true ; // How can I access FsmEditorSettings.DebugActionParameters ?;

			if (_target.myClass==null)
			{
				_target.myClass = new ClassWithFsmVariables();
			}

			FsmEditor.ActionEditor.EditField(_target.myClass, "MyName");


			// this works fine, but complex interfaces means I need to compound it. Can't find how to do this.
			//FsmEditor.ActionEditor.EditField(_target.myClass, "MyList");
			//FsmEditor.ActionEditor.EditField(_target.myClass, "MyVariables");
			// and this is where trouble starts :)

			edited = EditClassWithFsmVariablesFsmStringProperties(target.Fsm,_target.myClass);

			return GUI.changed || edited;
		}


	
		public static bool EditClassWithFsmVariablesFsmStringProperties(Fsm fsm,ClassWithFsmVariables target)
		{
			
			FsmEditorGUILayout.LightDivider();
			
			bool edited = false;
			
			int count = 0;
			
			if (target !=null && target.MyList !=null)
			{
				count = target.MyList.Length;
				
				
				for(int i=0;i<count;i++)
				{
					
					GUILayout.BeginHorizontal();
					
					GUILayout.Label("Property item "+i);
					GUILayout.FlexibleSpace();
					
					
					if (FsmEditorGUILayout.DeleteButton())
					{
						ArrayUtility.RemoveAt(ref target.MyList,i);
						return true; // we must not continue, an entry is going to be deleted so the loop is broken here. next OnGui, all will be well.
					}
					
					GUILayout.EndHorizontal();
					
					#if PLAYMAKER_1_8_OR_NEWER
					PlayMakerInspectorUtils.SetActionEditorArrayVariableSelectionContext(target,i,target.GetType().GetField("MyList"));
					#endif

					// HERE: I get 
				/*
				ArgumentException: Object type HutongGames.PlayMaker.FsmString cannot be converted to target type: HutongGames.PlayMaker.FsmString[]
					Parameter name: val
						System.Reflection.MonoField.SetValue (System.Object obj, System.Object val, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Globalization.CultureInfo culture) (at /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.Reflection/MonoField.cs:133)
							System.Reflection.FieldInfo.SetValue (System.Object obj, System.Object value) (at /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.Reflection/FieldInfo.cs:150)
							HutongGames.PlayMakerEditor.ActionEditor.DoVariableSelection (System.Object userdata) (at c:/Users/Alex/Documents/Unity/Playmaker/Projects/Playmaker.source.unity/Assets/PlayMaker/Editor/Classes/ActionEditor.cs:2893)
							UnityEditor.GenericMenu.CatchMenu (System.Object userData, System.String[] options, Int32 selected)
				*/
					target.MyList[i] = VariableEditor.FsmStringField(new GUIContent("Property"),fsm,target.MyList[i],null);

				}	
			}
			
			string _addButtonLabel = "Add a Property";
			
			if (count>0)
			{
				_addButtonLabel = "Add another Property";
			}
			
			GUILayout.BeginHorizontal();
			GUILayout.Space(154);
			
			if ( GUILayout.Button(_addButtonLabel) )
			{		
				
				if (target.MyList==null)
				{
					target.MyList = new FsmString[0];
				}
				
				
				ArrayUtility.Add<FsmString>(ref target.MyList, new FsmString());
				edited = true;	
			}
			GUILayout.Space(21);
			GUILayout.EndHorizontal();
			
			return edited || GUI.changed;
		}


	}
}