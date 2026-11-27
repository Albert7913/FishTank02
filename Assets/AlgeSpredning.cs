using UnityEngine;
using System.Collections; // Gør IEnumerator tilgængelig.

public class AlgeSpredning : MonoBehaviour
{
    // I Inspector trækkes AlgeDot-prefabben ind i feltet Alge Prik.
    [SerializeField] private GameObject algePrik;

    // I Inspector tilknyttes akvariets fire vægge.
    // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/SerializeField.html
    [SerializeField] private SpriteRenderer Left_wall;
    [SerializeField] private SpriteRenderer Right_wall;
    [SerializeField] private SpriteRenderer Bund_wall;
    [SerializeField] private SpriteRenderer Top_wall;

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

            // Holder centrum mellem væggenes indvendige kanter.
            // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Mathf.Clamp.html
            centrum.x = Mathf.Clamp(
                centrum.x,
                Left_wall.bounds.max.x,
                Right_wall.bounds.min.x
            );

            centrum.y = Mathf.Clamp( //hold tallet mellem en nedre og en øvre grænse
                centrum.y,
                Bund_wall.bounds.max.y,
                Top_wall.bounds.min.y
            );

            // Vælger størrelsen på cirklen én gang for denne algeplet.
            float radius = Random.Range(1f, 3f);

            // Gentager koden mellem klammerne 20 gange.
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-for-statement
            for (int antal = 0; antal < 20; antal++)
            {
                // Finder et nyt tilfældigt punkt omkring plettens centrum.
                Vector2 punkt = centrum + Random.insideUnitCircle * radius;

                // Opretter en grøn prik og gemmer en reference til kopien.
                // https://docs.unity.com/en-us/engine/6000.0/script-reference/unityengine/object/instantiate
                GameObject nyPrik = Instantiate(
                    algePrik,
                    new Vector3(punkt.x, punkt.y, 0f),
                    Quaternion.identity
                );

                // Henter den nye priks Sprite Renderer og dens yderkanter.
                // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/GameObject.GetComponent.html
                // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Renderer-bounds.html
                Bounds prikKanter = nyPrik.GetComponent<SpriteRenderer>().bounds;

                // Fjerner prikken, hvis den rager ud over en af væggenes indvendige kanter.
                // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Object.Destroy.html
                if (prikKanter.min.x < Left_wall.bounds.max.x ||
                    prikKanter.max.x > Right_wall.bounds.min.x ||
                    prikKanter.min.y < Bund_wall.bounds.max.y ||
                    prikKanter.max.y > Top_wall.bounds.min.y)
                {
                    Destroy(nyPrik);
                }

                // Venter et halvt sekund, før løkken fortsætter.
                // https://docs.unity.com/en-us/engine/6000.0/script-reference/unityengine/waitforseconds
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}