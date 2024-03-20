using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad2 : MonoBehaviour
{
    private Vector3[] vertices;
    private int[] triangles;
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
        CreateCamera();
    }

    void Update()
    {
      
    }

    private void CreateModel()
    {
        new Vector3(0, 0, 2);
     
        vertices = new Vector3[]{
            new Vector3(0,0,0),     //0
            new Vector3(0,0,3.5f),     //1
            new Vector3(1,0,0),     //2
            new Vector3(1,0,3.5f),  //3
            new Vector3(2,0,3.5f),  //4
            new Vector3(2,0,2.5f),  //5
            new Vector3(1,0,2.5f),  //6
            new Vector3(1,0,2),     //7
            new Vector3(2,0,2),     //8
            new Vector3(1,0,1),     //9
            new Vector3(2,0,1)      //10
        };
        triangles = new int[]{
            0,1,2, //t1
            1,3,2, //t2
            6,3,4, //t3
            6,4,5, //t4
            9,7,8, //t5
            9,8,10 //t6
        };
    }

    private void UpdateMesh()
    {
        objetoF.GetComponent<MeshFilter>().mesh.vertices = vertices;
        objetoF.GetComponent<MeshFilter>().mesh.triangles = triangles;
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
        objetoF.GetComponent<MeshRenderer>().material = newMaterial;
    }
}
