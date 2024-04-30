using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWeapon : MonoBehaviour
{
    public WeaponConfig weaponConfig;
    // here is where you would add in multiple attachments, in this case we have only 2
    public WeaponAttachment mainAttachment;
    public string equipMessage = "";
    private GameObject weaponPrefab;
    [SerializeField] private GameObject bulletSpawnPoint;
   

    private IWeapon weapon;
    private bool isDecorated;


    void Start()
    {
        this.weapon = new Weapon(weaponConfig);
    }

    void OnGUI()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(750, 70, 200, 100), equipMessage);
        if (isDecorated == true)
        {
            equipMessage = "Weapon Equipped! Ready to Fire!";
        }
        else{
            equipMessage = "";
        }
    }


    public void Reset()
    {
        weapon = new Weapon(weaponConfig);
        Instantiate(weaponPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        Debug.Log("weapon is detached ");
        isDecorated = false;
    }

    public void Decorate()
    {

        if (mainAttachment)
        {
            weapon = new WeaponDecorator(weapon, mainAttachment);
            isDecorated = true;
            weaponPrefab = mainAttachment.prefab;
        }
    }
}
