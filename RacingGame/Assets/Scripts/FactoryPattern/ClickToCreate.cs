using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToCreate : MonoBehaviour
{
    [SerializeField] private Factory[] factories;
    // Update is called once per frame
    void Update()
    {
        CreateEffectAtClick();
    }

    private void CreateEffectAtClick(){
        if(Input.GetMouseButtonDown(0)){
            factories[0].GetEffect(gameObject.transform.position);
        }
    }
}
