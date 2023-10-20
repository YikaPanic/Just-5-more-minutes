using UnityEngine;

public class CoinPick : MonoBehaviour
{
    public float pickupDistance = 1.0f;

    private GameObject player;
    private PlayerShooting playerShooting; // shoot scripts

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerShooting = player.GetComponent<PlayerShooting>(); // get shoot scripts
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= pickupDistance)
        {
            playerShooting.CollectCoin(); // collect coin
            Destroy(gameObject);
        }
    }
}
