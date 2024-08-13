using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeController : MonoBehaviour
{

    // Settings
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 7;
    public int GapBalanceValue = 0;

    // References
    public GameObject BodyPrefab;
    public GameObject SpecialBodyPrefab;
    public Transform WorldCenter; // Centro do mundo (esfera)

    // Lists
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();
    private AudioSource sound;
    private Rigidbody rb;
    

    void Awake()
    {
        sound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Time.timeScale = 1;
        SpecialGrowSnake();
        SpecialGrowSnake();
        SpecialGrowSnake();
        SpecialGrowSnake();
        SpecialGrowSnake();
        SpecialGrowSnake();
        SpecialGrowSnake();
        SpecialGrowSnake();
    }

    void Update()
    {
        // Move forward
        transform.position += MoveSpeed * Time.deltaTime * transform.forward;

        // Steer
        float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

       

        // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snake's path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += BodySpeed * Time.deltaTime * moveDirection;

            // Rotate body towards the point along the snake's path
            body.transform.LookAt(point);

            index++;
        }

        GapBalance();
        RestartGameButton();
        PauseButton();
    }

    private void GrowSnake()
    {
        // Instantiate body instance and add it to the list
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }

    private void SpecialGrowSnake()
    {
        // Instantiate body instance and add it to the list
        GameObject body = Instantiate(SpecialBodyPrefab);
        BodyParts.Add(body);
    }

    private void GapBalance()
    {
        if (GapBalanceValue < 4)
        {
            return;
        }
        else
        {
            Gap -= 1;
            GapBalanceValue = 0;
        }

        if (Gap < 4)
        {
            Gap = 4;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cake"))
        {
            sound.Play();
            Destroy(other.gameObject, 0.1f);
            GrowSnake();
            GrowSnake();
            GrowSnake();
            GrowSnake();
            GameUIManeger.instance.ScoreUpdate();
            MoveSpeed += 0.1f;
            BodySpeed += 0.1f;
            GapBalanceValue += 1;
        }

        if (other.CompareTag("snakeBody"))
        {
            GameUIManeger.GameOver();
        }

        if (other.CompareTag("specialPlanet"))
        {
            //transform.position = new Vector3(37f, 9.82f, 8.54f);
            FakeGravity.GravityCancell(1);
            rb.useGravity = false; // Desativa a gravidade 
            Vector3 targetPosition = new Vector3(37, 10, 9); // Exemplo de posição alvo
            rb.transform.position = targetPosition;
            StartCoroutine(ReenableGravityAfterDelay()); // Reativa a gravidade após um curto período
        }

    }

    public FakeGravity FakeGravity;
    IEnumerator ReenableGravityAfterDelay()
    {
        yield return new WaitForSeconds(1f); // Espera meio segundo
        rb.useGravity = true; // Reativa a gravidade
        FakeGravity.GravityCancell(2);
    }

    public GameOverScreen GameOverScreen;
    public void RestartGameButton()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameOverScreen.RestartGame();
        }
    }

    public PauseScreen PauseScreen;
    public void PauseButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen.Pause();
        }
    }

    public GameUIManeger GameUIManeger;
 

}
