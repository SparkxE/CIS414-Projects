using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientDecorator : MonoBehaviour
{
    private CarWeapon carWeapon;
    private bool isWeaponDecorated= false;

    void Start()
    {
        carWeapon = (CarWeapon)FindObjectOfType(typeof(CarWeapon));
    }
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(250, 0, 200, 20));
        if (isWeaponDecorated == false)
        {
            if (GUILayout.Button("Decorated Weapon"))
            {
                carWeapon.Decorate();
                isWeaponDecorated = !isWeaponDecorated;
            }
        }

        if (isWeaponDecorated == true)
        {
            if (GUILayout.Button("Reset Weapon"))
            {
                carWeapon.Reset();
                isWeaponDecorated = !isWeaponDecorated;
            }
        }

      
        GUILayout.EndArea();
    }
}
