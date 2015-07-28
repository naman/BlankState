using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class FetchPositions : MonoBehaviour {
	private Rigidbody[] people;
	private List<string[]> rowData = new List<string[]>();
	
	// Use this for initialization
	void Start () {
		people = GameObject.Find ("People").GetComponentsInChildren<Rigidbody>();
		Save ();
	}

	void Save(){
			string[] rowDataTemp = new string[6];
			rowDataTemp[0] = "ID";
			rowDataTemp[1] = "Time";
			rowDataTemp[2] = "Position(x)";
			rowDataTemp[3] = "Position(y)";
			rowDataTemp[4] = "Position(z)";
			rowData.Add(rowDataTemp);
	}

	// Update is called once per frame
	void FixedUpdate () {
		int id=1;
		foreach (Rigidbody i in people){
			string[] Temp = new string[6];
			Temp[0] = ""+id; // id
			Temp[1] = "" + Time.time; // Time
			Temp[2] = "" + i.position.x;
			Temp[3] = "" + i.position.y;
			Temp[4] = "" + i.position.z;	
			rowData.Add(Temp);
			id+=1;
		}
		string[][] output = new string[rowData.Count][];
			
		for (int i = 0; i < output.Length; i++)
			output [i] = rowData [i];

		int length = output.GetLength (0);
		string delimiter = ",";
		StringBuilder sb = new StringBuilder ();
			
		for (int index = 0; index < length; index++)
			sb.AppendLine (string.Join (delimiter, output [index]));
			
		string filePath = getPath ();
			
		StreamWriter outStream = System.IO.File.CreateText (filePath);
		outStream.WriteLine (sb);
		outStream.Close ();
	}
		// Following method is used to retrive the relative path as device platform
		private string getPath(){
			#if UNITY_EDITOR
			return Application.dataPath +"/CSV/"+"Positions.csv";
			#elif UNITY_ANDROID
			return Application.persistentDataPath+"Positions.csv";
			#elif UNITY_IPHONE
			return Application.persistentDataPath+"/"+"Positions.csv";
			#else
			return Application.dataPath +"/"+"Positions.csv";
			#endif
		}
}
