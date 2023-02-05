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
        Debug.LogWarning("current Init" + current_state);
        TurnOffAll();

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
    private void TurnOffAll()
    {
        weed.SetActive(false);
        sprout.SetActive(false);
        hiddenSprout.SetActive(false);
        deadPlant.SetActive(false);
    }
    public void UpdateModel()
    {
        switch (current_state)
        {
            case Slot.HiddenSeed:
                break;
            case Slot.HiddenWeed:
                break;
            case Slot.Plant:
                break;
            case Slot.Weed:
                break;
            case Slot.Dead:
                break;
        }
    }
}
