using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitSelectionHandlerScript : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask = new LayerMask();

    private Camera mainCamera;
    public List<UnitScript> SelectedUnits = new List<UnitScript>();


    private void Start()
    {
        mainCamera = Camera.main;

    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            foreach (UnitScript selectedUnit in SelectedUnits)
            {
                selectedUnit.Deselect();
            }

            SelectedUnits.Clear();
        }

        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            ClearSelectionArea();
        }
    }

    private void ClearSelectionArea()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        
        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            return;
        }

        if(!hit.collider.TryGetComponent<UnitScript>(out UnitScript unitscript)) 
        {
            return; 
        }

        if(!unitscript.hasAuthority)
        {
            return;
        }

        SelectedUnits.Add(unitscript);

        foreach (UnitScript selectedUnit in SelectedUnits)
        {
            selectedUnit.Select();
        }
    }

}
