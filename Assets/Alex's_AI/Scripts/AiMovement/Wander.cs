using UnityEngine;

public class Wander : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float multiplier;
    private float perlinNoise;

    private void FixedUpdate()
    {
        //rb.AddTorque(0, Random.Range(-amount, amount), 0);

        //perlinNoise = Random.Range(Mathf.PerlinNoise1D(100) , Mathf.PerlinNoise1D(-100)) * amount;

        float positivePerlin = Mathf.PerlinNoise1D(Time.time) * multiplier;
        float negativePerlin = -Mathf.PerlinNoise1D(Time.time) * multiplier;
        perlinNoise = Random.Range(positivePerlin, negativePerlin);
        rb.AddTorque(0, perlinNoise,0);
    }
}
