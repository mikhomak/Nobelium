using UnityEngine;

public class CameraPostEffect : MonoBehaviour {
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    private Transform camTransform;

    // How long the object should shake for.
    [SerializeField] private float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.

    [SerializeField] private float minShakeAmount = 0.0f;
    [SerializeField] private float maxShakeAmount = 0.5f;
    [SerializeField] private float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake() {
        if (camTransform == null) {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable() {
        originalPos = camTransform.localPosition;
    }

    void Update() {
        float shakeAmount =
            CommonMethods.getValueInRange(AudioPeer.getAudioBandBuffer(0), minShakeAmount, maxShakeAmount);
        camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

        shakeDuration -= Time.deltaTime * decreaseFactor;
    }
}