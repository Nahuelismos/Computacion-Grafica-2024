using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad3_4: MonoBehaviour
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
            0,8,20, //t1 -color3
            18,11,21, //t2 -color4  
            1,9,22, //t3 -color5 
            19,12,23, //t4 -color4 
            2,5,24, //t5 -color5 
            15,13,25, //t6 -color3 
            3,6,26, //t7 -color2 
            16,14,27, //t8 -color3
            4,7,28, //t9 -color1 
            17,10,29 //t10 -color2
        };
	
	colores = new Color[]{
		new Color(84/255f,153/255f,199/255f), //0 -c3
		new Color(21/255f,67/255f,96/255f), //1 -c5
		new Color(21/255f,67/255f,96/255f), //2 -c5
		new Color(169/255f,204/255f,227/255f), //3 -c2
		new Color(212/255f,230/255f,241/255f), //4 -c1
		new Color(21/255f,67/255f,96/255f), //5 -c5
		new Color(169/255f,204/255f,227/255f), //6 -c2
		new Color(212/255f,230/255f,241/255f), //7 -c1
		new Color(84/255f,153/255f,199/255f), //8 -c3
		new Color(21/255f,67/255f,96/255f), //9 -c5
		new Color(169/255f,204/255f,227/255f), //10 -c2
		new Color(31/255f,97/255f,141/255f), //11 -c4
		new Color(31/255f,97/255f,141/255f), //12 -c4
		new Color(84/255f,153/255f,199/255f), //13 -c3
		new Color(84/255f,153/255f,199/255f), //14 -c3
		new Color(84/255f,153/255f,199/255f), //15 -c3
		new Color(84/255f,153/255f,199/255f), //16 -c3
		new Color(169/255f,204/255f,227/255f), //17 -c2
		new Color(31/255f,97/255f,141/255f), //18 -c4
		new Color(31/255f,97/255f,141/255f), //19 -c4
		new Color(84/255f,153/255f,199/255f), //20 -c3
		new Color(31/255f,97/255f,141/255f), //21 -c4 
		new Color(21/255f,67/255f,96/255f), //22 -c5
		new Color(31/255f,97/255f,141/255f), //23 -c4
		new Color(21/255f,67/255f,96/255f), //24 -c5
		new Color(84/255f,153/255f,199/255f), //25 -c3
		new Color(169/255f,204/255f,227/255f), //26 -c2
		new Color(84/255f,153/255f,199/255f), //27 -c3
		new Color(212/255f,230/255f,241/255f), //28 -c1
		new Color(169/255f,204/255f,227/255f), //29 -c2
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

