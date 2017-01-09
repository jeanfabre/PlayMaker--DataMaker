Few Mentions on possible improvments of the API:

-- I can't seem to be able to access FsmEditorSettings class?

-- when I try to show a regular property field inside an array of say FsmString, I get this:

ArgumentException: Object type HutongGames.PlayMaker.FsmString cannot be converted to target type: HutongGames.PlayMaker.FsmString[]
Parameter name: val
System.Reflection.MonoField.SetValue (System.Object obj, System.Object val, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Globalization.CultureInfo culture) (at /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.Reflection/MonoField.cs:133)
System.Reflection.FieldInfo.SetValue (System.Object obj, System.Object value) (at /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.Reflection/FieldInfo.cs:150)
HutongGames.PlayMakerEditor.ActionEditor.DoVariableSelection (System.Object userdata) (at c:/Users/Alex/Documents/Unity/Playmaker/Projects/Playmaker.source.unity/Assets/PlayMaker/Editor/Classes/ActionEditor.cs:2893)
UnityEditor.GenericMenu.CatchMenu (System.Object userData, System.String[] options, Int32 selected)


It's line 91 of BugActionCustomEditor.


