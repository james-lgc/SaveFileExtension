using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DSA.Extensions.Base;

[CreateAssetMenu(menuName = "Writers/SaveFileWriter", fileName = "SaveFileWriter")]
[System.Serializable]
public class SaveFileJsonWriter : JsonWriter<SaveFile>
{
	public SaveFile[] GetSaveFilesFromDisk(int startIndex, int buttonsLength)
	{
		SaveFile[] tempSaves = new SaveFile[buttonsLength];
		int offset = 0 + startIndex;
		for (int i = startIndex; i < buttonsLength; i++)
		{
			string tempPath = GetPath(i);
			try { tempSaves[i - offset] = ReadTFromJson(); }
			catch (System.Exception e)
			{
				e.ToString();
				tempSaves[i] = new SaveFile(sentID: i);
			}
		}
		return tempSaves;
	}

	protected override void WriteToJson(SaveFile tList)
	{
		base.WriteToJson(tList);
	}

	protected string GetPath(int sentIndex)
	{
		string path = "Assets/Resources/SaveFile" + sentIndex + ".json";
		return path;
	}

	public override void Process()
	{
		throw new NotImplementedException();
	}

	public override void Set()
	{
		throw new NotImplementedException();
	}
}
