using UnityEngine;

public class Cube : MonoBehaviour
{
	private void Update ()
    {
        transform.Translate(Vector3.left * Time.deltaTime);
	}
}
