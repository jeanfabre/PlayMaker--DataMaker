// (c) Copyright HutongGames, LLC 2010-2012. All rights reserved.
//
// © 2012 Jean Fabre http://www.fabrejean.net

using UnityEngine;

using System.Xml;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("DataMaker Xml")]
	[Tooltip("Gets the xml content of an XmlProxy as a string")]
	public class XmlProxyGetXmlAsString : FsmStateAction
	{
		[Tooltip("The DataMaker Xml Proxy component to refresh")]
		[CheckForComponent(typeof(DataMakerXmlProxy))]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("Author defined Reference of the DataMaker Xml Proxy component ( necessary if several component coexists on the same GameObject")]
		public FsmString reference;

		[ActionSection("Result")]

		[Tooltip("The Xml content as string")]
		[RequiredField]
		public FsmString xmlString;
		
		public override void Reset ()
		{
			gameObject = null;
			reference = null;
			xmlString = null;
		}
		
		public override void OnEnter ()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
			
			if (go!=null)
			{
				DataMakerXmlProxy proxy = DataMakerCore.GetDataMakerProxyPointer(typeof(DataMakerXmlProxy), go, reference.Value, false) as DataMakerXmlProxy;
				
				if (proxy!=null) {
					xmlString.Value = proxy.content;
				}
			}
			
			Finish();
		}
		
	}
}