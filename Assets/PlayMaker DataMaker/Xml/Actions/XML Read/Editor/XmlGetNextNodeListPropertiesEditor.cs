using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;

using HutongGames.PlayMaker;
using UnityEditor;
using UnityEngine;
using System;

[CustomActionEditor(typeof(XmlGetNextNodeListProperties))]
public class XmlGetNextNodeListPropertiesEditor : CustomActionEditor
{

    public override bool OnGUI()
    {
		bool edited = false;
		XmlGetNextNodeListProperties _target = (XmlGetNextNodeListProperties)target;
		
		EditField("nodeListReference");

		EditField("reset");
		EditField("loopEvent");
		EditField("finishedEvent");
		EditField("index");
		EditField("reference");
		
		edited = edited || DataMakerActionEditorUtils.EditFsmPropertiesStorage(_target.Fsm,_target.storeProperties);

		EditField("foundEvent");
		EditField("notFoundEvent");
		EditField("errorEvent");
		
		return GUI.changed || edited;
    }
	
}
