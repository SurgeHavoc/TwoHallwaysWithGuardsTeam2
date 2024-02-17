using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int remainingGuards = 2;
    //public float rotationSpeed = 3f;
    public Vector3 openRotation = new Vector3(0, -110, 90);

    private bool isOpening = false;

    public List<GameObject> guards;
    public GameObject door;
    public GameObject door2;

    AudioSource WinAudio;

    private void Start()
    {
        guards = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        door = GameObject.Find("gate_low_textured");
        door2 = GameObject.Find("gate_low_textured (1)");

        WinAudio = GetComponent<AudioSource>();
    }

    public void GuardDied(GameObject guard)
    {
        guards.Remove(guard);
        if(guards.Count == 0 && !isOpening)
        {
            isOpening = true;
            StartCoroutine(RotateDoor());
        }
    }

    private IEnumerator RotateDoor()
    {
        float startRotation = door.transform.rotation.eulerAngles.y;
        float startRotation2 = door2.transform.rotation.eulerAngles.y;
        float targetRotation = -110.0f;
        float targetRotation2 = -250.0f;
        float rotationDuration = 2.0f;

        WinAudio.Play();

        float t = 0.0f;
        while(t < 1.0f)
        {
            t += Time.deltaTime / rotationDuration;
            float newRotation = Mathf.LerpAngle(startRotation, targetRotation, t);
            float newRotation2 = Mathf.LerpAngle(startRotation2, targetRotation2, t);
            door.transform.rotation = Quaternion.Euler(0.0f, newRotation, 90f);
            door2.transform.rotation = Quaternion.Euler(0.0f, newRotation2, 90f);
            yield return null;
        }
    }
}
