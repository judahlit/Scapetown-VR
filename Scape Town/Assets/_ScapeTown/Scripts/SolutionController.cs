using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionController : MonoBehaviour
{
    [SerializeField] private List<ColorSwitch> _selectedDoors;
    [SerializeField] private List<ColorSwitch> _unselectedDoors;

    [SerializeField] private List<MoveDown> _dissapearingObjects;

    private void OnEnable() {
        foreach(ColorSwitch curr in _selectedDoors)
        {
            curr.ColorSwaped += SwapColorEventHandler;
        }

        foreach(ColorSwitch curr in _unselectedDoors)
        {
            curr.ColorSwaped += SwapColorEventHandler;
        }
    }
    private void OnDisable() {
        foreach(ColorSwitch curr in _selectedDoors)
        {
            curr.ColorSwaped -= SwapColorEventHandler;
        }

        foreach(ColorSwitch curr in _unselectedDoors)
        {
            curr.ColorSwaped -= SwapColorEventHandler;
        }
    }
    
    private void SwapColorEventHandler()
    {
        if (CheckSolution())
        {
            SuccessHandler();
        }
    }

    private void SuccessHandler()
    {
        
        foreach(MoveDown curr in _dissapearingObjects)
        {
            curr.enabled = true;
        }

        foreach(ColorSwitch curr in _selectedDoors)
        {
            curr.gameObject.SetActive(false);
        }

        foreach(ColorSwitch curr in _unselectedDoors)
        {
            curr.gameObject.SetActive(false);
        }
    }

    private bool CheckSolution()
    {
        foreach(ColorSwitch curr in _selectedDoors)
        {
            if (curr._selected == false) return false;
        }

        foreach(ColorSwitch curr in _unselectedDoors)
        {
            if (curr._selected == true) return false;
        }

        return true;
    }
}
