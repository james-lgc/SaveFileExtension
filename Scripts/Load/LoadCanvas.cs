using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DSA.Extensions.Base;

public class LoadCanvas : SaveFileCanvas
{
	public override void Initialize()
	{
		base.Initialize();
		SetSendActions<SaveFile>(Process, 1);
	}

	public override void DisplayData()
	{
		if (ReceiveFunction == null) { return; }
		SaveFile[] saveFiles = ReceiveFunction();
		panels[1].SetData<SaveFile>(saveFiles);
		PrintableString[] texts = new PrintableString[] { new PrintableString("Load Game") };
		panels[0].SetData<DataItem>(texts);
		SetSelectedDisplayable(1, 0);
	}
}
