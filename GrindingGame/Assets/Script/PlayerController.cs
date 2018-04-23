using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    private Animator anim;
    Rigidbody rigidb;
    private NavMeshAgent navMeshAgent;
    public float rotationSpeed = 100.0F;
    public Rigidbody arrow;
    public Transform arrowPoint;
    public float arrowSpeed;
    public RectTransform gameOverPanel;
    public RectTransform gameWonPanel;
    public RectTransform pausePanel;



    private void OnEnable()
    {
        rigidb = GetComponent<Rigidbody>();
        rigidb.velocity = Vector3.zero;
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim.SetBool("isDead", false);
    }
	
	// Update is called once per frame
	void Update () {
        StopAndAttack();
        if (Input.GetKeyDown(KeyCode.P))
        {
            freezeScreen();
        }
        if (PlayerInventory.currentHealth <= 0)
        {
            showGameOver();
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        hideGameOver();
        hideGameWon();
    }


    void StopAndAttack()
    {
        
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetButton("Fire1") || Input.GetButton("Fire2"))
        {
            lookAtMouse();
            //navMeshAgent.isStopped = true;
            navMeshAgent.destination = navMeshAgent.transform.position;
            anim.SetBool("isShooting", true);
         
                
        }
        else
        {
            anim.SetBool("isShooting", false);
        }
    }


    void Shoot ()
    {                   
                Rigidbody arrowInstance = Instantiate(arrow, arrowPoint.transform.position, arrowPoint.transform.rotation);
                arrowInstance.velocity = transform.TransformDirection(Vector3.forward * arrowSpeed);        
    }

    void lookAtMouse()
    {
        {
            Plane playerPlane = new Plane(Vector3.up, transform.position);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0.0f;

            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);

                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

                // Smoothly rotate towards the target point.
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    public void freezeScreen()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();

        }
    }


    public void showGameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
    }

    public void hideGameOver()
    {
        gameOverPanel.gameObject.SetActive(false);
    }

    public void showGameWon()
    {
        hideGameOver();
        gameWonPanel.gameObject.SetActive(true);
       // GameObject.Find("WonScore").GetComponent<Text>().text = "Your Score: " ;
    }

    public void hideGameWon()
    {
        gameWonPanel.gameObject.SetActive(false);
    }

    public void showPaused()
    {
        pausePanel.gameObject.SetActive(true);
    }

    public void hidePaused()
    {
        pausePanel.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
