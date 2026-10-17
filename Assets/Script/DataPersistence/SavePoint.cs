using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveingPole : MonoBehaviour
{
    [SerializeField]
    private GameObject canvaHint;
    private bool PlayerEnter;
    private bool able; //NEVER MODIFY IN EDITOR 
    private Animator saveAnimator;
    private IEnumerator coroutine;

    void Awake()
    {
        this.saveAnimator = this.GetComponent<Animator>();
        this.PlayerEnter = false;
        this.able = true;
        this.coroutine = successSave();
    }
    private void Update(){
        if (Input.GetKeyDown(KeyCode.E) && PlayerEnter && able){
            DataPersistenceManager.instance.SaveGame();    
            this.coroutine = successSave(); // Make Sure assing your courutine every execute !!!!!!
            this.saveAnimator.Play("savepoint");
            if(canvaHint.transform.Find("HintTxt") != null && canvaHint.transform.Find("SuccessTxt") != null){
                canvaHint.transform.Find("HintTxt").gameObject.SetActive(false);
                canvaHint.transform.Find("SuccessTxt").gameObject.SetActive(true);
            }
            else{
                Debug.LogWarning("SCENE NEED HintTxt and SuccesTxt object");
            }
            StartCoroutine(coroutine);
            Debug.Log("Success save");
        }

    }
    IEnumerator successSave(){
        able = false;
         // suspend execution for 1 seconds
        yield return new WaitForSeconds(1f);
        canvaHint.transform.Find("SuccessTxt").gameObject.SetActive(false);
        able = true;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        this.PlayerEnter = true;
        if(col.CompareTag("Player"))
            canvaHint.transform.Find("HintTxt").gameObject.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D col)
    {
        this.PlayerEnter = false;
        if(col.CompareTag("Player"))
            canvaHint.transform.Find("HintTxt").gameObject.SetActive(false);
    }
}
