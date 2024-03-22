using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    private GameObject miCamara;
    public Vector3 posicionCamara, rotacionCamara; 
    // Start is called before the first frame update
    void Start()
    {
        CreateCamera();
        posicionCamara = new Vector3(0,3,-7);
        rotacionCamara = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {   
        miCamara.transform.position = posicionCamara;
        miCamara.transform.rotation = Quaternion.Euler(rotacionCamara.x,rotacionCamara.y,rotacionCamara.z);
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
