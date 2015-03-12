// (c) copyright Hutong Games, LLC 2010-2014. All rights reserved.

using UnityEngine;
using System;
using System.Globalization;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.String)]
    [Tooltip("Gets an Rss compliant date string to inject in PubDate rss property.")]
    public class RssFeedGetPubDate : FsmStateAction
    {
		
		[Tooltip("The date. Set to none to use the current computer date")]
		public FsmString date;
		
		[Tooltip("The date format (if date is declared) ")]
		public FsmString dateFormat;
		
		[ActionSection("Result")]
        [RequiredField]
        [UIHint(UIHint.Variable)] 
        [Tooltip("The Rss compliant PubDate value for the date")]
        public FsmString pubDate;

        public override void Reset()
        {
            date = new FsmString() {UseVariable=true};
			dateFormat = "MM/dd/yyyy HH:mm";
			pubDate = null;
        }

		private DateTime _date;
		
        // Code that runs on entering the state.
        public override void OnEnter()
        {
			
			if (!date.IsNone && string.IsNullOrEmpty(date.Value) )
			{
				CultureInfo provider = CultureInfo.InvariantCulture;
				_date = DateTime.ParseExact(date.Value,dateFormat.Value,provider);
			}else{
				_date = DateTime.Now;
			}
			
			pubDate.Value = _date.ToString("ddd',' d MMM yyyy HH':'mm':'ss") + " " + _date.ToString("zzzz").Replace(":", "");				
        }

    }
}
