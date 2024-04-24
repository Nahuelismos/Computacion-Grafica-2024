using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activdad11 : MonoBehaviour
{
	private Vector2[] uvs;
	private Vector3[] vertices;
    private int[] triangles;
    private GameObject objetoCuadrado;
	public Material material;
    void Start() {
        objetoCuadrado = new GameObject("Cuadrado");
        objetoCuadrado.AddComponent<MeshFilter>();
        objetoCuadrado.GetComponent<MeshFilter>().mesh = new Mesh();
        objetoCuadrado.AddComponent<MeshRenderer>();
        CreateModel();
        UpdateMesh();
        CreateMaterial();
    }

    void Update(){
		
	}
	
	private void CreateModel(){
		vertices = new Vector3[]{
			new Vector3(0,0,0),
			new Vector3(0,1,0),
			new Vector3(1,0,0),
			new Vector3(1,1,0)
		};
		
		uvs = new Vector2[] {
			new Vector2(0,0),
			new Vector2(0,1),
			new Vector2(1,0),
			new Vector2(1,1)
		};
		
		triangles = new int[]{
			0,1,2,
			1,3,2
		};
	}
	
	private void UpdateMesh(){
        objetoCuadrado.GetComponent<MeshFilter>().mesh.vertices = vertices;
		objetoCuadrado.GetComponent<MeshFilter>().mesh.uv = uvs;
        objetoCuadrado.GetComponent<MeshFilter>().mesh.triangles = triangles;
    }

	private void CreateMaterial(){
        objetoCuadrado.GetComponent<MeshRenderer>().material = material;
    }
}
