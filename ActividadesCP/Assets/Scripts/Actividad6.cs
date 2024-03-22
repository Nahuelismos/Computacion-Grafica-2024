using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad6 : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 mouse, mousePress;
    public float rotacion;
    private GameObject miCamara;
    public Vector3 posicionCamara, rotacionCamara; 
    void Start(){
        CreateCamera();
        posicionCamara = new Vector3(0,0,-7);
        rotacionCamara = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            mousePress = mouse;
        }
        if(Input.GetKey(KeyCode.Mouse0)){
            if(mousePress.x != 0.0f)
                rotacion = ((mousePress.x-mouse.x)/mousePress.x);
            miCamara.transform.Rotate(0.0f,rotacion,0.0f,Space.World); 
        }
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            miCamara.transform.Rotate(0.0f,rotacion,0.0f,Space.World); 
            //miCamara.transform.rotation = Quaternion.Euler(rotacionCamara.x,rotacionCamara.y+rotacion,rotacionCamara.z);
        }
        miCamara.transform.position = posicionCamara;
        //miCamara.transform.Rotate(0.0f,rotacion,0.0f,Space.World); 
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
