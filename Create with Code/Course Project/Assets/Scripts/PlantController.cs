using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IssueType
{
    NONE,
    BUGS,
    DEHYDRATION
}

public class PlantController : MonoBehaviour
{
    //--- Variables ---

    private Color currentColour = new Color(1,1,1,1);
    private float timer;
    private float startTime;
    private MeshRenderer renderComponent;
    private Transform canvas;
    private Transform player;

    private GameObject personalIssueObject;
    private Vector3 issueOffset = new Vector3(0, 10, 0);
    private IssueType personalIssueType;

    public GameObject issueObject;


    static float[] randomRange = new float[] { 4.0f, 12.0f };
    static float[] colourChange = new float[] { 1.0f, 0.7f };


    // Start is called before the first frame update
    void Start()
    {
        personalIssueType = IssueType.NONE;
        setTime();
        renderComponent = GetComponent<MeshRenderer>();
        canvas = GameObject.Find("Canvas").transform;
        player = GameObject.Find("Player").transform;
        personalIssueObject = Instantiate(issueObject, canvas);
        personalIssueObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            setTime();

            if (personalIssueType != IssueType.NONE)
            {
                Destroy(gameObject);
                Destroy(personalIssueObject);
            }

            GenerateIssue();
        }

        else
        {
            if (personalIssueType != IssueType.NONE)
            {
                // colour slowly depletes
                currentColour.b -= colourChange[0] / (startTime * 80.0f);
                currentColour.g -= colourChange[1] /(startTime * 80.0f);

                renderComponent.materials[0].SetColor("_Color", currentColour);
            }

            timer -= Time.deltaTime;
        }

        Vector3 s = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        personalIssueObject.transform.position = new Vector3(s.x, s.y, 0) + issueOffset;

        if (Input.GetKeyDown(KeyCode.O) && Vector3.Distance(transform.position, player.position) < 2)
        {
            Heal();
        }
    }

    void GenerateIssue()
    {
        personalIssueObject.SetActive(true);
        personalIssueType = (IssueType)Random.Range(1, 3);

        switch(personalIssueType)
        {
            case IssueType.NONE:
                Debug.LogError("GenerateIssue method generated a null Issue!");
                break;
            case IssueType.BUGS:
                personalIssueObject.transform.GetChild(0).gameObject.SetActive(false);
                personalIssueObject.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case IssueType.DEHYDRATION:
                personalIssueObject.transform.GetChild(1).gameObject.SetActive(false);
                personalIssueObject.transform.GetChild(0).gameObject.SetActive(true);
                break;
        }
    }

    void Heal()
    {
        personalIssueType = IssueType.NONE;
        setTime();
        currentColour = new Color(1,1,1,1);
        renderComponent.materials[0].SetColor("_Color", currentColour);
        personalIssueObject.SetActive(false);
    }

    void setTime()
    {
        timer = Random.Range(randomRange[0], randomRange[1]);
        startTime = timer;
    }
}
