using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitSelectionHandlerScript : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask = new LayerMask();

    private Camera mainCamera;
    private List<UnitScript> selectedUnits = new List<UnitScript>();


    private void Start()
    {
        mainCamera = Camera.main;

    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

        }

        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            ClearSelectionArea();
        }
    }

    private void ClearSelectionArea()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
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

        selectedUnits.Add(unitscript);

        foreach (UnitScript selectedUnit in selectedUnits)
        {
            selectedUnit.Select();
        }
    }

}
