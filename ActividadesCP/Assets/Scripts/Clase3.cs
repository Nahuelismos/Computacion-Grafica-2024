using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Clase3 : MonoBehaviour {
	
	[SerializeField] private Vector3[] vertices;
    [SerializeField] private int[] triangles;
	private Color[] colores;
    private  GameObject objeto;
	void Start(){
		string fileName = "bed1";
		string path = "Assets/Objects/"+fileName+".obj";
		StreamReader reader = new StreamReader(path);
		
		string fileData = (reader.ReadToEnd());
		ReadEachLine(fileData);//create model
		
		
		objeto = new GameObject(fileName);
        objeto.AddComponent<MeshFilter>();
        objeto.GetComponent<MeshFilter>().mesh = new Mesh();
        objeto.AddComponent<MeshRenderer>();
		
		UpdateMesh();
        CreateMaterial();
		reader.Close();
		Debug.Log(fileData);
		
    }

    void Update() {
        
    }
	
	void ReadEachLine(string fileData){
		string[] lines = fileData.Split('\n');
		int cantV = 0;
		int cantF = 0;
		List<Vector3> lista_vertice = new List<Vector3>();
		List<Vector3> lista_triangulo = new List<Vector3>();
		for(int i = 0; i< lines.Length; i++){
			//Debug.Log(lines[i]);
			if(lines[i].StartsWith("v ")){
				//es un vertice_string
				float[] vertice_float = new float[3];
				string vertice_string = " ";
				int pos_vertice = 0;
				for(int j = 2; j< lines[i].Length; j++){
					if((lines[i][j] != ' ')){
						vertice_string+=lines[i][j];
					} else{
						//Debug.Log(cantV+"-"+pos_vertice+": "+vertice_string);
						vertice_float[pos_vertice] = float.Parse(vertice_string.Split(".")[0]) + float.Parse(vertice_string.Split(".")[1])*Mathf.Pow(10,(-1)*vertice_string.Split(".")[1].Length);
						pos_vertice++;
						vertice_string = "";
					}
				}
				//Debug.Log(cantV+"-"+pos_vertice+": "+vertice_string+"---");
				vertice_float[pos_vertice] = float.Parse(vertice_string.Split(".")[0]) + float.Parse(vertice_string.Split(".")[1])*Mathf.Pow(10,(-1)*(vertice_string.Split(".")[1].Length-1));
				//Debug.Log(cantV+": <"+vertice_float[0]+" - "+vertice_float[1]+" - "+vertice_float[2]+">");
				lista_vertice.Add(new Vector3(vertice_float[0], vertice_float[1], vertice_float[2]));
				cantV++;
			} else if (lines[i].StartsWith("f ")){
				//es una cara
				int[] triangulo_int = new int[9];
				string triangulo_string = " ";
				int pos_triangulo = 0;
				for(int j = 2; j< lines[i].Length; j++){//j=2 si es el cubo, j = 3 si son los normales.
					if((lines[i][j] != ' ')	 && (lines[i][j] != '/')){
						triangulo_string+=lines[i][j];
					}else{
						triangulo_int[pos_triangulo] = int.Parse(triangulo_string);
						//Debug.Log(cantF+"-"+pos_triangulo+": "+triangulo_string);
						pos_triangulo++;
						triangulo_string = "";
					}
				}
				triangulo_int[pos_triangulo] = int.Parse(triangulo_string);
				//Debug.Log(cantF+"-"+pos_triangulo+": "+triangulo_string);
				//Debug.Log(cantF+": <"+triangulo_int[0]+" - "+triangulo_int[3]+" - "+triangulo_int[6]+">"); //0,3,6 si es normal, 0,1,2 si es el cubo
				lista_triangulo.Add(new Vector3(triangulo_int[0]-1, triangulo_int[3]-1,  triangulo_int[6]-1));
				cantF++;
			}
		}
		Debug.Log ("cantidad de vertices: "+lista_vertice.Count+". cantidad de triangulos: "+lista_triangulo.Count);	
		vertices = new Vector3[cantV];
		triangles = new int[3*cantF];
		//foreach(Vector3 v in lista_vertice){}
		//foreach(Vector3 v in lista_vertice){}
			
		for (int v = 0; v < lista_vertice.Count; v++){
			vertices[v] = lista_vertice[v];
		} 
			
		for(int f = 0; f < lista_triangulo.Count; f++){
			int t1 = (int)Mathf.Floor(lista_triangulo[f].x); 
			int t2 = (int)Mathf.Floor(lista_triangulo[f].y);
			int t3 = (int)Mathf.Floor(lista_triangulo[f].z);
			triangles[3*f+0] = t1;
			triangles[3*f+1] = t2;
			triangles[3*f+2] = t3;
			//Debug.Log(f+"--> "+(3*f+0)+": "+t1+", "+(3*f+1)+": "+t2+", "+(3*f+2)+": "+t3);
		}
	}

	private void UpdateMesh(){
        objeto.GetComponent<MeshFilter>().mesh.vertices = vertices;
        objeto.GetComponent<MeshFilter>().mesh.triangles = triangles;
    }

    private void CreateMaterial(){
        Material newMaterial = new Material(Shader.Find("ShaderBasico"));
        objeto.GetComponent<MeshRenderer>().material = newMaterial;
    }
}
