using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GlitchButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI tmpText;
    private Color originalColor;
    private string originalText;
    private bool glitching = false;
    private AudioSource audioSource;

    void Start()
    {
        tmpText = GetComponentInChildren<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>(); // ? Grab AudioSource
        originalColor = tmpText.color;
        originalText = tmpText.text;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        glitching = true;
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play(); // ? Play sound on hover
        }
        StartCoroutine(Flicker());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        glitching = false;
        tmpText.color = originalColor;
        tmpText.text = originalText;
    }

    System.Collections.IEnumerator Flicker()
    {
        while (glitching)
        {
            tmpText.color = new Color(Random.value, Random.value, Random.value);
            tmpText.text = GlitchText(originalText);
            yield return new WaitForSeconds(0.05f);
            tmpText.text = originalText;
        }
    }

    private string GlitchText(string baseText)
    {
        string[] glitchChars = new string[] { "#", "@", "%", "&", "*", "!", "?" };
        char[] chars = baseText.ToCharArray();
        int index = Random.Range(0, chars.Length);
        chars[index] = glitchChars[Random.Range(0, glitchChars.Length)][0];
        return new string(chars);
    }
}
