using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

namespace UnityStandardAssets.Characters.ThirdPerson
{
public class FetchPositions : MonoBehaviour {
	public ThirdPersonCharacter[] people;
	private List<string[]> rowData = new List<string[]>();
	
	// Use this for initialization
	void Start () {
			Save ();
	}
	void Save(){
			string[] rowDataTemp = new string[3];
			rowDataTemp[0] = "ID";
			rowDataTemp[1] = "Time";
			rowDataTemp[2] = "Position (x,y,z)";
			rowData.Add(rowDataTemp);
	}

	// Update is called once per frame
	void Update () {
		ThirdPersonCharacter[] people = GetComponentsInChildren<ThirdPersonCharacter> ();
		
		int id=0;
		foreach (ThirdPersonCharacter i in people){
				string[] Temp = new string[3];
				Temp[0] = ""+id; // id
				Temp[1] = ""+Time.time; // Time
				Temp[2] = ""+i.transform.position;
				rowData.Add(Temp);
				id+=1;

		}
			string[][] output = new string[rowData.Count][];
			
			for(int i = 0; i < output.Length; i++){
				output[i] = rowData[i];
			}
			
			int     length         = output.GetLength(0);
			string     delimiter     = ",";
			
			StringBuilder sb = new StringBuilder();
			
			for (int index = 0; index < length; index++)
				sb.AppendLine(string.Join(delimiter, output[index]));
			
			
			string filePath = getPath();
			
			StreamWriter outStream = System.IO.File.CreateText(filePath);
			outStream.WriteLine(sb);
			outStream.Close();
	}
		// Following method is used to retrive the relative path as device platform
		private string getPath(){
			//#if UNITY_EDITOR
			return Application.dataPath +"/CSV/"+"Saved_data.csv";
			//#elif UNITY_ANDROID
			//return Application.persistentDataPath+"Saved_data.csv";
			//#elif UNITY_IPHONE
			//return Application.persistentDataPath+"/"+"Saved_data.csv";
			//#else
			//return Application.dataPath +"/"+"Saved_data.csv";
			//#endif
		}
}
}