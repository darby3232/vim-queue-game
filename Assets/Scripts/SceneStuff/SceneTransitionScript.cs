using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionScript : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(RunFirst());
    }

    IEnumerator RunFirst()
    {

        anim.SetTrigger("NewLevel");
        //Play animation first, then load
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

    }

}
