using UnityEngine;
using TMPro;

public class TextComponent : MonoBehaviour {
    [SerializeField] private GameObject targetLight;
    private TMP_Text _tmpText;
    private float _maxAlpha = 1f;
    private float _minAlpha = 0f;
    private float _fadeSpeed = 1f;
    private bool _isInRange = false;

    private void Start() {
        _tmpText = GetComponent<TMP_Text>();

        if (_tmpText != null)
        {
            Color initialColor = _tmpText.color;
            initialColor.a = _minAlpha;
            _tmpText.color = initialColor;
        }
    }

    private void Update() {
        if (_tmpText != null)
        {
            Color textColor = _tmpText.color;

            if (_isInRange)
            {
                textColor.a = Mathf.MoveTowards(textColor.a, _maxAlpha, _fadeSpeed * Time.deltaTime);
            }
            else
            {
                textColor.a = Mathf.MoveTowards(textColor.a, _minAlpha, _fadeSpeed * Time.deltaTime);
            }

            _tmpText.color = textColor;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == targetLight)
        {
            _isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject == targetLight)
        {
            _isInRange = false;
        }
    }
}