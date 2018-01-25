using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AppState
{
    LOADING,
    CONFIRMATION,
    RESULTS
}

public class Slides : MonoBehaviour
{
    [SerializeField] float time_until_confirmation = 1.0f;
    [SerializeField] RectTransform load_screen;
    [SerializeField] RectTransform call_screen;
    [SerializeField] RectTransform slider_screen;


    AppState state = AppState.LOADING;


    void Start()
    {
        StartCoroutine(TransitionToConfirmation());
    }


    void Update()
    {
        switch (state)
        {
            case AppState.LOADING:
            {

            } break;

            case AppState.CONFIRMATION:
            {

            } break;

            case AppState.RESULTS:
            {

            } break;
        }
    }


    IEnumerator TransitionToConfirmation()
    {
        yield return new WaitForSeconds(time_until_confirmation);

        // Hide loading screen stuff.

        state = AppState.CONFIRMATION;

        // Show confirmation screen stuff.
    }


    IEnumerator TransitionToResults()
    {

        yield break;
    }


    void LoadingState()
    {
        // Rotate the loading icon or something ?
    }


    void ConfirmationState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Change sprite: Push accept button down.
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Change sprite: Lift accept button up.

            StartCoroutine(TransitionToResults());
        }
    }


    void ResultsState()
    {
        // Something ..
    }

}
