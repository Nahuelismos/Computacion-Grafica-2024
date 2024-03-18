using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad3: MonoBehaviour
{
    private Vector3[] vertices;
    private int[] triangles;
    private GameObject objetoEstrella, miCamara;

    void Start()
    {
        objetoEstrella = new GameObject("Estrella");
        objetoEstrella.AddComponent<MeshFilter>();
        objetoEstrella.GetComponent<MeshFilter>().mesh = new Mesh();
        objetoEstrella.AddComponent<MeshRenderer>();
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
        vertices = new Vector3[]{
            new Vector3(0,0,2),     //0
            new Vector3(2*Mathf.Sin(2/5f*Mathf.PI),0,2*Mathf.Cos(2/5f*Mathf.PI)), //1
            new Vector3(2*Mathf.Sin(4/5f*Mathf.PI),0,2*Mathf.Cos(4/5f*Mathf.PI)), //2
            new Vector3(2*Mathf.Sin(6/5f*Mathf.PI),0,2*Mathf.Cos(6/5f*Mathf.PI)), //3
            new Vector3(2*Mathf.Sin(8/5f*Mathf.PI),0,2*Mathf.Cos(8/5f*Mathf.PI)), //4

            new Vector3(0,0,-1),  //5
            new Vector3((-1)*Mathf.Sin(2/5f*Mathf.PI),0,(-1)*Mathf.Cos(2/5f*Mathf.PI)), //6
            new Vector3((-1)*Mathf.Sin(4/5f*Mathf.PI),0,(-1)*Mathf.Cos(4/5f*Mathf.PI)), //7
            new Vector3((-1)*Mathf.Sin(6/5f*Mathf.PI),0,(-1)*Mathf.Cos(6/5f*Mathf.PI)), //8
            new Vector3((-1)*Mathf.Sin(8/5f*Mathf.PI),0,(-1)*Mathf.Cos(8/5f*Mathf.PI)), //9

            new Vector3(0,0,0)    //10
        };
        for(int i = 0; i < 11; i++)
        {
            Debug.Log(i+": " + vertices[i]);
        }
        triangles = new int[]{
            0,8,7, //t1
            1,9,8, //t2
            2,5,9, //t3
            3,6,5, //t4
            4,7,6, //t5
            7,8,10, //t6
            8,9,10, //t7
            9,5,10, //t8
            5,6,10, //t9
            6,7,10 //t10
        };
    }

    private void UpdateMesh()
    {
        objetoEstrella.GetComponent<MeshFilter>().mesh.vertices = vertices;
        objetoEstrella.GetComponent<MeshFilter>().mesh.triangles = triangles;
    }

    private void CreateCamera()
    {
        miCamara = new GameObject("Camara");
        miCamara.AddComponent<Camera>();

        //----Posicion en el centro----
        miCamara.transform.position = new Vector3(0,4,0);

        miCamara.transform.rotation = Quaternion.Euler(90, 0, 0);
        miCamara.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        miCamara.GetComponent<Camera>().backgroundColor = Color.black;
    }

    private void CreateMaterial()
    {
        Material newMaterial = new Material(Shader.Find("Standard"));
        objetoEstrella.GetComponent<MeshRenderer>().material = newMaterial;
    }
}

