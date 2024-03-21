using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad5 : MonoBehaviour
{
    private Vector3[] vertices;
    private int[] triangles;
    private GameObject[] objetoF;
    private GameObject miCamara;

    void Start()
    {
	CreateModel();
	for(int i = 0;i<1; i++){
        	objetoF[i] = new GameObject("LetraF"+i);
        	objetoF[i].AddComponent<MeshFilter>();
        	objetoF[i].GetComponent<MeshFilter>().mesh = new Mesh();
        	objetoF[i].AddComponent<MeshRenderer>();	
        	UpdateMesh(i);
	}
        CreateMaterial();
        CreateCamera();
    }

    void Update()
    {
      
    }

    private void CreateModel()
    {
        vertices = new Vector3[]{
            new Vector3(0,0,0),     //0
            new Vector3(0,0,1),     //1
	    new Vector3(1,0,0)	    //2
        };
        triangles = new int[]{
            0,1,2 //t1
        };
    }

    private void UpdateMesh(int i)
    {
        objetoF[i].GetComponent<MeshFilter>().mesh.vertices = vertices;
        objetoF[i].GetComponent<MeshFilter>().mesh.triangles = triangles;
    }

    private void CreateCamera()
    {
        miCamara = new GameObject("Camara");
        miCamara.AddComponent<Camera>();

        //----Posicion en el centro----
        miCamara.transform.position = new Vector3(1, 4, 2);

        miCamara.transform.rotation = Quaternion.Euler(90, 0, 0);
        miCamara.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        miCamara.GetComponent<Camera>().backgroundColor = Color.black;
    }

    private void CreateMaterial()
    {
        Material newMaterial = new Material(Shader.Find("Standard"));
	for(int i = 0;i<1;i++){
        	objetoF[i].GetComponent<MeshRenderer>().material = newMaterial;
	}
    }
}
