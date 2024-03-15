using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject dagger;
    public Transform dagger1;
    public Transform dagger2;

    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    protected override void Attack()
    {
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        speed = 10;
        base.Attack();
        Instantiate(dagger, dagger1.position, dagger1.rotation);
        Instantiate(dagger, dagger2.position, dagger2.rotation);
    }
}
