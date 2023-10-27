using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private Text _textField;
    [SerializeField] private int _frequency = 1;

    private float _timer = 0f;

    void Update()
    {
        var deltaTime = Time.unscaledDeltaTime;

        _timer += deltaTime;

        if (_timer >= 1f / _frequency)
        {
            _timer = 0f;
            var fps = Mathf.FloorToInt(1.0f / deltaTime);
        
            _textField.text = $"FPS: {fps.ToString()}";
        }
    }
}




