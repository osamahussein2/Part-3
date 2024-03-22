using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Merchant : Villager
{
    public TextMeshProUGUI merchantText;

    public Slider slider;

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
            merchantText.text = "";
        }
    }

    private void OnMouseDown()
    {
        CharacterControl.SetSelectedVillager(this);
        clickingOnSelf = true;

        CharacterControl.SelectedVillagerName(merchantText);
    }

    public override ChestType CanOpen()
    {
        return ChestType.Merchant;
    }
}
