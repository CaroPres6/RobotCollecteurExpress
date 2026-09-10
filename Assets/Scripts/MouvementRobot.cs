using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class MouvementRobot : MonoBehaviour
{
    [SerializeField] private float vitesse = 5f;

    private Rigidbody2D corps;
    private Vector2 direction;

    private Animator animator;

    private void Awake()
    {
        corps = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // TODO 1 : lire les axes Horizontal et Vertical.
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        // TODO 2 : créer et normaliser le vecteur direction.
        direction = new Vector2(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        // TODO 3 : déplacer le Rigidbody2D selon la direction et la vitesse.
        corps.MovePosition(corps.position + direction * vitesse * Time.fixedDeltaTime);
        animator.SetBool("EnMouvement", direction.sqrMagnitude > 0.01f);
    }

    /*
     * BANQUE DE LIGNES — À REPLACER DANS LE BON ORDRE
     *
     * float vertical = Input.GetAxisRaw("Vertical");
     * corps.MovePosition(corps.position + direction * vitesse * Time.fixedDeltaTime);
     * direction = new Vector2(horizontal, vertical).normalized;
     * float horizontal = Input.GetAxisRaw("Horizontal");
     */
}

