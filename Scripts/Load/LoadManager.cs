using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DSA.Extensions.Base;

public class LoadManager : SaveFileManager
{
	public override ExtensionEnum Extension { get { return ExtensionEnum.Load; } }

	public override void Initialize()
	{
		base.Initialize();
		canvas.ReceiveFunction = GetManualSaveFiles;
		canvas.SendAction = Process;
	}

	protected override void StartProcess()
	{
		base.StartProcess();
		canvas.DisplayData();
	}

	public override void Process(SaveFile sentSave)
	{
		for (int i = 0; i < processLinkedManagers.Length; i++)
		{
			processLinkedManagers[i].ProcessArrayList(sentSave.Saveables);
		}
		EndProcess();
	}

}
