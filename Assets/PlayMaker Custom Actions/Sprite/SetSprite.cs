// (c) Copyright HutongGames, LLC 2010-2017. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("sprite")]
	[Tooltip("Sets a Sprite on any GameObject. Object must have a Sprite Renderer.")]
	public class SetSprite : FsmStateAction
	{
		
		[RequiredField]
		[Tooltip("The GameObject with a Sprite Renderer Component or a Ui Image component.")]
		public FsmOwnerDefault gameObject;

		[ObjectType(typeof(Sprite))]
		[Tooltip("The Sprite to set")]
		public FsmObject sprite;

		private SpriteRenderer spriteRenderer;
		private Image spriteImage;



		public override void Reset()
		{
			gameObject = null;
			sprite = null;
		}
		
		public override void OnEnter()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null) return;
			
			spriteRenderer = go.GetComponent<SpriteRenderer>();

			spriteImage = go.GetComponent<Image>();


			bool ok = DoSetSprite();

			if (!ok)
			{
				LogError("SetSprite: Missing SpriteRenderer or Image component!");
				return;
			}

			Finish();
		}

		bool DoSetSprite()
		{
			if (spriteRenderer) {
				spriteRenderer.sprite = sprite.Value as Sprite;
				return true;
			}

			if (spriteImage) {
				spriteImage.sprite = sprite.Value as Sprite;
				return true;
			}

			return false;
		}
	}
}
