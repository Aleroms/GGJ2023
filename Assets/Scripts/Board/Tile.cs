using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum Slot { HiddenSeed, Plant, HiddenWeed, Weed, Dead}
    public Slot current_state;

    [Header("Art Assets")]
    [SerializeField] private GameObject weed;
    [SerializeField] private GameObject sprout;
    [SerializeField] private GameObject hiddenSprout;
    [SerializeField] private GameObject deadPlant;


    public void InitModel()
    {
        TurnOffAll();
        ActivateModel();
    }
    private void TurnOffAll()
    {
        weed.SetActive(false);
        sprout.SetActive(false);
        hiddenSprout.SetActive(false);
        deadPlant.SetActive(false);
    }
    public void UpdateModel(Slot state)
    {
        current_state = state;
        TurnOffAll();
        ActivateModel();
        
    }
    private void ActivateModel()
    {
        switch (current_state)
        {
            case Slot.HiddenSeed:
                hiddenSprout.SetActive(true);
                break;
            case Slot.HiddenWeed:
                hiddenSprout.SetActive(true);
                break;
            case Slot.Plant:
                sprout.SetActive(true);
                break;
            case Slot.Weed:
                weed.SetActive(true);
                break;
            case Slot.Dead:
                deadPlant.SetActive(true);
                break;
        }
    }
}
