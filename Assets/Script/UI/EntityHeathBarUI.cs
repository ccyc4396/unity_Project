using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHeathBarUI : MonoBehaviour
{
    public CharacterStates myStates;
    public RectTransform myTransform;
    public Slider healthBarSlider;

    public void Awake()
    {
        myTransform = GetComponent<RectTransform>();
        myStates = GetComponentInParent<CharacterStates>();
        healthBarSlider = GetComponentInChildren<Slider>();  
    }
    public void Start()
    {
        InitializedHealthBar();
    }

    public  void Flip()
    {
        myTransform.Rotate(0, 180, 0);
    }

    private void InitializedHealthBar()
    {
        healthBarSlider.value =  (float)myStates.currentHeath/myStates.maxHeath ;
    }
    public void BarChange(CharacterStates states)
    {

        healthBarSlider.value = (float)states.currentHeath / states.maxHeath;
        
    }
}
