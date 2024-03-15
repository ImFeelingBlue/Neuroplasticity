using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RandomMovements : MonoBehaviour
{
    // Blinking Variables
    [SerializeField] RectTransform bottomLipPanelTransform;
    [SerializeField] RectTransform topLipPanelTransform;
    [SerializeField] Vector3 bottomLipBlink;
    [SerializeField] Vector3 topLipBlink;
    [SerializeField] Vector3 bottomLipOpen;
    [SerializeField] Vector3 topLipOpen;
    bool lidsAreClosed = false;

    // Eye color change variables
    [SerializeField] Transform Player;
    [SerializeField] GameObject PurpleEyeBall;
    [SerializeField] GameObject RedEyeBall;
    [SerializeField] TMP_Text DetectionSkillText; 

    private bool eyeColorChange = false;
    private bool enemyEncounterTracker = false;
    private bool randomEnemyDetectionCheck = false;
    int randomSeeEnemy;
    public int DetectionSkill = 0;
    int detectionChance = 10;
    bool skillPointGiven = false;

    // Eye movement variables
    [SerializeField] RectTransform redEyeBallPanel;
    [SerializeField] Camera mainCamera;
    [SerializeField] float fixedDistance = 16f;
    bool eyeMovementCoroutineCheck = false;

    void Start()
    {
        StartCoroutine(BlinkRoutine());
        PurpleEyeBall.SetActive(true);
        RedEyeBall.SetActive(false);
    }
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(Player.position, enemy.transform.position);

            // Detection skill and chance alteration to randomize enemy detection
            if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) && DetectionSkill < 5)
            {
                DetectionSkill++;
                detectionChance -= 2;
                skillPointGiven = true;
                DetectionSkillText.text = "Detection: " + DetectionSkill.ToString();
            }
            else if ((Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0)) && DetectionSkill > 0)
            {
                DetectionSkill--;
                detectionChance += 2;
                DetectionSkillText.text = "Detection: " + DetectionSkill.ToString();
            }

            if ((distance <= 10f && !randomEnemyDetectionCheck) || (distance <= 10f && skillPointGiven))
            {
                randomEnemyDetectionCheck = true;
                skillPointGiven = false;
                randomSeeEnemy = Random.Range(1, detectionChance + 1);
            }
            else if (distance > 10f && randomEnemyDetectionCheck)
            {
                randomEnemyDetectionCheck = false;
            }

            // Change the eye color to red when the player is close to the enemy
            if (distance <= 10f && !eyeColorChange && randomSeeEnemy == 1)
            {
                eyeColorChange = true;
                enemyEncounterTracker = true;
                PurpleEyeBall.SetActive(false);
                RedEyeBall.SetActive(true);
                StartCoroutine(KeepTheLidsClosed());
                if (!eyeMovementCoroutineCheck)
                {
                    eyeMovementCoroutineCheck = true;
                    RedEyeMovement();
                }
            }
            // Change the eye color to purple when the player is away from the enemy
            else if (distance > 10f && enemyEncounterTracker)
            {
                enemyEncounterTracker = false;
                eyeColorChange = false;
                PurpleEyeBall.SetActive(true);
                RedEyeBall.SetActive(false);
                StartCoroutine(KeepTheLidsClosed());
            }
        }
    }

    void RedEyeMovement()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float closestDistance = Mathf.Infinity;
        Vector3 closestPosition = Vector3.zero;

        foreach (GameObject enemyObject in enemies)
        {
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(enemyObject.transform.position);
            float enemyDistance = Vector3.Distance(redEyeBallPanel.position, screenPosition);

            if (enemyDistance < closestDistance)
            {
                closestDistance = enemyDistance;
                closestPosition = screenPosition;
            }
        }

        // Calculate a position that lies a fixed distance towards the enemy
        Vector3 fixedTargetPosition = redEyeBallPanel.position + (closestPosition - redEyeBallPanel.position).normalized * fixedDistance;
        StartCoroutine(MoveEye(fixedTargetPosition)); // Move eye towards the fixed target position
    }

    IEnumerator MoveEye(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        float duration = 0.3f;

        yield return new WaitForSeconds(0.5f); // Delay before moving back

        Vector3 originalPosition = redEyeBallPanel.position; // Store original position

        // Move the red eye smoothly to the target position
        while (elapsedTime < duration)
        {
            redEyeBallPanel.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the panel reaches exactly the target position
        redEyeBallPanel.position = targetPosition;

        // Delay before moving back to original position
        yield return new WaitForSeconds(1.5f);

        // Move the red eye smoothly back to the original position
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            redEyeBallPanel.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the panel reaches exactly the original position
        redEyeBallPanel.position = originalPosition;
        eyeMovementCoroutineCheck = false;
    }

    // Coroutine responsible for controlling the blinking of the eyes
    IEnumerator BlinkRoutine()
    {
        while (true)
        {
            int randomBlink = Random.Range(1, 21);

            yield return new WaitForSeconds(randomBlink);

            // Blink if the lids are not already closed
            if (!lidsAreClosed)
            {
                StartCoroutine(KeepTheLidsClosed());
            }

            // Calculate the time to wait before blinking again to ensure a total of 20 seconds between blinks
            int waitBeforeBlinkingAgain = 21 - randomBlink;
            yield return new WaitForSeconds(waitBeforeBlinkingAgain);
        }
    }

    // Coroutine responsible for closing and opening the lids
    IEnumerator KeepTheLidsClosed()
    {
        lidsAreClosed = true;

        bottomLipPanelTransform.position = bottomLipBlink;
        topLipPanelTransform.position = topLipBlink;

        yield return new WaitForSeconds(0.4f);

        bottomLipPanelTransform.position = bottomLipOpen;
        topLipPanelTransform.position = topLipOpen;

        lidsAreClosed = false;
    }
}
