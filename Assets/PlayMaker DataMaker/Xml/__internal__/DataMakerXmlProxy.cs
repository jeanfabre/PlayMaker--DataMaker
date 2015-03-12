// (c) Copyright HutongGames, LLC 2010-2012. All rights reserved.
//
// © 2012 Jean Fabre http://www.fabrejean.net
//
//
using UnityEngine;
using System.Collections;

using HutongGames.PlayMaker;

using System.Xml;


public class DataMakerXmlProxy : DataMakerProxyBase {
	
	static public bool delegationActive = true;
	
	public bool useSource;
	public TextAsset XmlTextAsset;
		
	[HideInInspector]
	public XmlNode xmlNode;
	
	[HideInInspector]
	public string content;
	
	public PlayMakerFSM FsmEventTarget;
	
	void Awake () {
		
		
		if (useSource && XmlTextAsset!=null)
		{
			InjectXmlString(XmlTextAsset.text);
		}
		
		RegisterEventHandlers();

	}
	
	void RefreshContent()
	{
		content = DataMakerXmlUtils.XmlNodeToString(xmlNode);
	}
	
	public void InjectXmlNode(XmlNode node)
	{
		
		xmlNode = node;
		
		RegisterEventHandlers();
	}
	
	public void InjectXmlNodeList(XmlNodeList nodeList)
	{
		 XmlDocument doc = new XmlDocument();
    	xmlNode =  doc.CreateElement("root");
		foreach(XmlNode _node in nodeList)
		{
			xmlNode.AppendChild(_node);
		}
	
		RegisterEventHandlers();
		
		Debug.Log(DataMakerXmlUtils.XmlNodeToString(xmlNode));
	}
	
	public void InjectXmlString(string source)
	{
		xmlNode = DataMakerXmlUtils.StringToXmlNode(source);
		
		RegisterEventHandlers();
		
	}
	
	
	private void UnregisterEventHandlers()
	{
		// Is it required? since the xmlnode is going to be garbage collected??!
		
		//	xmlNode.OwnerDocument.NodeChanged = null; new XmlNodeChangedEventHandler(NodeTouchedHandler);
		//	xmlNode.OwnerDocument.NodeInserted += new XmlNodeChangedEventHandler(NodeTouchedHandler);
		//	xmlNode.OwnerDocument.NodeRemoved += new XmlNodeChangedEventHandler(NodeTouchedHandler);
	}
	
	private void RegisterEventHandlers()
	{
		if (xmlNode!=null)
		{
			if (xmlNode.OwnerDocument==null)
			{
				Debug.LogWarning("Missing OwnerDocument for xmlnode: "+xmlNode.Name);
				return;
			}

			xmlNode.OwnerDocument.NodeChanged += new XmlNodeChangedEventHandler(NodeTouchedHandler);
			xmlNode.OwnerDocument.NodeInserted += new XmlNodeChangedEventHandler(NodeTouchedHandler);
			xmlNode.OwnerDocument.NodeRemoved += new XmlNodeChangedEventHandler(NodeTouchedHandler);
		}
	}
	
	 //Define the event handler.
	 void NodeTouchedHandler(object src, XmlNodeChangedEventArgs args)
	 {
	  	Debug.Log("Node " + args.Node.Name + " action:"+args.Action);
		
		if (FsmEventTarget==null || ! delegationActive)
		{
			return;
		}
		
		if(args.Action == XmlNodeChangedAction.Insert)
		{
			PlayMakerUtils.SendEventToGameObject(FsmEventTarget,FsmEventTarget.gameObject,"XML / INSERTED");
		}else if(args.Action == XmlNodeChangedAction.Change)
		{
			PlayMakerUtils.SendEventToGameObject(FsmEventTarget,FsmEventTarget.gameObject,"XML / CHANGED");
		}else if(args.Action == XmlNodeChangedAction.Remove)
		{
			PlayMakerUtils.SendEventToGameObject(FsmEventTarget,FsmEventTarget.gameObject,"XML / REMOVED");
		}
	}
	
}
