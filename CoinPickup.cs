using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    [SerializeField] AudioClip coinPickuoSFX;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            AudioSource.PlayClipAtPoint(coinPickuoSFX, Camera.main.transform.position); 
            Destroy(gameObject); 
        }
    }
}
