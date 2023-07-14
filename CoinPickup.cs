using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    [SerializeField] AudioClip coinPickuoSFX;
    [SerializeField] int coinPoints = 100;

    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !wasCollected) {
            wasCollected = true;
            AudioSource.PlayClipAtPoint(coinPickuoSFX, Camera.main.transform.position); 
            Destroy(gameObject); 
            FindObjectOfType<GameSession>().AddScore(coinPoints);
        }
    }
}
