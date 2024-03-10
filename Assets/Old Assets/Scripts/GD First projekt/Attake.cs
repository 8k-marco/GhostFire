using UnityEngine;

public class Attake : MonoBehaviour
{
    [SerializeField] private GameObject[] fireBallPrefabs;
    [SerializeField] private Transform fireBallSpawnLeft;
    [SerializeField] private Transform fireBallSpawnRight;

    // Falls der Fire-Knopf gedrückt wird, wird ein Feuerball erstellt und abgefeuert
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            var fireBallClone = Instantiate(GetRandomFireBall(), Input.GetAxis("Horizontal") > 0 ? fireBallSpawnRight.position : fireBallSpawnLeft.position, Quaternion.identity);
            // Einstellen der Feuer-Richtung (links/rechts)
            fireBallClone.GetComponent<FireBall>().SetDirection(Input.GetAxis("Horizontal") > 0 ? Vector3.right : Vector3.left);
        }
    }

    // Gibt einen zufälligen Feuerball zurück
    private GameObject GetRandomFireBall()
    {
        var selectedIndex = Random.Range(0, fireBallPrefabs.Length);
        return fireBallPrefabs[selectedIndex];
    }

}
