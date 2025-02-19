﻿using UnityEngine;
using UnityEngine.UI;
using KKAPI.Maker;
using System.Collections;

namespace ExpandMaleMaker {
    internal static partial class Hooks {

        internal static void EnableUnderhair() {
            //we have to wait a bit to set this on Sunshine for some reason
            ExpandMaleMaker.instance.StartCoroutine(UnderhairDelay());

            IEnumerator UnderhairDelay() {
                if (!MakerAPI.InsideAndLoaded) yield return new WaitForEndOfFrame();
                ExpandMaleMaker.logger.LogMessage("Hello from EMM");               
                GameObject bodyButton = GameObject.Find("CustomScene/CustomRoot/FrontUIGroup/CustomUIGroup/CvsMainMenu/BaseTop/tglBody");
                Toggle toggle = bodyButton.GetComponent<Toggle>();
                toggle.onValueChanged.AddListener(EnableUnderhairButton);  
                yield return null;
            }

            void EnableUnderhairButton(bool clothingPanel) {
                if (clothingPanel) {
                    GameObject element = GameObject.Find("CustomScene/CustomRoot/FrontUIGroup/CustomUIGroup/CvsMenuTree/01_BodyTop/tglUnderhair");
                    SetUnderhairDisplay(element);
                    SetUnderhairOffset(element);
                }
            }
        }

        static void SetUnderhairOffset(GameObject element) {
            element.transform.GetChild(1).position = new Vector3(113.8f, 820f, 0);
            element.transform.GetChild(1).localPosition = new Vector3(132.65f, 640.0f, 0);
        }
    }
}
