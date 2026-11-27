using UnityEngine;
using System.Collections; // gør IEnumerator tilgængelig

public class AlgeSpredning : MonoBehaviour
{
    // I inspektor vælges hvilken alge
   [SerializeField] private GameObject algePrik;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //IEnumarator gør at koden kan holde pause og starte bagefter
 IEnumerator Start()
 {
     // Vælger størrelsen på cirklen én gang for hele algepletten.
     float radius = Random.Range(1f, 3f);

     // Løkke Gentager koden mellem  20 gange.
     //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-for-statement
     for (int antal = 0; antal < 20; antal++)
     {
         // Finder et nyt tilfældigt punkt til hver prik.
         Vector2 punkt = Random.insideUnitCircle * radius;

         // Opretter en kopi af algeprikken på punktet uden rotation.
         //https://docs.unity.com/en-us/engine/6000.0/script-reference/unityengine/object/instantiate
         Instantiate(algePrik, new Vector3(punkt.x, punkt.y, 0f), Quaternion.identity);
         // Venter et halvt sekund, før løkken fortsætter.
         //https://docs.unity.com/en-us/engine/6000.0/script-reference/unityengine/waitforseconds
         yield return new WaitForSeconds(0.5f);
     }
 }
}