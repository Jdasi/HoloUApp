﻿using System.Collections;
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
    [SerializeField] float slide_speed = 1;
    [SerializeField] RectTransform load_screen;
    [SerializeField] RectTransform call_screen;
    [SerializeField] RectTransform slider_screen;
    [SerializeField] RectTransform screen_group;

    [SerializeField] GameObject accept_button_up;
    [SerializeField] GameObject accept_button_dn;

    AppState state = AppState.LOADING;

    bool sliding;
    float height;
    float target_y;
    Vector2 original_pos;


    void Start()
    {
        target_y = load_screen.localPosition.y + height;
        original_pos = screen_group.localPosition;
        load_screen.gameObject.SetActive(true);
        StartCoroutine(TransitionToConfirmation());
    }


    void Update()
    {
        switch (state)
        {
            case AppState.LOADING:
            {
                LoadingState();
            } break;

            case AppState.CONFIRMATION:
            {
                ConfirmationState();
                if (sliding)
                {
                    screen_group.localPosition = Vector2.Lerp(screen_group.localPosition,
                        new Vector2(0, Screen.height), Time.deltaTime * slide_speed);
                }
            } break;

            case AppState.RESULTS:
            {
                ResultsState();
            } break;
        }
    }


    IEnumerator TransitionToConfirmation()
    {
        yield return new WaitForSeconds(time_until_confirmation);

        load_screen.gameObject.SetActive(false);
        call_screen.gameObject.SetActive(true);

        state = AppState.CONFIRMATION;
    }


    IEnumerator TransitionToResults()
    {
        sliding = true;
        yield return new WaitUntil(() => target_y - screen_group.localPosition.y  >= 0.5f);
        sliding = false;
        state = AppState.RESULTS;
    }


    void LoadingState()
    {
        // Rotate the loading icon or something ?
    }


    void ConfirmationState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            accept_button_up.SetActive(false);
            accept_button_dn.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            accept_button_up.SetActive(true);
            accept_button_dn.SetActive(false);

            StartCoroutine(TransitionToResults());
        }
    }


    void ResultsState()
    {
        // Something ..
    }

}
