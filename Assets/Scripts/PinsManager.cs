using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsManager : MonoBehaviour
{
    public GameObject lPins;
    public GameObject rPins;

    private Dictionary<Transform, Vector3> lPinsPositions = new Dictionary<Transform, Vector3>();
    private Dictionary<Transform, Quaternion> lPinsRotations = new Dictionary<Transform, Quaternion>();
    private Dictionary<Transform, Rigidbody> lPinsRigidbodies = new Dictionary<Transform, Rigidbody>();

    private Dictionary<Transform, Vector3> rPinsPositions = new Dictionary<Transform, Vector3>();
    private Dictionary<Transform, Quaternion> rPinsRotations = new Dictionary<Transform, Quaternion>();
    private Dictionary<Transform, Rigidbody> rPinsRigidbodies = new Dictionary<Transform, Rigidbody>();

    public float dropDuration = 10.0f;
    public int pinCount = 0;

    public Animator pinsetterL;
    public Animator pinsetterR;

    public bool toggleL = false;
    public bool toggleR = false;

    void Start()
    {
        StoreInitialTransforms(lPins, lPinsPositions, lPinsRotations, lPinsRigidbodies);
        StoreInitialTransforms(rPins, rPinsPositions, rPinsRotations, rPinsRigidbodies);
    }

    void Update()
    {
        if (toggleL)
        {
            pinsetterL.SetTrigger("Reset");
            ResetPins(lPinsPositions, lPinsRotations, lPinsRigidbodies);
            toggleL = false;
        }

        else if (toggleR)
        {
            pinsetterR.SetTrigger("Reset");
            ResetPins(rPinsPositions, rPinsRotations, rPinsRigidbodies);
            toggleR = false;
        }
    }

    private void StoreInitialTransforms(GameObject parent, Dictionary<Transform, Vector3> positions,
        Dictionary<Transform, Quaternion> rotations, Dictionary<Transform, Rigidbody> rigidbodies)
    {
        foreach (Transform child in parent.transform)
        {
            positions[child] = child.localPosition;
            rotations[child] = child.localRotation;

            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rigidbodies[child] = rb;
            }
        }
    }

    private void ResetPins(Dictionary<Transform, Vector3> positions,
    Dictionary<Transform, Quaternion> rotations,
    Dictionary<Transform, Rigidbody> rigidbodies)
    {
        foreach (Transform t in positions.Keys)
        {
            t.localRotation = rotations[t];

            Rigidbody rb = null;
            if (rigidbodies.ContainsKey(t))
            {
                rb = rigidbodies[t];
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

            StartCoroutine(ResetSequence(t, positions[t], rb));
        }
    }

    private IEnumerator ResetSequence(Transform pin, Vector3 originalPos, Rigidbody rb)
    {
        float phaseDuration = 0.6f;
        float waitDuration = 1.0f;

        Vector3 jumpPos = new Vector3(originalPos.x, originalPos.y + 3f, originalPos.z);
        pin.localPosition = jumpPos;

        Vector3 lowerPos = new Vector3(originalPos.x, originalPos.y + 0.9f, originalPos.z);
        yield return StartCoroutine(SmoothMove(pin, jumpPos, lowerPos, phaseDuration));

        yield return new WaitForSeconds(waitDuration);

        yield return StartCoroutine(SmoothMove(pin, pin.localPosition, originalPos, phaseDuration));

        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }

    private IEnumerator SmoothMove(Transform obj, Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            obj.localPosition = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        obj.localPosition = to;
    }
}