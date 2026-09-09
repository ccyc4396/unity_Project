using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    

    [Header("Flash FX")]
    [SerializeField] private SpriteRenderer myRenderer;
    [SerializeField] private Material hitMat;
    [SerializeField] private Material originalMat;
    void Start()
    {
        myRenderer = GetComponentInChildren<SpriteRenderer>();
        originalMat = myRenderer.sharedMaterial;

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Flash()
    {
        StartCoroutine(FXflash(0.2f));
    }

    IEnumerator FXflash(float time)
    {
        myRenderer.sharedMaterial = hitMat;
        yield return new WaitForSeconds(time);
        myRenderer.sharedMaterial = originalMat;

    }

}
