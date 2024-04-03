using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad7_Cubo : MonoBehaviour
{
	private Vector3[] vertices;
    private int[] triangles;
	private Color[] colores;
    //private GameObject miCamara, cubo;
	private GameObject cubo;
	void Start() {
        cubo = new GameObject("cubo");
        cubo.AddComponent<MeshFilter>(); 
        cubo.GetComponent<MeshFilter>().mesh = new Mesh();
        cubo.AddComponent<MeshRenderer>();
		CreateModel(); 
		CreateMaterial();
		UpdateMesh();
       //CreateCamera();
    }

    void Update() {
        
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
	
	private void UpdateMesh() {
        cubo.GetComponent<MeshFilter>().mesh.vertices = vertices;
        cubo.GetComponent<MeshFilter>().mesh.triangles = triangles;
		cubo.GetComponent<MeshFilter>().mesh.colors = colores;
    }
	
	private void CreateMaterial()
    {
        Material newMaterial = new Material(Shader.Find("ShaderBasico"));
        cubo.GetComponent<MeshRenderer>().material = newMaterial;
    }
	
	/*private void CreateCamera() {
        miCamara = new GameObject("Camara");
        miCamara.AddComponent<Camera>();

        //----Posicion en el centro----
        miCamara.transform.position = new Vector3(-3,2.5f,-3);

        miCamara.transform.rotation = Quaternion.Euler(30,45,0);
        miCamara.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        miCamara.GetComponent<Camera>().backgroundColor = Color.white;
    }*/
}
