using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DSA.Extensions.Base;

public class SaveFileButton : UIButtonBase, ISettable<SaveFile>, ISendable<SaveFile>
{
	public override ExtensionEnum Extension { get { return ExtensionEnum.UI; } }

	public Action<SaveFile> SendAction { get; set; }

	public SaveFile Data { get; protected set; }

	public void Set(SaveFile sentItem)
	{
		Data = sentItem;
		SetText(sentItem.Text);
	}

	protected override void Use()
	{
		if (!GetIsExtensionLoaded()) { return; }
		try { SendAction(Data); }
		catch (System.Exception e) { Debug.Log(e.ToString()); }
	}
}
