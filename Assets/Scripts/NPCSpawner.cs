using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject villagerPrefab;
    [SerializeField]
    private int minAmount, maxAmount;
    private int randomAmount;

    private void Start() {
        randomAmount = Random.Range(minAmount, maxAmount);
        Vector3 randomLocation;
        for (int i = 0; i < randomAmount; i++) {
        randomLocation = transform.position + new Vector3(Random.Range(-5, 5), transform.position.y, Random.Range(-5, 5));
        Instantiate(villagerPrefab, randomLocation, Quaternion.identity, transform);
        }
    }
}
