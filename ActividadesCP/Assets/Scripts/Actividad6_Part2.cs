using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activdad6_Part2 : MonoBehaviour
{
	private Vector3[] vertices;
    private int[] triangles;
	private Color[] colores;
	[SerializeField] private float raiz, vel_mov; 
    [SerializeField] private Vector2 mouse, mousePress, rotacion, ang_ext, valor_act;
    private GameObject miCamara, nave;
    // Start is called before the first frame update
    void Start(){
		nave = new GameObject("nave");
        nave.AddComponent<MeshFilter>(); 
        nave.GetComponent<MeshFilter>().mesh = new Mesh();
        nave.AddComponent<MeshRenderer>();
		Create_Nave();
		CreateMaterial();
		UpdateMesh();
        CreateCamera();
		vel_mov = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;
		if (Input.GetKeyDown(KeyCode.Mouse0)){
            mousePress = mouse;
		}else if(Input.GetKey(KeyCode.Mouse0)){
			if(mousePress.x != 0.0f)
                rotacion = valor_act + 20.0f*(mousePress-mouse)/mousePress;
			else {
				rotacion = valor_act;
			}
			nave.transform.rotation = Quaternion.Euler(0.0f,-rotacion.x+ang_ext.x,-rotacion.y+ang_ext.y);
		} else if(Input.GetKeyUp(KeyCode.Mouse0)){
			valor_act=rotacion;
			nave.transform.rotation = Quaternion.Euler(0.0f,-valor_act.x+ang_ext.x,-valor_act.y+ang_ext.y);
		}
		if(Input.GetKey(KeyCode.W)){
            nave.transform.Translate(vel_mov * Time.deltaTime,0.0f,0.0f);
        }
        if(Input.GetKey(KeyCode.S)){
            nave.transform.Translate(-vel_mov * Time.deltaTime,0.0f,0.0f);
        }
        if(Input.GetKey(KeyCode.A)){	
            nave.transform.Translate(0.0f, 0.0f, vel_mov * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            nave.transform.Translate(0.0f,0.0f, -vel_mov * Time.deltaTime);
		}
		
    }
	
	private void Create_Nave(){
		vertices = new Vector3[]{
            new Vector3(0,0,0),
			new Vector3(-1,0,-0.5f),
			new Vector3(-1,0,0.5f)
		 };
		 
		triangles = new int[]{
            0,1,2
		};
		colores = new Color[]{
			new Color(84/255f,153/255f,199/255f), //0 
			new Color(21/255f,67/255f,96/255f), //1 
			new Color(21/255f,67/255f,96/255f) //2
		};
		//nave.transform.rotation = Quaternion.Euler(0,-90,0);
	}
	
	private void UpdateMesh() {
        nave.GetComponent<MeshFilter>().mesh.vertices = vertices;
        nave.GetComponent<MeshFilter>().mesh.triangles = triangles;
		nave.GetComponent<MeshFilter>().mesh.colors = colores;
    }
	
	private void CreateMaterial()
    {
        Material newMaterial = new Material(Shader.Find("ShaderBasico"));
        nave.GetComponent<MeshRenderer>().material = newMaterial;
    }
	
	private void CreateCamera() {
        miCamara = new GameObject("Camara");
        miCamara.AddComponent<Camera>();

        //----Posicion en el centro----
        miCamara.transform.position = new Vector3(-2,2,0);

        miCamara.transform.rotation = Quaternion.Euler(45,90,0);
        miCamara.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        miCamara.GetComponent<Camera>().backgroundColor = Color.white;
		miCamara.transform.SetParent(nave.transform);
    }
}
