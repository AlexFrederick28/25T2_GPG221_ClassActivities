using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class SphereChangling : NetworkBehaviour
{
    bool big = true;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        gameObject.name = "SphereChangling : " + OwnerClientId; // handy to see different players in console heirarchy
    }

    private void FixedUpdate()
    {
        if (IsServer)
        {
            if (Random.value > 0.95f)
            {
                ChangeSize_Rpc(!big);
            }
        }
        if (IsLocalPlayer)
        {
            if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
            {
                Debug.Log("Space key was pressed");
                RequestToChangeSize_RPC(big);
            }
        }
    }

    // Remote procedure call
    [Rpc(SendTo.ClientsAndHost, Delivery = RpcDelivery.Unreliable)]
    public void ChangeSize_Rpc(bool _big)
    {
        //Debug.Log("IsHost = " + IsHost);
        //Debug.Log("IsClient = " + IsClient);
        //Debug.Log("IsLocalPlayer = " + IsLocalPlayer);
        //Debug.Log("IsOwner = " + IsOwner);
        //Debug.Log("IsServer = " + IsServer);

        this.big = _big;

        if (_big)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    [Rpc(SendTo.Server, Delivery = RpcDelivery.Reliable)] // allows clients to send to server
    public void RequestToChangeSize_RPC(bool _big)
    {
        ChangeSize_Rpc(_big);
    }



}
