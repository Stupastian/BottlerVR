using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ResetScene : MonoBehaviour
{
    public bool pointerEnter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SceneReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PointerEnter()
    {
        pointerEnter = true;
        Debug.Log("Pointer Enter Reset Button");
    }

    public void PointerExit()
    {
        pointerEnter = false;
        Debug.Log("Pointer Exit Reset Button");
    }

    // Update is called once per frame
    void Update()
    {
        // Resetin voi tehdä myös R näppäimellä eli tätä voi testata ilman ohjaimia
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneReset();
        }
        // Tässä käytetään ohjainta, laitoin ensin tähän pelkästään tuon funktiokutsun, mutta sittemmin siirsin sen tuonne eventtien puolelle. Sillä tätä voi käyttää muihinkin nappeihin.
        if (pointerEnter && Input.GetButton("Fire3"))
        {
            ExecuteEvents.Execute(this.gameObject.transform.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
            //SceneReset();
        }
    }
}
