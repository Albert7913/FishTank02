using UnityEngine;
public class TestFish : MonoBehaviour
{
    Rigidbody2D rb;
    public float minSpeed = 50f;
    public float maxSpeed = 100f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody2D>();
        Vector2 randomDirection = Random.insideUnitCircle;
        rb.AddForce(randomDirection * randomSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
