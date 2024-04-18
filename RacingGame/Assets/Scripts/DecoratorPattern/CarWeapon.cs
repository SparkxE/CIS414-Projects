using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWeapon : MonoBehaviour
{
    public WeaponConfig weaponConfig;
    // here is where you would add in multiple attachments, in this case we have only 2
    public WeaponAttachment mainAttachment;
   

    private IWeapon weapon;
    private bool isDecorated;


    void Start()
    {
        this.weapon = new Weapon(weaponConfig);
    }

    void OnGUI()
    {
        GUI.color = Color.red;
        if (isDecorated == true)
        {
            GUI.Label(new Rect(750, 70, 200, 100), "Weapon Equipped! Ready to Fire!");
        }
    }


    public void Reset()
    {
        weapon = new Weapon(weaponConfig);
        Debug.Log("weapon is detached ");
    }

    public void Decorate()
    {

        if (mainAttachment )
        {
            weapon = new WeaponDecorator(weapon, mainAttachment);
        }
       
        isDecorated = !isDecorated;
    }
}
