using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad5 : MonoBehaviour
{
    private Vector3[] vertices;
    private int[] triangles;
    private GameObject[] objetoF;
    private GameObject miCamara;
    private int cant = 12;

    void Start()
    {
		CreateModel(); 
        objetoF = new GameObject[cant];
		for(int i = 0;i<cant; i++){
            string n = "LetraF"+i;
        	objetoF[i] = new GameObject(n);
        	objetoF[i].AddComponent<MeshFilter>();
        	objetoF[i].GetComponent<MeshFilter>().mesh = new Mesh();
        	objetoF[i].AddComponent<MeshRenderer>();	
        	UpdateMesh(i);
	    }
        //objeto1
        objetoF[1].transform.position = new Vector3(1,0,1);
        objetoF[1].transform.rotation = Quaternion.Euler(0,180,0);
        
        //objeto2
        objetoF[2].transform.position = new Vector3(1,0,1);
        objetoF[2].transform.rotation = Quaternion.Euler(0,-90,0);

        //objeto3
        objetoF[3].transform.position = new Vector3(0,0,2);
        objetoF[3].transform.rotation = Quaternion.Euler(0,90,0);

        //objeto4
        objetoF[4].transform.position = new Vector3(0,0,2);

        //objeto5
        objetoF[5].transform.position = new Vector3(1,0,3);
        objetoF[5].transform.rotation = Quaternion.Euler(0,180,0);
        
        //objeto6
        objetoF[6].transform.position = new Vector3(1,0,3);
        objetoF[6].transform.rotation = Quaternion.Euler(0,-90,0);

        //objeto7
        objetoF[7].transform.position = new Vector3(0,0,4);
        objetoF[7].transform.rotation = Quaternion.Euler(0,90,0);

        //objeto8
        objetoF[8].transform.position = new Vector3(1,0,1);

        //objeto9
        objetoF[9].transform.position = new Vector3(2,0,2);
        objetoF[9].transform.rotation = Quaternion.Euler(0,180,0);

        //objeto10
        objetoF[10].transform.position = new Vector3(1,0,3);

        //objeto11
        objetoF[11].transform.position = new Vector3(2,0,4);
        objetoF[11].transform.rotation = Quaternion.Euler(0,180,0);

        CreateMaterial();
        CreateCamera();
    }

    void Update()
    {
      
    }

    private void CreateModel() {
        vertices = new Vector3[]{
            new Vector3(0,0,0),     //0
            new Vector3(0,0,1),     //1
	    	new Vector3(1,0,0)	    //2
        };
        triangles = new int[]{
            0,1,2 //t1
        };
    }

    private void UpdateMesh(int i) {
        objetoF[i].GetComponent<MeshFilter>().mesh.vertices = vertices;
        objetoF[i].GetComponent<MeshFilter>().mesh.triangles = triangles;
    }

    private void CreateCamera(){
        miCamara = new GameObject("Camara");
        miCamara.AddComponent<Camera>();

        //----Posicion en el centro----
        miCamara.transform.position = new Vector3(1, 4, 2);

        miCamara.transform.rotation = Quaternion.Euler(90, 0, 0);
        miCamara.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        miCamara.GetComponent<Camera>().backgroundColor = Color.white;
    }

    private void CreateMaterial() {
        Material newMaterial = new Material(Shader.Find("Standard"));
		for(int i = 0;i<cant;i++){
        	objetoF[i].GetComponent<MeshRenderer>().material = newMaterial;
		}
    }
}
