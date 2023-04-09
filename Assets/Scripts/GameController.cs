using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]private DoorKnob doorKnob;
    public bool doorKnobActive = false;
    [SerializeField]private Transform r_MouseSpawner;
    [SerializeField]private Transform l_MouseSpawner;
    [SerializeField]private Transform spiderSpawner;
    [SerializeField]private GameObject mouse;
    [SerializeField]private GameObject spider;
    public bool spiderActive = false;

    public bool poopletStillOnEnterPoint = false;
    [SerializeField]private GameObject[] poopletPrefabs;
    [SerializeField]private Transform poopletSpawner;
    [SerializeField]private float poopletSpawnSpeedMin = 2.0f;
    [SerializeField]private float poopletSpawnSpeedMax = 6.0f;
    [SerializeField]private LayerMask layermask;

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(poopletSpawner.position, 0.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(mouseSpawnerTimer());
        StartCoroutine(spiderSpawnerTimer());
        StartCoroutine(doorKnobTimer());
        StartCoroutine(generatePooplets());
    }

    IEnumerator mouseSpawnerTimer ()
    {
        while (true)
        {
            float newTime = Random.Range(0.5f, 2.0f);
            int spawnerSide = Random.Range(0, 10);

            yield return new WaitForSeconds(newTime);

            if (spawnerSide <= 5)
            {
                Instantiate(mouse, r_MouseSpawner);
            }
            else
            {
                Instantiate(mouse, l_MouseSpawner);
            }
            
        }
    }

    // Rework spider timer when events are implemented
    IEnumerator spiderSpawnerTimer ()
    {
        while (true)
        {
            if (!spiderActive)
            {
                float newTime = Random.Range(1.5f, 5.0f);

                yield return new WaitForSeconds(newTime);

                Instantiate(spider, spiderSpawner);
                spiderActive = true;
            }
            yield return null;
        }
    }

    IEnumerator doorKnobTimer ()
    {
        while (true)
        {
            if (!doorKnobActive)
            {
                float newTime = Random.Range(1.5f, 5.0f);

                yield return new WaitForSeconds(newTime);
                doorKnob.StartAnim();
                doorKnobActive = true;
            }
            yield return null;
        }
    }

    IEnumerator generatePooplets ()
    {
        while (true)
        {
            float instantiationSpeed = Random.Range(poopletSpawnSpeedMin,poopletSpawnSpeedMax);

            yield return new WaitForSeconds(instantiationSpeed);

            Collider[] hitColliders = Physics.OverlapSphere(poopletSpawner.GetComponent<Collider>().transform.position, 0.5f, layermask);
            if (hitColliders.Length == 0)
            {  
                // Currently only one type of pooplet is being used.
                GameObject instance = Instantiate(poopletPrefabs[0], poopletSpawner.position, Quaternion.identity);
                instance.name = poopletPrefabs[0].name;
                Debug.Log("Instance.name: " + instance.name);
                // pooplets.AddPooplet(instance.name);
            }
        }
    }
}
