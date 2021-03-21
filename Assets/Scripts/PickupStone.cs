using UnityEngine;

public class PickupStone : MonoBehaviour
{
    public Shooting shotScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("PixelRock"))
        {
            Destroy(collision.gameObject);
            shotScript.AddStone();
        }
    }
}
