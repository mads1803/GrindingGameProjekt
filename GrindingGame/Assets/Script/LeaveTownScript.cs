using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class LeaveTownScript : MonoBehaviour {
    public Transform other;
    public string SceneToLoad;
 

    private void OnMouseDown()
    {
        
        float dist = Vector3.Distance(other.position, transform.position);
        if (dist < 10)
        {
            Debug.Log("Portalen er trykket");
            //SceneManager.UnloadScene("DesertScene");
            SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
            
        }
       
    }

    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();

    }
    void OnMouseEnter()
    {
        rend.material.color = Color.white;
    }
    void OnMouseOver()
    {
        rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    }
    void OnMouseExit()
    {
        rend.material.color = Color.grey;
    }
}
