using UnityEngine;

public class AlgeSpredning : MonoBehaviour
{
    // I inspektor vælges hvilken alge
   [SerializeField] private GameObject algePrik;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    float radius = Random.Range(1f, 3f); // Hvor stor er den usynlige cirkel
    Vector2 punkt = Random.insideUnitCircle * radius; // Hvor skal den grønne prik sættes
    //Laver en kopi af alge prikken på det beregende punkt z=0, den har inten rotation
    Instantiate(algePrik, new Vector3(punkt.x, punkt.y, 0f), Quaternion.identity);
    Debug.Log($"Radius: {radius}, punkt: {punkt}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
