using UnityEngine;

/// <summary>
/// Gives a set of instructions for energy users
/// </summary>
public interface IEnergyUser 
{
    public void AddEnergy(int amount);
    public void RemoveEnergy(int amount);
}
