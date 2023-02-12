using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int PrEP = 0;
    public GameObject popQuestion;
    public GameObject button;
    public GameObject wrongButton;

    public GameObject flag;
    public AudioSource audioPlayer;
    
    [SerializeField] public Text prepText;
    [SerializeField] public GameObject correctResponse;
    [SerializeField] public GameObject wrongResponse;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("prep"))
        {
            audioPlayer.Play();
            Destroy(collision.gameObject);
            PrEP++;
            prepText.text = "PrEP collected: " + PrEP;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Pop();
        }
    }


    private void Pop()
    {
        popQuestion.SetActive(true);
    }

    public void correctAnswer()
    {
        flag.SetActive(false);
        PrEP++;
        bingo();
        prepText.text = "PrEP collected: " + PrEP;
    }

    public void wrongAnswer()
    {
        flag.SetActive(false);
        PrEP -= 1;
        wrong();
        prepText.text = "PrEP collected: " + PrEP;
    }
    
    void bingo()
    {
        correctResponse.SetActive(true);
        Invoke("correctHide",2f);
    }

    void correctHide()
    {
        correctResponse.SetActive(false);
    }

    void wrong()
    {
        wrongResponse.SetActive(true);
        Invoke("wrongHide",2f);
    }

    void wrongHide()
    {
        wrongResponse.SetActive(false);
    }
}
