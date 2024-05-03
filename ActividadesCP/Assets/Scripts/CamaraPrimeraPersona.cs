using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPrimeraPersona : MonoBehaviour
{
    private Vector3 p0, p1, p2, p3;
    private GameObject camaraPrimeraPersona;
    public float velocidadDeMovimiento;
    public float velocidadDeGiro;
    private Vector3 posMouseInicialMovimiento;
    private float pos;
    private bool activarCurvaBezier;

    public CameraController cameraController;
    // Start is called before the first frame update
    void Start()
    {
        activarCurvaBezier = false;
        pos = 0.0f;
        velocidadDeGiro = 10f;
        velocidadDeMovimiento = 2.25f;
        CreateCameraPrimeraPersona();
        CreateCurvaBezier();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(camaraPrimeraPersona.activeSelf == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                activarCurvaBezier = true;
            }
            if (activarCurvaBezier) { 
                pos +=  0.1f*Time.deltaTime;
            if (pos > 0 && pos <= 1.0f)
            {
                camaraPrimeraPersona.transform.position = puntoCurvaBezier(pos);
                camaraPrimeraPersona.transform.LookAt(primeraDerivadaCurvaBezier(pos));
            }
            }
            if(pos >= 1.0f || pos <= 0.0f)
            {   
                activarCurvaBezier = false;
                //enabled = false;
                if (Input.GetKey(KeyCode.W))
                {
                    MoverAdelante();
                }
                if (Input.GetKey(KeyCode.S))
                {
                    MoverAtras();
                }
                if (Input.GetKey(KeyCode.D))
                {   
                    MoverDerecha();
                }
                if (Input.GetKey(KeyCode.A))
                {
                    MoverIzquierda();
                }
                Rotacion();
            }
        }
    }

    private void Rotacion() {
        if (Input.GetMouseButtonDown(0))//obtengo posicion inicial del mouse
        {
            posMouseInicialMovimiento = Input.mousePosition;
        } else
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 movimientoMouse = Input.mousePosition - posMouseInicialMovimiento;

                camaraPrimeraPersona.transform.Rotate(-movimientoMouse.y, 0, 0, Space.Self);
                camaraPrimeraPersona.transform.Rotate(0, movimientoMouse.x, 0, Space.World);//Ya que tengo siempre el Y apuntado para arriba para girar bien lo roto respecto al mundo en Y porq sino se rompe todo

                posMouseInicialMovimiento = Input.mousePosition;
            }
        }
    }

    private void MoverAdelante()
    {
        camaraPrimeraPersona.transform.Translate(Vector3.forward * velocidadDeMovimiento * Time.deltaTime); ;
    }
    private void MoverAtras()
    {
        camaraPrimeraPersona.transform.Translate(Vector3.back * velocidadDeMovimiento * Time.deltaTime);
    }
    private void MoverDerecha()
    {
        camaraPrimeraPersona.transform.Translate(Vector3.right * velocidadDeMovimiento * Time.deltaTime);
    }
    private void MoverIzquierda()
    {
        camaraPrimeraPersona.transform.Translate(Vector3.left * velocidadDeMovimiento * Time.deltaTime);
    }

    private void CreateCameraPrimeraPersona() {//Crea la camara en primera persona
        camaraPrimeraPersona = new GameObject("Camara1eraPersona");
        cameraController.camara1raPersona = camaraPrimeraPersona;
        camaraPrimeraPersona.AddComponent<Camera>();
        camaraPrimeraPersona.transform.position = new Vector3(-6, 1.8f, 2);
        camaraPrimeraPersona.transform.rotation = Quaternion.Euler(0, 90, 0);
        camaraPrimeraPersona.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        camaraPrimeraPersona.GetComponent<Camera>().backgroundColor = Color.black;
    }

    Vector3 puntoCurvaBezier(float tiempo)
    {
        return Mathf.Pow((1 - tiempo), 3) * p0 + 3 * Mathf.Pow((1 - tiempo), 2) * tiempo * p1 + 3 * (1 - tiempo) * Mathf.Pow(tiempo, 2) * p2 + Mathf.Pow(tiempo, 3) * p3;
    }

    Vector3 primeraDerivadaCurvaBezier(float tiempo){
         return -3 * Mathf.Pow((1 - tiempo), 2) * p0 - 6 * (1 - 4 * tiempo + Mathf.Pow(tiempo, 2)) * p1 + 3 * tiempo * (2 - 3 * tiempo) * p2 + 3 * Mathf.Pow(tiempo, 2) * p3; 
    }

    void CreateCurvaBezier(){
        p0 = new Vector3(-3.75f, 0.63f, -0.26f);
        p1 = new Vector3(0.0f, -1.04f, 1.12f);
        p2 = new Vector3(1.0f, 3.74f, -0.18f);
        p3 = new Vector3(3.94f, 2.41f, 1.0f);
    }
}
