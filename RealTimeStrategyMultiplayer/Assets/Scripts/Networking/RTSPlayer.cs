using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSPlayer : NetworkBehaviour
{
    private List<UnitScript> myUnits = new List<UnitScript>();

    public override void OnStartServer()
    {
        UnitScript.ServerOnUnitSpawned += ServerHandleUnitSpawned;
        UnitScript.ServerOnUnitDespawned += ServerHandleUnitDespawned;
    }

    public override void OnStopServer()
    {
        base.OnStopServer();
    }

    private void ServerHandleUnitSpawned(UnitScript unitScript)
    {

    }

    private void ServerHandleUnitDespawned(UnitScript unitScript)
    {

    }

}
