using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DSA.Extensions.Base;

public abstract class SaveFileCanvas : ClickableCanvas, ISendable<SaveFile>, IReceivable<SaveFile[]>, IProcessor<SaveFile>
{
	public override ExtensionEnum.Extension Extension { get { return ExtensionEnum.Extension.UI; } }

	public Action<SaveFile> SendAction { get; set; }

	public SaveFile Data { get; set; }

	public Func<SaveFile[]> ReceiveFunction { get; set; }

	public void Process(SaveFile sentSave)
	{
		if (SendAction == null) { return; }
		SendAction(sentSave);
	}
}
