using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currentSelection;
    public static CharacterControl Instance;

    private void Start()
    {
        Instance = this;
    }

    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        Instance.currentSelection.text = villager.ToString();
    }

    public static void SelectedVillagerName(TextMeshProUGUI villagerText)
    {
        if (SelectedVillager != null)
        {
            villagerText.text = SelectedVillager.GetType().ToString();
        }
    }

    /*private void Update()
    {
        if(SelectedVillager != null)
        {
            currentSelection.text = SelectedVillager.GetType().ToString();
        }
    }*/
}
