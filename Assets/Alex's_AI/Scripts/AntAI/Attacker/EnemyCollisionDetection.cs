using UnityEngine;

/// <summary>
/// Not moduralised! Specifically used for the "AIBeybladeAttacker.cs" to detect if it has collided with a gameobject (Bad code)
/// </summary>
public class EnemyCollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<IEnergyUser>() != null)
        {
            if (GetComponentInParent<AIBeylbladeAttacker>().isAtDistance == true)
            {
                GetComponentInParent<AIBeylbladeAttacker>().hitEnemy = true;
                GetComponentInParent<IEnergyUser>().RemoveEnergy(GetComponentInParent<AIBeylbladeAttacker>().attackEnemyCost);

                //Debug.Log("HIT: " + collision.gameObject.name);

                Destroy(collision.gameObject);
            }
        }
    }
}
