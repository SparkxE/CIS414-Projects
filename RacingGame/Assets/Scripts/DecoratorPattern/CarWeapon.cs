using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWeapon : MonoBehaviour
{
    public WeaponConfig weaponConfig;
    // here is where you would add in multiple attachments, in this case we have only 2
    public WeaponAttachment mainAttachment;
   

    private bool isFiring;
    private IWeapon weapon;
    private bool isDecorated;


    void Start()
    {
        this.weapon = new Weapon(weaponConfig);
    }

    void OnGUI()
    {
       


        GUI.color = Color.red;
        GUI.Label(new Rect(900, 50, 200, 100), "Firing Rate: " + weapon.Rate);
        GUI.Label(new Rect(900, 70, 200, 100), "Range: " + weapon.Range);
        GUI.Label(new Rect(900, 90, 200, 100), "Strength: " + weapon.Strength);
        GUI.Label(new Rect(900, 110, 200, 100), "Cooldown: " + weapon.Cooldown);
        GUI.Label(new Rect(900, 130, 200, 100), "Weapon Firing: " + isFiring);
        if (mainAttachment && isDecorated)
        {
            GUI.Label(new Rect(900, 170, 200, 100), "Main Attachment: " + mainAttachment.attachmentName);
        }
     

      
    }


    public void Reset()
    {
        weapon = new Weapon(weaponConfig);
        isFiring = false;
        Debug.Log("weapon is detached ");
    }

    public void Decorate()
    {
        isFiring = false;

        if (mainAttachment )
        {
            weapon = new WeaponDecorator(weapon, mainAttachment);
        }
       
        isDecorated = !isDecorated;
        Debug.Log("Firing is on");
    }

    void Update()
    {

    }
}
