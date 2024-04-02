using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase2_5 : MonoBehaviour {
	private Vector3[] vertices;
    private int[] triangles;
	private Color[] colores;
    private GameObject objetoCuadrado, miCamara;
	[SerializeField] private Vector3 newPosition, newRotation, newScale;
	
	void Start() {
        objetoCuadrado = new GameObject("Cuadrado");
        objetoCuadrado.AddComponent<MeshFilter>();
        objetoCuadrado.GetComponent<MeshFilter>().mesh = new Mesh();
        objetoCuadrado.AddComponent<MeshRenderer>();
		CreateModel();
        UpdateMesh();
        CreateMaterial();
        CreateCamera();
		
		newPosition = new Vector3(0,0,0);
		newRotation = new Vector3(0, Mathf.Deg2Rad*45, 0);
		newScale = new Vector3(1,1,1);
		Matrix4x4 modelMatrix = CreateModelMatrix(newPosition, newRotation, newScale);
        objetoCuadrado.GetComponent<Renderer>().material.SetMatrix("_ModelMatrix", modelMatrix);
    }

    void Update() {
        
    }
	
	
    private void CreateModel()
    {
        vertices = new Vector3[]{
            new Vector3(0,0,0), //0
            new Vector3(0,0,1), //1
            new Vector3(1,0,0), //2
            new Vector3(1,0,1) //3
        };
        triangles = new int[]{
            0,1,2, //t1
            1,3,2  //t2
        };
		
		colores = new Color[]{
			new Color(84/255f,153/255f,199/255f), //0 -c3
			new Color(21/255f,67/255f,96/255f), //1 -c5
			new Color(21/255f,67/255f,96/255f), //2 -c5
			new Color(169/255f,204/255f,227/255f) //3 -c2
		};
    }
	
	private void UpdateMesh()
    {
        objetoCuadrado.GetComponent<MeshFilter>().mesh.vertices = vertices;
        objetoCuadrado.GetComponent<MeshFilter>().mesh.triangles = triangles;
	    objetoCuadrado.GetComponent<MeshFilter>().mesh.colors = colores;
    }

    private void CreateCamera()
    {
        miCamara = new GameObject("Camara");
        miCamara.AddComponent<Camera>();

        //miCamara.transform.position = new Vector3(0, 2, 0);
        //----Posicion en el centro----
        miCamara.transform.position = new Vector3(0.5f, 2, 0.5f);

        miCamara.transform.rotation = Quaternion.Euler(90, 0, 0);
        miCamara.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        miCamara.GetComponent<Camera>().backgroundColor = Color.black;
    }

    private void CreateMaterial()
    {
        Material newMaterial = new Material(Shader.Find("Standard"));
        objetoCuadrado.GetComponent<MeshRenderer>().material = newMaterial;
    }
	
	private Matrix4x4 CreateModelMatrix(Vector3 newPosition, Vector3 newRotation, Vector3 newScale){
		Matrix4x4 positionMatrix = new Matrix4x4(
			new Vector4(1f, 0f, 0f, newPosition.x),
			new Vector4(0f, 1f, 0f, newPosition.y),
			new Vector4(0f, 0f, 1f, newPosition.z),
			new Vector4(0f, 0f, 0f, 1f)
		);
		positionMatrix = positionMatrix.transpose;
		
		Matrix4x4 rotationMatrixX = new Matrix4x4(
			new Vector4(1f, 0f, 0f, 0f),
			new Vector4(0f, Mathf.Cos(newRotation.x), -Mathf.Sin(newRotation.x), 0f),
			new Vector4(0f, Mathf.Sin(newRotation.x), Mathf.Cos(newRotation.x), 0f),
			new Vector4(0f, 0f, 0f, 1f)
		);
		
		Matrix4x4 rotationMatrixY = new Matrix4x4(
			new Vector4(Mathf.Cos(newRotation.y), 0f, -Mathf.Sin(newRotation.y), 0f),
			new Vector4(0f, 1f, 0f, 0f),
			new Vector4(Mathf.Sin(newRotation.y), 0f, Mathf.Cos(newRotation.y), 0f),
			new Vector4(0f, 0f, 0f, 1f)
		);
		
		Matrix4x4 rotationMatrixZ = new Matrix4x4(
			new Vector4(Mathf.Cos(newRotation.z), -Mathf.Sin(newRotation.z), 0f, 0f),
			new Vector4(Mathf.Sin(newRotation.z), Mathf.Cos(newRotation.z), 0f, 0f),
			new Vector4(0f, 0f, 1f, 0f),
			new Vector4(0f, 0f, 0f, 1f)
		);
		
		Matrix4x4 rotationMatrix = rotationMatrixZ * rotationMatrixY * rotationMatrixX;
		rotationMatrix = rotationMatrix.transpose;
		
		Matrix4x4 scaleMatrix = new Matrix4x4(
			new Vector4(newScale.x, 0f, 0f, 0f),
			new Vector4(0f, newScale.y, 0f, 0f),
			new Vector4(0f, 0f, newScale.z, 0f),
			new Vector4(0f, 0f, 0f, 1f)
		);
		
		Matrix4x4 finalMatrix = positionMatrix;
		finalMatrix *= rotationMatrix;
		finalMatrix *= scaleMatrix;
		return (finalMatrix);
	}
}
