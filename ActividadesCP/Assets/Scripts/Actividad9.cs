using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad9 : MonoBehaviour
{
	private Vector3[] vertices;
    private int[] triangles;
	private Color[] colores;
    //private GameObject miCamara, cubo;
	private GameObject[] cubo;
	void Start() {
		CreateModel(); 
		cubo = new GameObject[6];
		for(int i = 0; i<6; i++){
			string nombre = "cubo"+i;
			cubo[i] = new GameObject(nombre);
			cubo[i].AddComponent<MeshFilter>(); 
			cubo[i].GetComponent<MeshFilter>().mesh = new Mesh();
			cubo[i].AddComponent<MeshRenderer>();
			UpdateMesh(i);
		}
		
		moverCubos();
		CreateMaterial();
		
		
    }

    void Update() {
        
    }
	
	private void moverCubos(){
		cubo[1].transform.position = new Vector3(0,0,2);
		cubo[2].transform.position = new Vector3(0,0,4);
		cubo[3].transform.position = new Vector3(0,0,6);
		cubo[4].transform.position = new Vector3(2,0,2);
		cubo[5].transform.position = new Vector3(2,0,6);
	}
	private void CreateModel(){
		vertices = new Vector3[]{
			new Vector3(-1,1,1), //0
			new Vector3(1,1,1), //1
			new Vector3(1,1,-1), //2
			new Vector3(-1,1,-1), //3
			new Vector3(-1,-1,1), //4
			new Vector3(1,-1,1), //5
			new Vector3(1,-1,-1), //6
			new Vector3(-1,-1,-1), //7
		};
		
		triangles = new int[]{
			0,1,3,
			3,1,2, //cara arriba
			7,5,4,
			5,7,6, //cara abajo
			3,4,0, 
			3,7,4, //cara izquierda
			5,2,1,
			5,6,2, //cara derecha
			4,1,0,
			4,5,1, //cara adelante
			6,3,2,
			6,7,3  //cara atras
		};
		
		colores = new Color[]{
			new Color(1,0,1), //0
			new Color(1,1,1), //1
			new Color(0,1,1), //2
			new Color(0,0,1), //3
			new Color(1,0,0), //4
			new Color(1,1,0), //5
			new Color(0,1,0), //6
			new Color(0,0,0)  //7
		};
	}
	
	private void UpdateMesh(int i) {
		cubo[i].GetComponent<MeshFilter>().mesh.vertices = vertices;
		cubo[i].GetComponent<MeshFilter>().mesh.triangles = triangles;
		cubo[i].GetComponent<MeshFilter>().mesh.colors = colores; 
		
    }
	
	private void CreateMaterial(){
		Material newMaterial = new Material(Shader.Find("ShaderBasico"));
		for(int i = 0; i<6; i++){
			cubo[i].GetComponent<MeshRenderer>().material = newMaterial;
		}
    }
}
