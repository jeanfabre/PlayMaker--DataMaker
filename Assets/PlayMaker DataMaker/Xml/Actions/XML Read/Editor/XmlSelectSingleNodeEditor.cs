using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;

using HutongGames.PlayMaker;
using UnityEditor;
using UnityEngine;
using System;

[CustomActionEditor(typeof(XmlSelectSingleNode))]
public class XmlSelectSingleNodeEditor : XmlCustomActionEditor
{

    public override bool OnGUI()
    {
		bool edited = false;
		XmlSelectSingleNode _target = (XmlSelectSingleNode)target;
	
		if (_target.xmlSource==null)
		{
			_target.xmlSource = new FsmXmlSource();
		}
	
		if (_target.xPath==null)
		{
			_target.xPath = new FsmXpathQuery();
		}
	
		edited = edited || DataMakerActionEditorUtils.EditFsmXmlSourceField(_target.Fsm,_target.xmlSource);
				
		edited = edited || DataMakerActionEditorUtils.EditFsmXpathQueryField(_target.Fsm,_target.xPath);
		
		EditField("xmlResult");
		EditField("storeReference");
		
		edited = edited || DataMakerActionEditorUtils.EditFsmPropertiesStorage(_target.Fsm,_target.storeProperties);

		EditField("foundEvent");
		EditField("notFoundEvent");
		EditField("errorEvent");
		
		return GUI.changed || edited;
    }
	
}
