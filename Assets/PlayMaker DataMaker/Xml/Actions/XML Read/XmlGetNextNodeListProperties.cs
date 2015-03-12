// (c) Copyright HutongGames, LLC 2010-2014. All rights reserved.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Xml;
using System.Xml.XPath;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("DataMaker Xml")]
	[Tooltip("Get the next node properties in a nodelist. \nEach time this action is called it gets the next node." +
	 	"This lets you quickly loop through all the nodelist to perform actions per nodes.")]
	public class XmlGetNextNodeListProperties : DataMakerXmlActions
	{
		[ActionSection("XML Source")]
			
		public FsmString nodeListReference;
		
		[ActionSection("Set up")]

		[Tooltip("Event to send for looping.")]
		public FsmEvent loopEvent;
		
		[Tooltip("Event to send when there are no more nodes.")]
		public FsmEvent finishedEvent;
		
		[ActionSection("Result")]
		
		[Tooltip("The index into the node List")]
		[UIHint(UIHint.Variable)]
		public FsmInt index;
		
		[Tooltip("The memory reference of the current node")]
		public FsmString reference;
		
		public FsmXmlPropertiesStorage storeProperties;
		

		// increment an index as we loop through items
		private int nextItemIndex;

		// are we there yet?
		private bool noMoreItems;
		
		
		private XmlNodeList _nodeList;
		
		public override void Reset()
		{
			nodeListReference = null;
			
			storeProperties = null;
			
			finishedEvent = null;
			loopEvent = null;
			
			index = null;
			reference = null;
		}
		
		public override void OnEnter()
		{
			if (_nodeList==null)
			{
				_nodeList = DataMakerXmlUtils.XmlRetrieveNodeList(nodeListReference.Value);
				if (_nodeList==null)
				{
					Fsm.Event(finishedEvent);
					return;
				}
			}
			
			DoGetNextNode();
			
			Finish();
		}
				
		void DoGetNextNode()
		{		
			// no more items?
			
			int _count = _nodeList.Count;
			
			
			if (nextItemIndex >= _count)
			{
				nextItemIndex = 0;
				Fsm.Event(finishedEvent);
				return;
			}

			// get next item properties
			index.Value = nextItemIndex;

			XmlNode _node = _nodeList[nextItemIndex];


			storeProperties.StoreNodeProperties(this.Fsm,_node);
		

			if (! string.IsNullOrEmpty(reference.Value))
			{
				DataMakerXmlUtils.XmlStoreNode(_node,reference.Value);
			}
			// no more items?

			if (nextItemIndex >= _count)
			{
				Fsm.Event(finishedEvent);
				nextItemIndex = 0;
				return;
			}
			
			// iterate to next 
			nextItemIndex++;
			
			if (loopEvent!=null){
				Fsm.Event(loopEvent);
			}
		}
	}
}