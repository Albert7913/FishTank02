using UnityEngine;
using System.Collections; // Gør IEnumerator tilgængelig.

public class AlgeSpredning : MonoBehaviour
{
    // I Inspector trækkes AlgeDot-prefabben ind i feltet Alge Prik.
    [SerializeField] private GameObject algePrik;

    // Start kører ved spilstart.
    // IEnumerator gør, at metoden kan holde pause og fortsætte bagefter.
    IEnumerator Start()
    {
        // Udgangspunktet for at finde algepletternes centrum er (0, 0).
        Vector2 centrum = Vector2.zero;

        // Laver to algepletter efter hinanden.
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-for-statement
        for (int plet = 0; plet < 2; plet++)
        {
            // Vælger et nyt centrum højst 2 Unity-enheder fra det forrige.
            // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Random-insideUnitCircle.html
            centrum = centrum + Random.insideUnitCircle * 2f;

            // Vælger størrelsen på cirklen én gang for denne algeplet.
            float radius = Random.Range(1f, 3f);

            // Gentager koden mellem klammerne 20 gange.
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-for-statement
            for (int antal = 0; antal < 20; antal++)
            {
                // Finder et nyt tilfældigt punkt omkring plettens centrum.
                Vector2 punkt = centrum + Random.insideUnitCircle * radius;

                // Opretter en kopi af algeprikken på punktet uden rotation.
                // https://docs.unity.com/en-us/engine/6000.0/script-reference/unityengine/object/instantiate
                Instantiate(algePrik, new Vector3(punkt.x, punkt.y, 0f), Quaternion.identity);

                // Venter et halvt sekund, før løkken fortsætter.
                // https://docs.unity.com/en-us/engine/6000.0/script-reference/unityengine/waitforseconds
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}