using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzDireccional : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] materiales;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Material m in materiales)
            m.SetVector("_LigthPosition_w", transform.position);
    }
}
