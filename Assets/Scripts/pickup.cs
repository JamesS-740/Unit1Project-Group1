using UnityEngine;

public class pickup : MonoBehaviour
{
    float Rotatespeed = 3;

    float time;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * Rotatespeed);
    }

}
