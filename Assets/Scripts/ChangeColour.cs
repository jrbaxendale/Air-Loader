using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;
using UnityEngine.UI;
public class ChangeColour : MonoBehaviour
{
    public GameObject cube;
    private float intensity = 5.0f;
    private float r = 0.2f;
    private float g = 0.1f;
    private float b = 0.1f;
    private float a = 0.9f;




    void Start()


    {
        

        var objRenderer = cube.GetComponent<Renderer>();
        objRenderer.material.SetColor("_Color", Color.red);
        objRenderer.material.SetColor("_EmissionColor", new Vector4(r, g, b, a) * intensity);

       

    }
}






