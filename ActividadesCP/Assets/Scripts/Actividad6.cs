using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad6 : MonoBehaviour { 
	private Vector3[] vertices;
    private int[] triangles;
	[SerializeField] private float valor_act, raiz, ang_ext;
    [SerializeField] private float mouse, mousePress, rotacion, mouseMov;
    private GameObject miCamara;//, cam_trian;
    //[SerializeField] private Vector3 posicionCamara, rotacionCamara; 
    
	void Start(){ 
		//cam_trian = new GameObject("Cam_triang");
        //cam_trian.AddComponent<MeshFilter>(); 
        //cam_trian.GetComponent<MeshFilter>().mesh = new Mesh();
        //cam_trian.AddComponent<MeshRenderer>();
		//CreateCam_Triang();
		raiz = 7.0f;
        CreateCamera();
		//UpdateMesh();
		valor_act = 1.0f;
    }

    // Update is called once per frame
    void Update() {
		mouse = Input.mousePosition.x;
		if (Input.GetKeyDown(KeyCode.Mouse0)){
            mousePress = mouse;
		}
		if(Input.GetKey(KeyCode.Mouse0)){
			if(mousePress != 0.0f)
                rotacion = valor_act + 20.0f*(mousePress-mouse)/mousePress;
			else {
				rotacion = valor_act;
			}
			miCamara.transform.rotation = Quaternion.Euler(0.0f,-rotacion+ang_ext,0.0f);
			miCamara.transform.position = new Vector3(raiz*Mathf.Cos(2.0f*Mathf.PI*rotacion/360.0f),0.0f,raiz*Mathf.Sin(2.0f*Mathf.PI*rotacion/360.0f));
		}
		if(Input.GetKeyUp(KeyCode.Mouse0)){
			valor_act=rotacion;
			miCamara.transform.rotation = Quaternion.Euler(0.0f,-valor_act+ang_ext,0.0f);
			miCamara.transform.position = new Vector3(raiz*Mathf.Cos(2.0f*Mathf.PI*valor_act/360.0f),0.0f,raiz*Mathf.Sin(2.0f*Mathf.PI*valor_act/360.0f));
		}
		
    }
	
	/*private void CreateCam_Triang(){
		cam_trian.transform.position = new Vector3(7,0,0);
		vertices = new Vector3[]{
            new Vector3(0,0,0),
			new Vector3(1,0,0.5f),
			new Vector3(1,0,-0.5f)
		 };
		 
		triangles = new int[]{
            0,1,2
		};
	}
	
	private void UpdateMesh() {
        cam_trian.GetComponent<MeshFilter>().mesh.vertices = vertices;
        cam_trian.GetComponent<MeshFilter>().mesh.triangles = triangles;
    }*/
	
    private void CreateCamera() {
        miCamara = new GameObject("Camara");
        miCamara.AddComponent<Camera>();

        //----Posicion en el centro----
        miCamara.transform.position = new Vector3(raiz,0,0);

        miCamara.transform.rotation = Quaternion.Euler(0,-90,0);
        miCamara.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        miCamara.GetComponent<Camera>().backgroundColor = Color.white;
    }

}
