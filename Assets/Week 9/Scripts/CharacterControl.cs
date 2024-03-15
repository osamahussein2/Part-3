using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public TextMeshProUGUI selectText;
    public static Villager SelectedVillager { get; private set; }

    void Update()
    {
        selectText.text = "Nothing";

        if (SelectedVillager.gameObject.name == "Merchant")
        {
            selectText.text = "Merchant";
        }

        if (SelectedVillager.gameObject.name == "Archer")
        {
            selectText.text = "Archer";
        }

        if (SelectedVillager.gameObject.name == "Thief")
        {
            selectText.text = "Thief";
        }
    }

    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
    }
}
