using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Clase3 : MonoBehaviour {
	
	private Vector3[] vertices;
    private int[] faces;
	private Color[] colores;
	[SerializeField] private List<GameObject> lista_objetos;
    void Start(){
		lista_objetos.Add(createModel("muebles/Bathroom/bath/Bath"));
		lista_objetos.Add(createModel("muebles/beds/bed1/bed1"));
		
		lista_objetos[0].transform.position = new Vector3(2,0,0);
	}
	
	GameObject createModel(string fileName){
		
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
		
		return objeto;
	}

    void Update() {
    }
	
	/**
	Presentacion (tema y quienes son)
	Que queremos hacer (un monoambiente)
	Expicar como se hizo
	Como es que funciona
	*/
	
	void ReadEachLine(string fileData){
		string[] lines = fileData.Split('\n');
		List<Vector3> lista_vertice = new List<Vector3>();
		List<int> lista_cara = new List<int>();
		Vector3 vertice_min = new Vector3(Mathf.Infinity,Mathf.Infinity, Mathf.Infinity); //cambiar por el flotante maximo posible
		Vector3 vertice_max = new Vector3(Mathf.NegativeInfinity, Mathf.NegativeInfinity, Mathf.NegativeInfinity); //cambiar por el flotante minimo posible 
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
						pos_vertice++; 
						vertice_string = "";
					}
				}
				vertice_float[pos_vertice] = float.Parse(vertice_string.ToString())*Mathf.Pow(10,(-1)*vertice_string.Split(".")[1].Length);
				Vector3 vertice_nuevo = new Vector3(vertice_float[0], vertice_float[1], vertice_float[2]);
				lista_vertice.Add(vertice_nuevo);
			} else if ((lines[i].StartsWith("f ")) || (lines[i].StartsWith("f  "))){
					string[] fila_separada = lines[i].Split(' ');
					Vector3[] valores_separados = new Vector3[fila_separada.Length-1];
					for(int k = 1; k< fila_separada.Length; k++){
						valores_separados[k-1] =  new Vector3(int.Parse(fila_separada[k].Split('/')[0])-1,int.Parse(fila_separada[k].Split('/')[1]), int.Parse(fila_separada[k].Split('/')[2]));
					}
					for (int l = 0; l< valores_separados.Length-2; l++){
						lista_cara.Add((int) (valores_separados[0].x));
						lista_cara.Add((int) (valores_separados[l+1].x));
						lista_cara.Add((int) (valores_separados[l+2].x));
					}
				
			}
		}
		Debug.Log ("cantidad de vertices: "+lista_vertice.Count+". cantidad de caras: "+(lista_cara.Count/3));	
		vertices = new Vector3[lista_vertice.Count];
		faces = new int[lista_cara.Count];
		
		foreach (Vector3 vert in lista_vertice){
			for (int m = 0; m <3; m++){
				if(vert[m] < vertice_min[m])
					vertice_min[m] = vert[m];
				if(vert[m] > vertice_max[m])
					vertice_max[m] = vert[m];
			}
		}
		
		Debug.Log("Vertice minimo: "+vertice_min+". Vertice maximo: "+vertice_max);
		
		for (int v = 0; v < lista_vertice.Count; v++){
			vertices[v] = lista_vertice[v]-(vertice_max+vertice_min)/2;
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
