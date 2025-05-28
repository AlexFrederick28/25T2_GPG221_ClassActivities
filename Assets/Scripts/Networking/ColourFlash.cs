using Unity.Netcode;
using UnityEngine;

public class ColourFlash : NetworkBehaviour
{
    public Material colour;
    public int probability = 200;

    void FixedUpdate()
    {
        if (IsServer) // This is a handy variable you can use to prevent code from running on the client
        {
            if (Random.Range(0, probability) == 0)
            {
                ChangeColour_Rpc();
            }
        }
    }


    // This is the �attribute� that tells Unity you want to network this function
    [Rpc(SendTo.ClientsAndHost, RequireOwnership = false)]
    private void ChangeColour_Rpc() // You MUST name it with �ClientRpc� at the end. I think just to make sure you know what you�re doing
    {
        colour.color = Random.ColorHSV();
    }
}
