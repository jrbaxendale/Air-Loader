using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussianBlur_HDRP_Controller : MonoBehaviour
{
    public Material GaussianBlurMat;

    [Range(0f, 1f)]
    public float blurAmount = 0.5f;

    [Range(0f, 1f)]
    public float metallic = 0.5f;

    // Update is called once per frame
    void Update()
    {
        GaussianBlurMat.SetFloat("_Smoothness",blurAmount);
        GaussianBlurMat.SetFloat("_Metallic", metallic);
    }
}
