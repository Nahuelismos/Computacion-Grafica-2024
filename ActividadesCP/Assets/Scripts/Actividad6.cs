using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad6 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private  float mouse, mousePress, mouseMov;
    [SerializeField] private float rotacion;
    [SerializeField] private GameObject miCamara;
    [SerializeField] private Vector3 posicionCamara, rotacionCamara; 
    void Start(){
        posicionCamara = new Vector3(0,0,-7);
        rotacionCamara = new Vector3(0,0,0);
        CreateCamera();
    }

    // Update is called once per frame
    /*void Update()
    {
        mouse = Input.mousePosition; //solo para ver
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            mousePress = mouse;
        }
        if(Input.GetKey(KeyCode.Mouse0)){
            mouseMov = mousePress - mouse;
            //miCamara.transform.Rotate(0.0f, mouseMov.x/100, 0.0f,Space.World);

        }
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            mouseMov = new Vector3(0, 0, 0);
        }
        miCamara.transform.LookAt(Vector3.zero);
        rotacionCamara = new Vector3 (miCamara.transform.rotation.x, miCamara.transform.rotation.y, miCamara.transform.rotation.z);
    }*/

    private void Update() {
        mouse = Input.mousePosition.x;
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            mousePress = Input.mousePosition.x;
        }
        if (Input.GetKey(KeyCode.Mouse0)) {
            mouseMov = Mathf.Clamp((mousePress - mouse), -100f,100f);
       
        }
        miCamara.transform.rotation = Quaternion.Euler(0, mouseMov, 0);

    }
    private void CreateCamera()
    {
        miCamara = new GameObject("Camara");
        miCamara.AddComponent<Camera>();

        //----Posicion en el centro----
        miCamara.transform.position = posicionCamara;

        miCamara.transform.rotation = Quaternion.Euler(rotacionCamara.x,rotacionCamara.y,rotacionCamara.z);
        miCamara.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        miCamara.GetComponent<Camera>().backgroundColor = Color.white;
    }

}
