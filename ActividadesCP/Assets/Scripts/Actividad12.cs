using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad12 : MonoBehaviour
{
    private Vector2[] uvs;
	private Vector3[] vertices;
    private int[] triangles;
    private GameObject objetoDado;
	public Material material;
    void Start() {
        objetoDado = new GameObject("Dado");
        objetoDado.AddComponent<MeshFilter>();
        objetoDado.GetComponent<MeshFilter>().mesh = new Mesh();
        objetoDado.AddComponent<MeshRenderer>();
        CreateModel();
        UpdateMesh();
        CreateMaterial();
    }

    void Update(){
		
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
			
			new Vector3(1,-1,-1), //8 = 6
			new Vector3(-1,-1,-1), //9 = 7
			new Vector3(-1,-1,-1), //10 = 7
			new Vector3(-1,-1,1), //11 = 4
			new Vector3(-1,-1,1), //12 = 4
			new Vector3(1,-1,1) //13 = 5
		};
		
		uvs = new Vector2[] {
			new Vector2(1/4f,2/3f),  //0
			new Vector2(2/4f,2/3f),  //1
			new Vector2(2/4f,1/3f),  //2
			new Vector2(1/4f,1/3f),  //3
			new Vector2(4/4f,2/3f),  //4
			new Vector2(3/4f,2/3f),  //5
			new Vector2(3/4f,1/3f),  //6
			new Vector2(4/4f,1/3f),  //7
			
			new Vector2(2/4f,0/3f), //8
			new Vector2(1/4f,0/3f), //9
			new Vector2(0/4f,1/3f), //10
			new Vector2(0/4f,2/3f), //11
			new Vector2(1/4f,3/3f), //12
			new Vector2(2/4f,3/3f)  //13
		};
		
		triangles = new int[]{
			0,1,3, //3
			3,1,2, //3
			7,5,4, //1
			5,7,6, //1
			3,11,0, //4 
			3,10,11, //4
			5,2,1, //2
			5,6,2, //2
			12,1,0, //6
			12,13,1, //6
			8,3,2, //5
			8,9,3  //5
		};
	}
	
	private void UpdateMesh(){
        objetoDado.GetComponent<MeshFilter>().mesh.vertices = vertices;
		objetoDado.GetComponent<MeshFilter>().mesh.uv = uvs;
        objetoDado.GetComponent<MeshFilter>().mesh.triangles = triangles;
    }

	private void CreateMaterial(){
        objetoDado.GetComponent<MeshRenderer>().material = material;
    }
}
