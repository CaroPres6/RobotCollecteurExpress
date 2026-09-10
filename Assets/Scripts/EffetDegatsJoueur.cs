using System.Collections;
using UnityEngine;

public class EffetDegatsJoueur : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renduRobot;
    [SerializeField] private CanvasGroup flashEcran;
    [SerializeField] private Color couleurDegat = new(1f, 0.25f, 0.25f);
    [SerializeField] private float dureeEffet = 0.45f;
    [SerializeField] private int nombreClignotements = 3;
    private Coroutine animationEnCours;
    private Color couleurInitiale;

    private void Awake()
    {
        if (renduRobot == null) renduRobot = GetComponent<SpriteRenderer>();
        if (renduRobot == null)
        {
            Debug.LogError("EffetDegatsJoueur exige un SpriteRenderer.");
            enabled = false;
            return;
        }
        couleurInitiale = renduRobot.color;
        if (flashEcran != null) flashEcran.alpha = 0f;
    }

    public void JouerEffetDegat()
    {
        if (animationEnCours != null) StopCoroutine(animationEnCours);
        animationEnCours = StartCoroutine(AnimerDegat());
    }

    private IEnumerator AnimerDegat()
    {
        int repetitions = Mathf.Max(1, nombreClignotements);
        float intervalle = Mathf.Max(0.05f, dureeEffet) / (repetitions * 2f);
        if (flashEcran != null) flashEcran.alpha = 0.35f;
        for (int i = 0; i < repetitions; i++)
        {
            renduRobot.color = couleurDegat;
            yield return new WaitForSeconds(intervalle);
            renduRobot.color = couleurInitiale;
            yield return new WaitForSeconds(intervalle);
        }
        if (flashEcran != null)
        {
            for (float t = 0f; t < 1f; t += Time.deltaTime / 0.2f)
            {
                flashEcran.alpha = Mathf.Lerp(0.35f, 0f, t);
                yield return null;
            }
            flashEcran.alpha = 0f;
        }
        renduRobot.color = couleurInitiale;
        animationEnCours = null;
    }
}