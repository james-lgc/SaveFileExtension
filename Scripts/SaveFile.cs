using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System;

[System.Serializable]
public struct SaveFile
{
	[SerializeField] private string saveName;
	public string SaveName { get { return saveName; } }

	[SerializeField] private long saveTime;
	public long SaveTimeValue { get { return saveTime; } }
	public DateTime SaveTime { get { return DateTime.FromBinary(saveTime); } }
	public string Text
	{
		get
		{
			if (SaveTime == default(DateTime))
			{
				return "Empty Slot";
			}
			string dateTimeExtension = " - " + SaveTime.ToShortDateString() + " " + SaveTime.ToShortTimeString();
			string tempName = saveName;
			if (id == -1) { tempName = "AutoSave"; }
			else if (id == -2) { tempName = "QuickSave"; }
			return tempName + dateTimeExtension;
		}
	}

	[SerializeField] private ArrayList saveables;
	public ArrayList Saveables { get { return saveables; } }

	private int id;
	public int ID { get { return id; } }

	public SaveFile(ArrayList sentSaveables, int sentID = -1)
	{
		saveables = sentSaveables;
		saveTime = DateTime.Now.ToBinary();
		id = sentID;
		saveName = "Save File " + sentID;
	}

	public SaveFile(int sentID)
	{
		saveables = null;
		saveTime = default(DateTime).ToBinary();
		id = sentID;
		saveName = "Save File " + sentID;
	}

	public override bool Equals(object obj)
	{
		if (obj == null) return false;
		if (obj.GetType() != this.GetType()) return false;
		SaveFile sentSave = (SaveFile)obj;
		if (SaveTimeValue != sentSave.SaveTimeValue) { return false; }
		if (Saveables != sentSave.Saveables) { return false; }
		return true;
	}

	public override int GetHashCode()
	{
		return (int)saveTime ^ id;
	}

	public static bool operator ==(SaveFile saveFile1, SaveFile saveFile2)
	{
		return saveFile1.Equals(saveFile2);
	}

	public static bool operator !=(SaveFile saveFile1, SaveFile saveFile2)
	{
		return !saveFile1.Equals(saveFile2);
	}

	public static bool operator <(SaveFile saveFile1, SaveFile saveFile2)
	{
		if (saveFile1.SaveTimeValue < saveFile2.SaveTimeValue) { return true; }
		return false;
	}

	public static bool operator >(SaveFile saveFile1, SaveFile saveFile2)
	{
		if (saveFile1.SaveTimeValue > saveFile2.SaveTimeValue) { return true; }
		return false;
	}

	public static bool operator <=(SaveFile saveFile1, SaveFile saveFile2)
	{
		if (saveFile1.SaveTimeValue <= saveFile2.SaveTimeValue) { return true; }
		return false;
	}

	public static bool operator >=(SaveFile saveFile1, SaveFile saveFile2)
	{
		if (saveFile1.SaveTimeValue >= saveFile2.SaveTimeValue) { return true; }
		return false;
	}
}
