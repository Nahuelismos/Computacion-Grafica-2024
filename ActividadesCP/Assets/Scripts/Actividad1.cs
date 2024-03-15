using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad1 : MonoBehaviour
{
    private Vector3[] vertices;
    private int[] triangles;
    private GameObject objetoCuadrado, miCamara;
    public GameObject boton_activar;
    public bool esta_activado;
    public float girar;

    void Start()
    {
        objetoCuadrado = new GameObject("Cuadrado");
        objetoCuadrado.AddComponent<MeshFilter>();
        objetoCuadrado.GetComponent<MeshFilter>().mesh = new Mesh();
        objetoCuadrado.AddComponent<MeshRenderer>();
        CreateModel();
        UpdateMesh();
        CreateMaterial();
        CreateCamera();

        boton_activar = new GameObject("Activar giro");
        boton_activar.SetActive(false);
        girar = 0;
    }

    void Update()
    {
        girar = girar + 0.5f;
        if (esta_activado)
        {
            boton_activar.SetActive(true);
            miCamara.transform.rotation = Quaternion.Euler(90, girar, 0);
            objetoCuadrado.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            boton_activar.SetActive(false);
            miCamara.transform.rotation = Quaternion.Euler(90, 0, 0);
            objetoCuadrado.transform.rotation = Quaternion.Euler(0, -girar, 0);
        }
        Debug.Log("girar: " + girar);
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
    }

    private void UpdateMesh()
    {
        objetoCuadrado.GetComponent<MeshFilter>().mesh.vertices = vertices;
        objetoCuadrado.GetComponent<MeshFilter>().mesh.triangles = triangles;
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
}
