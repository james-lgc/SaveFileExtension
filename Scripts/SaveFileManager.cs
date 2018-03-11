using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using DSA.Extensions.Base;

public abstract class SaveFileManager : ClickableCanvasedManagerBase<SaveFileCanvas>, IProcessor<SaveFile>
{
	[SerializeField] protected SaveFileJsonWriter writer;
	[SerializeField] protected SaveFile[] saveFiles = new SaveFile[3];
	[SerializeField] protected ManagerBase[] processLinkedManagers;

	protected string rootPath { get { return "Assets/Resources/SaveFile"; } }

	private SaveFile activeSaveFile;

	public abstract void Process(SaveFile sentSave);

	public override void Initialize()
	{
		base.Initialize();
		uiController.CancelAction = EndProcess;
	}

	public SaveFile[] GetManualSaveFiles()
	{
		SaveFile[] tempSaves = new SaveFile[3];
		BinaryFormatter formatter = new BinaryFormatter();
		for (int i = 0; i < tempSaves.Length; i++)
		{
			SaveFile tempSave;
			try
			{
				using (FileStream stream = new FileStream(rootPath + i, FileMode.Open))
				{
					tempSave = (SaveFile)formatter.Deserialize(stream);
				}
			}
			catch (System.Exception e)
			{
				e.ToString();
				tempSave = new SaveFile(i);
			}
			tempSaves[i] = tempSave;
		}
		return tempSaves;
	}
}
