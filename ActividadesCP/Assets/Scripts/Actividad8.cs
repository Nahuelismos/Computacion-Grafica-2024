using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad8 : MonoBehaviour
{
    private Vector3[] vertices, verticesRotados;
    private int[] triangles;
	private Color[] colores;
    private GameObject objetoF, miCamara;

    void Start()
    {
		
        objetoF = new GameObject("LetraF");
        objetoF.AddComponent<MeshFilter>();
        objetoF.GetComponent<MeshFilter>().mesh = new Mesh();
        objetoF.AddComponent<MeshRenderer>();
        CreateModel();
        UpdateMesh();
        CreateMaterial();
    }

    void Update()
    {
      
    }

    private void CreateModel()
    {
        vertices = new Vector3[]{
            new Vector3(0,0,0),     //0
            new Vector3(0,0,3.5f),  //1
            new Vector3(1,0,0),     //2
            new Vector3(1,0,3.5f),  //3
            new Vector3(2,0,3.5f),  //4
            new Vector3(2,0,2.5f),  //5
            new Vector3(1,0,2.5f),  //6
            new Vector3(1,0,2),     //7
            new Vector3(2,0,2),     //8
            new Vector3(1,0,1),     //9
            new Vector3(2,0,1),      //10
			
			new Vector3(0,-1,0),     //11 -> ex 0
            new Vector3(0,-1,3.5f),  //12 -> ex 1
            new Vector3(1,-1,0),     //13 -> ex 2
            new Vector3(1,-1,3.5f),  //14 -> ex 3
            new Vector3(2,-1,3.5f),  //15 -> ex 4
            new Vector3(2,-1,2.5f),  //16 -> ex 5
            new Vector3(1,-1,2.5f),  //17 -> ex 6
            new Vector3(1,-1,2),     //18 -> ex 7
            new Vector3(2,-1,2),     //19 -> ex 8
            new Vector3(1,-1,1),     //20 -> ex 9
            new Vector3(2,-1,1)      //21 -> ex 10
			//pude haber usado un for con i=0 e i=1 y completar las dos filas.
        };
		
		for(int i = 0; i <= 21; i++){
			Vector3 vec_aux  = new Vector3 (vertices[i].y,vertices[i].z,vertices[i].x);
			vertices[i] = vec_aux;
		}
        triangles = new int[]{
            0,1,2, //t1
            1,3,2, //t2
            6,3,4, //t3
            6,4,5, //t4
            9,7,8, //t5
            9,8,10, //t6
			
			11,13,12, //t7
            12,13,14, //t8
            17,15,14, //t9
            17,16,15, //t10
            20,19,18, //t11
            20,21,19 //t12
        };
		
		colores = new Color[]{
			new Color(0.1f,0.1f,0.1f), //0
			new Color(0.25f,0.25f,0.25f), //1
			new Color(0.5f,0.5f,0.5f), //2
			new Color(0.65f,0.65f,0.65f),  //3
			new Color(0.1f,0.1f,0.1f),  //4
			new Color(0.25f,0.25f,0.25f),  //5
			new Color(0.5f,0.5f,0.5f),  //6
			new Color(0.65f,0.65f,0.65f),  //7
			new Color(0.1f,0.1f,0.1f),  //8
			new Color(0.25f,0.25f,0.25f),  //9
			new Color(0.5f,0.5f,0.5f),  //10
			new Color(0.65f,0.65f,0.65f),  //11
			new Color(0.1f,0.1f,0.1f),  //12
			new Color(0.25f,0.25f,0.25f),  //13
			new Color(0.5f,0.5f,0.5f),   //14
			new Color(0.65f,0.65f,0.65f),  //15
			new Color(0.1f,0.1f,0.1f),  //16
			new Color(0.25f,0.25f,0.25f),  //17
			new Color(0.5f,0.5f,0.5f),  //18
			new Color(0.65f,0.65f,0.65f),  //19
			new Color(0.1f,0.1f,0.1f),  //20
			new Color(0.25f,0.25f,0.25f)  //11
			
		};
		
    }

    private void UpdateMesh()
    {
        objetoF.GetComponent<MeshFilter>().mesh.vertices = vertices;
        objetoF.GetComponent<MeshFilter>().mesh.triangles = triangles;
		objetoF.GetComponent<MeshFilter>().mesh.colors = colores;
    }

    private void CreateMaterial()
    {
        Material newMaterial = new Material(Shader.Find("ShaderBasico"));
        objetoF.GetComponent<MeshRenderer>().material = newMaterial;
    }
}
