// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.
//
//
using UnityEngine;

using System.Xml;
using System.Xml.XPath;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("DataMaker Xml")]
	[Tooltip("Sets node properties and attributes. Use an xml reference.")]
	public class XmlSetNodeProperties : DataMakerXmlActions
	{
		
		[ActionSection("XML Node")]
		
		public FsmString xmlReference;
		
		[CompoundArray("Node Attributes", "Attribute", "Value")]
		public FsmString[] attributes;
		
		public FsmString[] attributesValues;
		
		[ActionSection("Feedback")]
		public FsmEvent errorEvent;
		
		public override void Reset ()
		{
			xmlReference = null;

			attributes = null;
			attributesValues = null;
			errorEvent = null;
		}

		public override void OnEnter ()
		{

			SetAttributes();
			
			
			Finish ();
		}
		
		
		private void SetAttributes ()
		{
			
		 	XmlNode _node = DataMakerXmlUtils.XmlRetrieveNode(xmlReference.Value);
			
			if (_node ==null)
			{
				Debug.LogWarning("XMl reference is empty, or likely invalid");
				
				Fsm.Event (errorEvent);
				return;
			}

			int att_i = 0;
			foreach (FsmString att in attributes) {
				SetNodeProperty(_node,att.Value,attributesValues[att_i].Value);
				att_i++;
			}
	
			Debug.Log(_node.OwnerDocument.OuterXml);
			Finish ();
		}
		
	}
}