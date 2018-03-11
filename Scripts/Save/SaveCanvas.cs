using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DSA.Extensions.Base;

public class SaveCanvas : SaveFileCanvas
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
		PrintableString[] texts = new PrintableString[] { new PrintableString("Save Game") };
		panels[0].SetData<DataItem>(texts);
		SetSelectedDisplayable(1, 0);
	}

}
