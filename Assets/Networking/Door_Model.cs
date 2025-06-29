using System.Runtime.ConstrainedExecution;
using Unity.Netcode;
using UnityEngine;

public class Door_Model : NetworkBehaviour
{
    public Transform door;
    public NetworkVariable<bool> isOpen = new NetworkVariable<bool>();

    private void OnEnable()
    {
        isOpen.OnValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        isOpen.OnValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(bool previousValue, bool newValue)
    {
        if (newValue)
        {
            Open();
        }
        if (previousValue)
        {
            Close();
        }
    }

    public void Open()
    {
        isOpen.Value = true;
        door.gameObject.SetActive(true);    
    }

    public void Close()
    {
        isOpen.Value = false;
        door.gameObject.SetActive(false);
    }
}
