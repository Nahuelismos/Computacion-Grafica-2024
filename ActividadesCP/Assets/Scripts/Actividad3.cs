using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad3: MonoBehaviour
{
    private Vector3[] vertices;
    private int[] triangles;
    private GameObject objetoEstrella, miCamara;
    private Color[] colores;
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

            new Vector3(0,0,2),    //10

            new Vector3(2*Mathf.Sin(2/5f*Mathf.PI),0,2*Mathf.Cos(2/5f*Mathf.PI)), //11
            new Vector3(2*Mathf.Sin(4/5f*Mathf.PI),0,2*Mathf.Cos(4/5f*Mathf.PI)), //12
            new Vector3(2*Mathf.Sin(6/5f*Mathf.PI),0,2*Mathf.Cos(6/5f*Mathf.PI)), //13
            new Vector3(2*Mathf.Sin(8/5f*Mathf.PI),0,2*Mathf.Cos(8/5f*Mathf.PI)), //14

            new Vector3(0,0,-1),  //15
            new Vector3((-1)*Mathf.Sin(2/5f*Mathf.PI),0,(-1)*Mathf.Cos(2/5f*Mathf.PI)), //16
            new Vector3((-1)*Mathf.Sin(4/5f*Mathf.PI),0,(-1)*Mathf.Cos(4/5f*Mathf.PI)), //17
            new Vector3((-1)*Mathf.Sin(6/5f*Mathf.PI),0,(-1)*Mathf.Cos(6/5f*Mathf.PI)), //18
            new Vector3((-1)*Mathf.Sin(8/5f*Mathf.PI),0,(-1)*Mathf.Cos(8/5f*Mathf.PI)), //19
	    
	    new Vector3(0,0,0),    //20
	    new Vector3(0,0,0),    //21
	    new Vector3(0,0,0),    //22
	    new Vector3(0,0,0),    //23
	    new Vector3(0,0,0),    //24
	    new Vector3(0,0,0),    //25
	    new Vector3(0,0,0),    //26
	    new Vector3(0,0,0),    //27
	    new Vector3(0,0,0),    //28
	    new Vector3(0,0,0)    //29
        };
        for(int i = 0; i < 11; i++)
        {
            Debug.Log(i+": " + vertices[i]);
        }
        triangles = new int[]{
            0,8,20, //t1
            18,11,21, //t2
            1,9,22, //t3
            19,12,23, //t4
            2,5,24, //t5
            15,13,25, //t6
            3,6,26, //t7
            6,4,27, //t8
            14,17,28, //t9
            7,10,29 //t10
        };
	
	colores = new Color[]{
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,1),

		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,1),

		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,0),
		new Color(0,0,1)
	};
    }

    private void UpdateMesh()
    {
        objetoEstrella.GetComponent<MeshFilter>().mesh.vertices = vertices;
        objetoEstrella.GetComponent<MeshFilter>().mesh.triangles = triangles;
	objetoEstrella.GetComponent<MeshFilter>().mesh.colors = colores;
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
        Material newMaterial = new Material(Shader.Find("ShaderBasico"));
        objetoEstrella.GetComponent<MeshRenderer>().material = newMaterial;
    }
}

