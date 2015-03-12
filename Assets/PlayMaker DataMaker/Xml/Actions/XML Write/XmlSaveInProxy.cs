// (c) Copyright HutongGames, LLC 2010-2012. All rights reserved.
//
// © 2012 Jean Fabre http://www.fabrejean.net
//
// To Learn about xPath syntax: http://msdn.microsoft.com/en-us/library/ms256471.aspx
//
using UnityEngine;

using System.Xml;
using System.Xml.XPath;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("DataMaker Xml")]
	[Tooltip("Save an xml string into a DataMaker Xml Proxy")]
	public class XmlSaveInProxy : DataMakerXmlNodeActions
	{
		
		[Tooltip("The xml reference")]
		public FsmString storeReference;
		
		[Tooltip("The xml source")]
		public FsmString xmlSource;
		
		[RequiredField]
		[Tooltip("The gameObject with the DataMaker Xml Proxy component")]
		[CheckForComponent(typeof(DataMakerXmlProxy))]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("Author defined Reference of the DataMaker Xml Proxy component ( necessary if several component coexists on the same GameObject")]
		public FsmString reference;
		
		public override void Reset ()
		{
			storeReference = new FsmString(){UseVariable=true};
			xmlSource = new FsmString(){UseVariable=true};
			gameObject = null;
			reference = null;
		}

		public override void OnEnter ()
		{
		
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
			
			DataMakerXmlProxy proxy = DataMakerCore.GetDataMakerProxyPointer(typeof(DataMakerXmlProxy), go, reference.Value, false) as DataMakerXmlProxy;
			
			if (proxy!=null) {
				
				if (!storeReference.IsNone)
				{
					proxy.InjectXmlNode(DataMakerXmlUtils.XmlRetrieveNode(storeReference.Value));
				}else if (!xmlSource.IsNone)
				{
					proxy.InjectXmlString(xmlSource.Value);
				}
			}
			
		
			
			Finish ();
		}

	}
}