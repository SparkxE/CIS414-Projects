using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDecorator : IWeapon
{
    private IWeapon decoratorWeapon;
    private WeaponAttachment attachment;

    public WeaponDecorator(IWeapon aWeapon, WeaponAttachment aAttachment)
    {
        this.decoratorWeapon = aWeapon;
        this.attachment = aAttachment;
    }


    public float Range
    {
        get { return decoratorWeapon.Range + attachment.Range; }
    }
    public float Rate
    {
        get { return decoratorWeapon.Rate + attachment.Rate; }
    }
    public float Strength
    {
        get { return decoratorWeapon.Strength + attachment.Strength; }
    }
    public float Cooldown
    {
        get { return decoratorWeapon.Cooldown + attachment.Cooldown; }
    }

}