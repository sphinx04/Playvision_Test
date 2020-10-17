using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour
{
    public GameObject NextLevel;
    public float levelRespawnDelay = .2f;
    public Vector3 levelRespawnOffset = new Vector3(0, -5, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadNext(other.transform, levelRespawnDelay));
        }
    }

    IEnumerator LoadNext(Transform player, float time)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();

        yield return new WaitForSeconds(time);

        player.SetParent(null);
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        GameObject nextLevel = Instantiate(NextLevel, player.position + levelRespawnOffset, new Quaternion());

        player.SetParent(nextLevel.transform);

        Destroy(transform.parent.gameObject);
    }
}
