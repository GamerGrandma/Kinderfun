using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   /* [SerializeField] private Animation _mainMenuAnimator;
    [SerializeField] private AnimationClip _fadeOutAnimation;
    [SerializeField] private AnimationClip _fadeInAnimation;
    public void OnFadeOutComplete()
    {
        Debug.LogWarning("FadeOut Complete");
    }
    public void OnFadeInComplete()
    {
        Debug.LogWarning("FadeIn Complete");
    }*/
    public void FadeIn()
   {
        UIManager.Instance.SetDummyCameraActive(true);
    //    _mainMenuAnimator.Stop();
    //    _mainMenuAnimator.clip = fadeInAnimation;
    //    _mainMenuAnimator.Play();
    }
    public void FadeOut()
    {
        UIManager.Instance.SetDummyCameraActive(false);
     //   mainMenuAnimator.Stop();
     //   _mainMenuAnimator.clip = fadeOutAnimation;
      //  _mainMenuAnimator.Play();
    }
}
