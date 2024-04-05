using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Clase3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
		string fileName = "Bed1";
		string path = "Assets/Objects/"+fileName+".obj";
		StreamReader reader = new StreamReader(path);
		string fileData = (reader.ReadToEnd());
		ReadEachLine(fileData);
		reader.Close();
		Debug.Log(fileData);
    }

    // Update is called once per frame
    void Update() {
        
    }
	
	void ReadEachLine(string fileData){
		string[] lines = fileData.Split('\n');
		int cantV = 0;
		int cantF = 0;
		for(int i = 0; i< lines.Length; i++){
			//Debug.Log(lines[i]);
			if(lines[i].StartsWith("v ")){
				//es un vector_string
				float[] vector_float = new float[3];
				string vector_string = " ";
				int pos_vector = 0;
				for(int j = 2; j< lines[i].Length; j++){
					if((lines[i][j] != ' ')){
						vector_string+=lines[i][j];
					} else{
						//Debug.Log(cantV+"-"+pos_vector+": "+vector_string);
						vector_float[pos_vector] = float.Parse(vector_string.Split(".")[0]) + float.Parse(vector_string.Split(".")[1])*Mathf.Pow(10,(-1)*vector_string.Split(".")[1].Length);
						pos_vector++;
						vector_string = "";
					}
				}
				//Debug.Log(cantV+"-"+pos_vector+": "+vector_string+"---");
				vector_float[pos_vector] = float.Parse(vector_string.Split(".")[0]) + float.Parse(vector_string.Split(".")[1])*Mathf.Pow(10,(-1)*(vector_string.Split(".")[1].Length-1));
				//Debug.Log(cantV+": <"+vector_float[0]+" - "+vector_float[1]+" - "+vector_float[2]+">");
				cantV++;
			} else if (lines[i].StartsWith("f ")){
				//es una cara
				int[] vertice_int = new int[9];
				string vertice_string = " ";
				int pos_vertice = 0;
				for(int j = 3; j< lines[i].Length; j++){
					if((lines[i][j] != ' ')	 && (lines[i][j] != '/')){
						vertice_string+=lines[i][j];
					}else{
						vertice_int[pos_vertice] = int.Parse(vertice_string);
						//Debug.Log(cantF+"-"+pos_vertice+": "+vertice_string);
						pos_vertice++;
						vertice_string = "";
					}
				}
				vertice_int[pos_vertice] = int.Parse(vertice_string);
				//Debug.Log(cantF+"-"+pos_vertice+": "+vertice_string);
				Debug.Log(cantF+": <"+vertice_int[0]+" - "+vertice_int[3]+" - "+vertice_int[6]+">");
				cantF++;
			}
		}
	}
}
