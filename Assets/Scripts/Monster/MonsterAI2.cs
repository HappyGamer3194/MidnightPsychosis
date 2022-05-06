using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterAI2 : MonoBehaviour
{
    #region states
    #region Idle
    public bool idle;
    public float idleAmount;
    public float idleAmountMin;
    public float idleAmountMax;
    public int idleGoal;
    public Transform[] idlePositions;
    #endregion

    #region Search
    public bool search;
    public Transform[] searchPositions;
    #endregion

    #region Hunt
    public bool hunt;
    public Transform[] enterances;
    #endregion
    #endregion

    public float timer;
    float timerMax = 60;
    float timerMin = 30;

    public GameObject player;
    public GameObject sanity;
    public GameManager gameManager;

    public float visionRange;
    public float visionAngle;

    public AudioSource audioSource;
    public AudioClip[] spottedSound;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        idle = true;
        hunt = false;
        idleGoal = ((int)Random.Range(idleAmountMin, idleAmountMax));
    }

    // Update is called once per frame
    void Update()
    {
        if (!hunt)
        {
            timer -= Time.deltaTime;
        }


        if (idle == true && timer <= 0)
        {
            timer = Random.Range(timerMin, timerMax);
            SetTransform(idlePositions[Random.Range(0,idlePositions.Length)]);
            Debug.Log("Monster is at Idle Position : " + Random.Range(0, idlePositions.Length));

            idleAmount += 1;

            if (idleAmount == idleGoal)
            {
                idle = false;
                search = true;
            }
        }

        if (search == true)
        {
            Search();

            if (timer <= 0)
            {
                timer = Random.Range(timerMin, timerMax);

                SetTransform(searchPositions[Random.Range(0, searchPositions.Length)]);

                Debug.Log("Monster is at Search Position : " + Random.Range(0, searchPositions.Length));
            }
        }
    }

    void SetTransform(Transform transform)
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 2.479165f,  transform.position.z);
        gameObject.transform.rotation = transform.rotation;
    }

    void Search()
    {
        Vector3 vectorToPlayer = player.transform.position - transform.position;

        if (Vector3.Distance(transform.position, player.transform.position) <= visionRange)
        {
            if (Vector3.Angle(transform.forward, vectorToPlayer) <= visionAngle)
            {
                Spotted();
            }
        }
    }

    void Hunt()
    {
        hunt = true;
        search = false;

        SetTransform(enterances[Random.Range(0, enterances.Length)]);

        Debug.Log("Monster is at Hunt Position : " + Random.Range(0, enterances.Length));

        transform.LookAt(player.transform);
    }

    void Spotted()
    {
        audioSource.clip = spottedSound[Random.Range(0, spottedSound.Length)];
        audioSource.PlayOneShot(audioSource.clip, 0.7f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.playerAlive = false;
            gameManager.playerTouchedMonster = true;
        }
    }
}
