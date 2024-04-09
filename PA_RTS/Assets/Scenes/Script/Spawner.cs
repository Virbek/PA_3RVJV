using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float fin = 15f;
    private float deb = 0f;
    [SerializeField]
    private GameObject robotPrefab;

    private bool spawn = false;
    // Start is called before the first frame update
    void Update()
    {
        if (spawn)
        {
            Cooldown();
        }
    }

    public void Cooldown()
    {
        deb += Time.deltaTime;
        spawn = true;
        if(deb >= fin)
        {
            SpawnRob(robotPrefab);
            spawn = false;
            deb = 0f;
        }
    }

    private void SpawnRob(GameObject robPrefab)
    {
        Vector3 spawnPosition = new Vector3(transform.position.x - Random.Range(-5f, 5f), transform.position.y, 1);
        GameObject newRobot = Instantiate(robPrefab, spawnPosition, Quaternion.identity);
        
        Rigidbody rb = newRobot.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = newRobot.AddComponent<Rigidbody>();
        }

        // Assurez-vous que les contraintes ne sont pas figées
        rb.constraints = RigidbodyConstraints.None;
    }
}
