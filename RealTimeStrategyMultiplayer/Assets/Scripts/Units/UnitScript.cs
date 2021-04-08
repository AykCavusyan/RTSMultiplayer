using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Events;
using System;


public class UnitScript : NetworkBehaviour
{
    [SerializeField] private UnitMovmentScript unitMovmentScript = null;
    [SerializeField] private UnityEvent onSelected = null;
    [SerializeField] private UnityEvent onDeselected = null;

    public static event Action<UnitScript> ServerOnUnitSpawned;
    public static event Action<UnitScript> ServerOnUnitDespawned;

    public UnitMovmentScript GetUnitMovment()
    {
        return unitMovmentScript;
    }

    #region Server

    public override void OnStartServer()
    {
        ServerOnUnitSpawned?.Invoke(this);
    }

    public override void OnStopServer()
    {
        ServerOnUnitDespawned?.Invoke(this);

    }

    #endregion




    #region Client

    [Client]
    public void Select()
    {
        if (!hasAuthority)
        {
            return;
        }

        onSelected?.Invoke();
    }


    [Client]
    public void Deselect()
    {
        if (!hasAuthority)
        {
            return;
        }

        onDeselected?.Invoke();
    }

    #endregion

}
