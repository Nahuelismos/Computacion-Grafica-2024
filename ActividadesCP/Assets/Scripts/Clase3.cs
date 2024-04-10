using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Clase3 : MonoBehaviour {
	
	[SerializeField] private Vector3[] vertices;
    [SerializeField] private int[] faces;
	private Color[] colores;
    void Start(){
		//lista_objetos.Add(createModel("bed1",3,3));
		//lista_objetos.Add(createModel("bed1"));
		createModel("Bed1");	
		createModel("muebles/Bathroom/bath/Bath");
    }
	
	void createModel(string fileName){
		
		string path = "Assets/Objects/"+fileName+".obj";
		StreamReader reader = new StreamReader(path);
		
		string fileData = (reader.ReadToEnd());
		ReadEachLine(fileData);//create model
		GameObject objeto = new GameObject(fileName.Split('/')[fileName.Split('/').Length-1]);
        //GameObject objeto = new GameObject(fileName);
		objeto.AddComponent<MeshFilter>();
        objeto.GetComponent<MeshFilter>().mesh = new Mesh();
        objeto.AddComponent<MeshRenderer>();
		
		UpdateMesh(objeto);
        CreateMaterial(objeto);
		reader.Close();
		Debug.Log(fileData);
		
	}

    void Update() {
        
    }
	
	void ReadEachLine(string fileData){
		string[] lines = fileData.Split('\n');
		List<Vector3> lista_vertice = new List<Vector3>();
		List<int> lista_cara = new List<int>();
		for(int i = 0; i< lines.Length; i++){
			if(lines[i].StartsWith("v ")){
				float[] vertice_float = new float[3];
				string vertice_string = " ";
				int pos_vertice = 0;
				for(int j = 2; j< lines[i].Length; j++){
					if((lines[i][j] != ' ')){
						vertice_string+=lines[i][j];
					} else{
						vertice_float[pos_vertice] = float.Parse(vertice_string.ToString())*Mathf.Pow(10,(-1)*vertice_string.Split(".")[1].Length);
						//float f1 = float.Parse(vertice_string.Split(".")[0]);
						//float f2 = float.Parse(vertice_string.Split(".")[1])*Mathf.Pow(10,(-1)*vertice_string.Split(".")[1].Length);
						//f2+=f1;
						Debug.Log(lista_vertice.Count+" "+pos_vertice+":"+(float.Parse(vertice_string.ToString())*Mathf.Pow(10,(-1)*vertice_string.Split(".")[1].Length))+".");
						pos_vertice++; 
						vertice_string = "";
					}
				}
				vertice_float[pos_vertice] = float.Parse(vertice_string.ToString())*Mathf.Pow(10,(-1)*vertice_string.Split(".")[1].Length);
				Vector3 vertice_nuevo = new Vector3(vertice_float[0], vertice_float[1], vertice_float[2]);
				lista_vertice.Add(vertice_nuevo);
				Debug.Log(vertice_nuevo);
			} else if (lines[i].StartsWith("f ")){
				//if((lines[i].Split(' ').Length-1) > 3){//resto los extremos
					lines[i] = lines[i].Replase("f  ","f ");
					Debug.Log((lines[i].Split(' ').Length-1)+": "+lines[i]);
					string[] fila_separada = lines[i].Split(' ');
					Vector3[] valores_separados = new Vector3[fila_separada.Length-1];
					for(int k = 1; k< fila_separada.Length; k++){
						valores_separados[k-1] =  new Vector3(int.Parse(fila_separada[k].Split('/')[0])-1,int.Parse(fila_separada[k].Split('/')[1]), int.Parse(fila_separada[k].Split('/')[2]));
					}
					for (int l = 0; l< valores_separados.Length-2; l++){
						//Debug.Log("v"+0+" v"+(l+1)+" v"+(l+2));
						lista_cara.Add((int) (valores_separados[0].x));
						lista_cara.Add((int) (valores_separados[l+1].x));
						lista_cara.Add((int) (valores_separados[l+2].x));
						if((lines[i].Split(' ').Length-1) > 3)
							Debug.Log("se añado a <"+valores_separados[0].x+" - "+valores_separados[l+1].x+" - "+valores_separados[l+2].x+">");
					}
				
			}
		}
		Debug.Log ("cantidad de vertices: "+lista_vertice.Count+". cantidad de caras: "+(lista_cara.Count/3));	
		vertices = new Vector3[lista_vertice.Count];
		faces = new int[lista_cara.Count];
			
		for (int v = 0; v < lista_vertice.Count; v++){
			vertices[v] = lista_vertice[v];
		} 
		for (int f = 0; f < lista_cara.Count; f++){
			faces[f] = lista_cara[f];
		}
	}

	private void UpdateMesh(GameObject objeto){
        objeto.GetComponent<MeshFilter>().mesh.vertices = vertices;
        objeto.GetComponent<MeshFilter>().mesh.triangles = faces;
    }

    private void CreateMaterial(GameObject objeto){
        Material newMaterial = new Material(Shader.Find("ShaderBasico"));
        objeto.GetComponent<MeshRenderer>().material = newMaterial;
    }
}
