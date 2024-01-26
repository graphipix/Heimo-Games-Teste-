using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] Transform Win, lose = default;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("YOU WIN");
            Win.gameObject.SetActive(true);
            Invoke(nameof(RestartGame), 3);
        }
        if (other.gameObject.CompareTag("Competitor"))
        {
            print("YOU LOSE");
            lose.gameObject.SetActive(true);
            Invoke(nameof(RestartGame), 3);
        }
    }

    private void RestartGame() 
    {
        SceneManager.LoadScene("Racing Track");
    }
}
