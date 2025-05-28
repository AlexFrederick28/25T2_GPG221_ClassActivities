using Unity.Netcode;
using UnityEngine;

public class SphereChangling : NetworkBehaviour
{
    bool big = true;

    private void FixedUpdate()
    {
        if (IsServer)
        {
            if (Random.value > 0.95f)
            {
                ChangeSize_Rpc(!big);
            }
        }
    }

    // Remote procedure call
    [Rpc(SendTo.ClientsAndHost)]
    public void ChangeSize_Rpc(bool _big)
    {
        Debug.Log("IsHost = " + IsHost);
        Debug.Log("IsClient = " + IsClient);
        Debug.Log("IsLocalPlayer = " + IsLocalPlayer);
        Debug.Log("IsOwner = " + IsOwner);
        Debug.Log("IsServer = " + IsServer);

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

}
