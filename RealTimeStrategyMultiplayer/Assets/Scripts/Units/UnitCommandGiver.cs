using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitCommandGiver : MonoBehaviour
{
    [SerializeField] private UnitSelectionHandlerScript unitSelectionHandlerScript = null;
    [SerializeField] private LayerMask layerMask = new LayerMask();
    private Camera mainCamera;

    // Start is called before the first frame update
    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Mouse.current.rightButton.wasPressedThisFrame)
        {
            return;
        }

        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if(!Physics.Raycast(ray, out RaycastHit hit, Mathf .Infinity, layerMask))
        {
            return;
        }

        TryMove(hit.point);

    }

    private void TryMove(Vector3 point)
    {
        foreach(UnitScript unitScript in unitSelectionHandlerScript.SelectedUnits)
        {
            unitScript.GetUnitMovment().CmdMove(point);
        }
    }
}
