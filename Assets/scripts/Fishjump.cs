using UnityEngine;

public class FishJump : MonoBehaviour
{

    private Vector3 target;
    private Vector3 start;
    public float jumpHeight = 5f;
    public float duration = 1.5f;
    private float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetupJump(Vector3 roadCenter, Quaternion roadRotation)
    {
        
        bool fromLeft = Random.value > 0.5f;
        float dir = fromLeft ? 1f : -1f;

        start = roadCenter + (roadRotation * new Vector3(-10f * dir, -5f, 0));
        target = roadCenter + (roadRotation * new Vector3(10f * dir, -5f, 0));

        transform.position = start;
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == Vector3.zero) return;

        timer += Time.deltaTime;
        float progress = timer / duration;

        Vector3 currentPos = Vector3.Lerp(start, target, progress);
        
        currentPos.y += jumpHeight * Mathf.Sin(Mathf.PI * progress);
        
        Vector3 moveDirection = currentPos - transform.position;
        if(moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }

        transform.position = currentPos;
        
        if (progress >= 1f)
        {
            timer = 0;
            
            Vector3 temp = start;
            start = target;
            target = temp;
    
        }

    }
}
