using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewWeaponAttachment", menuName = "Weapon/Attachment", order = 1)]
public class WeaponAttachment : ScriptableObject, IWeapon
{
    public string attachmentName;
    public string attachmentDescription;


    [Range(0, 100)]
    [Tooltip("Increase rate of firing per 10 seconds")]
    [SerializeField] private float range;

    [Range(0, 100)]
    [Tooltip("Increase weapon range")]
    [SerializeField] private float rate;

    [Range(0, 100)]
    [Tooltip("Increase weapon strength")]
    [SerializeField] private float strength;

    [Range(-5, 5)]
    [Tooltip("Reduce or increase cooldown duration")]
    [SerializeField] private float cooldown;

    public float Range
    {
        get { return range; }
    }
    public float Rate
    {
        get { return rate; }
    }
    public float Strength
    {
        get { return strength; }
    }
    public float Cooldown
    {
        get { return cooldown; }
    }
}
