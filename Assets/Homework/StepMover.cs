using UnityEngine;

public class StepMover : MonoBehaviour
{
    [SerializeField] float step = 1;
    [SerializeField] float speed = 1;

    Vector3 target;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {

        if (transform.position == target)
        {    
            if (Input.GetKeyDown(KeyCode.RightArrow))
                target += Vector3.right * step;
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                target += Vector3.left * step;
            else if (Input.GetKeyDown(KeyCode.UpArrow))
                target += Vector3.up * step;
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                target += Vector3.down * step;
        }
        else
           transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
