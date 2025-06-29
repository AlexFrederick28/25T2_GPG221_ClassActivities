using Unity.Netcode;
using UnityEngine;

public class Flasher : NetworkBehaviour // This inheritance gives you extra network variables etc
{
    public Light light;
    public int probability = 200;

    void FixedUpdate()
    {
        if (IsServer) // This is a handy variable you can use to prevent code from running on the client
        {
            if (Random.Range(0, probability) == 0)
            {
                // The !light.enabled bit is just how I’m toggling the bool back and forth. It means NOT
                ChangeLightStateClientRpc(!light.enabled); // Note I send through variables over the network. You can send multiple ones with commas, BUT you CAN’T send references to other objects as you normally would. There are other ways to do that though
            }
        }
    }


    // This is the ‘attribute’ that tells Unity you want to network this function
    [Rpc(SendTo.ClientsAndHost, RequireOwnership = false)]
    private void ChangeLightStateClientRpc(bool state) // You MUST name it with “ClientRpc” at the end. I think just to make sure you know what you’re doing
    {
        light.enabled = state;
    }
}

