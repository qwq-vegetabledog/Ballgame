using UnityEngine;
using UnityEngine.SceneManagement;

public class FallReset : MonoBehaviour
{
    
    public float threshold = -4f;

    void Update()
    {
        
        if (transform.position.y < threshold)
        {
           
            Time.timeScale = 1f;

            SceneManager.LoadScene(0);
        }
    }
}
