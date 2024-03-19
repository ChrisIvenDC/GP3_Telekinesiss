using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float groundOffset = 0.1f;
    public float rotationSpeed = 5f;
    public GameObject gameOverUI;

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0; 

            transform.position += direction.normalized * speed * Time.deltaTime;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


            GroundObject();
        }
    }

    void GroundObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hit))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + groundOffset, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Object touched by the player!");
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (other.CompareTag("Deadly"))
        {
            Destroy(gameObject);
        }
    }
}
