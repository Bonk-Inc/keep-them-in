using UnityEngine;

public class HitHandler : MonoBehaviour, IHittable {
    [SerializeField]
    private int health = 1;
    private bool dead;

    private void OnDestroy() {
        dead = true;
    }

    public void Hit(HittableParams param) {
        health -= param.dmg;
        if (health <= 0 && !dead) {
            Destroy(gameObject);//RIP enemy :(
        }
    }
}