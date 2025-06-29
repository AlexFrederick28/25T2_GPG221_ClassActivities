using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int number;

    [SerializeField] private bool spawnOnStart = true;

    [SerializeField] private GameObject prefab;

    private void Start()
    {
        if (spawnOnStart)
        {
            Spawn();
        }
    }

    public void Spawn()
   {
        for (int i = 0; i < number; i++)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
   }
}
