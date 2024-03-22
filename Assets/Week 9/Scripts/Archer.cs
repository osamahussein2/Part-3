using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Archer : Villager
{
    public TextMeshProUGUI archerText;

    public Slider slider;

    public GameObject arrowPrefab;
    public Transform spawnPoint;

    protected override void Update()
    {
        base.Update();
        CharacterControl.ScaleSelectedVillager(slider.value);
    }

    public override void Selected(bool value)
    {
        base.Selected(value);

        if (!value)
        {
            archerText.text = "";
        }
    }

    private void OnMouseDown()
    {
        CharacterControl.SetSelectedVillager(this);
        clickingOnSelf = true;

        CharacterControl.SelectedVillagerName(archerText);
    }

    protected override void Attack()
    {
        destination = transform.position;
        base.Attack();
        Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public override ChestType CanOpen()
    {
        return ChestType.Archer;
    }
}
