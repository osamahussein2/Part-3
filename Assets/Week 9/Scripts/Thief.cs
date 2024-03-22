using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Thief : Villager
{
    public TextMeshProUGUI thiefText;

    public GameObject knifePrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    Coroutine dashing;
    float dashSpeed = 7;

    public static Villager SelectedVillager { get; private set; }

    public override void Selected(bool value)
    {
        base.Selected(value);

        if (!value)
        {
            thiefText.text = "";
        }
    }

    private void OnMouseDown()
    {
        CharacterControl.SetSelectedVillager(this);
        clickingOnSelf = true;

        CharacterControl.SelectedVillagerName(thiefText);
    }

    protected override void Attack()
    {
        if(dashing != null)
        {
            StopCoroutine(dashing);
        }

        dashing = StartCoroutine(Dash());
        //StartCoroutine("Dash"); Extra line of code I could potentially use
    }

    IEnumerator NotDash()
    {
        yield return null;
    }

    IEnumerator Dash()
    {
        //dash towards mouse
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        speed = dashSpeed;

        while(speed > 3)
        {
            yield return null;
        }

        base.Attack();
        yield return new WaitForSeconds(0.1f);
        Instantiate(knifePrefab, spawnPoint1.position, spawnPoint1.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(knifePrefab, spawnPoint2.position, spawnPoint2.rotation);
    }

    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    public override string ToString()
    {
        return "Hi, I'm Osama!";
    }
}
