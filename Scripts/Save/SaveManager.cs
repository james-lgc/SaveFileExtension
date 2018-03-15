using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DSA.Extensions.Base;

public class SaveManager : SaveFileManager
{
	public override ExtensionEnum Extension { get { return ExtensionEnum.Save; } }

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
		canvas.SetDisplayableArrayData<PrintableString>(new PrintableString[] { new PrintableString("Save Game") }, 0);
	}

	public override void Process(SaveFile sentSave)
	{
		ArrayList saveables = new ArrayList();
		for (int i = 0; i < processLinkedManagers.Length; i++)
		{
			processLinkedManagers[i].AddDataToArrayList(saveables);
		}
		SaveFile saveFile = new SaveFile(saveables, sentSave.ID);
		BinaryFormatter formatter = new BinaryFormatter();
		using (FileStream stream = new FileStream(rootPath + saveFile.ID, FileMode.Create))
		{
			formatter.Serialize(stream, saveFile);
		}
		canvas.DisplayData();
	}
}
