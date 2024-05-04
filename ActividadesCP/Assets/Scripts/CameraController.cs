using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camaraOrbital, camara1raPersona;
    public bool camara1raPersonaEstado, camaraOrbitalEstado;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            activarCamara1eraPersona();
        if(Input.GetKeyDown(KeyCode.Alpha2))
            activarCamaraOrbital();
    }

    public void activarCamaraOrbital()
    {
        camaraOrbital.SetActive(true);
        camara1raPersona.SetActive(false);
    }

    public void activarCamara1eraPersona()
    {
        camara1raPersona.SetActive(true);
        camaraOrbital.SetActive(false);
    }
    
}
