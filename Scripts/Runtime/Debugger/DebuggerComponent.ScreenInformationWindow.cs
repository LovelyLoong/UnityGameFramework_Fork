﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public sealed partial class DebuggerComponent : GameFrameworkComponent
    {
        private sealed class ScreenInformationWindow : ScrollableDebuggerWindowBase
        {
            protected override void OnDrawScrollableWindow()
            {
                GUILayout.Label("<b>Screen Information</b>");
                GUILayout.BeginVertical("box");
                {
                    DrawItem("Current Resolution", GetResolutionString(Screen.currentResolution));
                    DrawItem("Screen Width", Utility.Text.Format("{0} px / {1:F2} in / {2:F2} cm", Screen.width, Utility.Converter.GetInchesFromPixels(Screen.width), Utility.Converter.GetCentimetersFromPixels(Screen.width)));
                    DrawItem("Screen Height", Utility.Text.Format("{0} px / {1:F2} in / {2:F2} cm", Screen.height, Utility.Converter.GetInchesFromPixels(Screen.height), Utility.Converter.GetCentimetersFromPixels(Screen.height)));
                    DrawItem("Screen DPI", Screen.dpi.ToString("F2"));
                    DrawItem("Screen Orientation", Screen.orientation.ToString());
                    DrawItem("Is Full Screen", Screen.fullScreen.ToString());
#if UNITY_2018_1_OR_NEWER
                    DrawItem("Full Screen Mode", Screen.fullScreenMode.ToString());
#endif
                    DrawItem("Sleep Timeout", GetSleepTimeoutDescription(Screen.sleepTimeout));
#if UNITY_2019_2_OR_NEWER
                    DrawItem("Brightness", Screen.brightness.ToString("F2"));
#endif
                    DrawItem("Cursor Visible", Cursor.visible.ToString());
                    DrawItem("Cursor Lock State", Cursor.lockState.ToString());
                    DrawItem("Auto Landscape Left", Screen.autorotateToLandscapeLeft.ToString());
                    DrawItem("Auto Landscape Right", Screen.autorotateToLandscapeRight.ToString());
                    DrawItem("Auto Portrait", Screen.autorotateToPortrait.ToString());
                    DrawItem("Auto Portrait Upside Down", Screen.autorotateToPortraitUpsideDown.ToString());
#if UNITY_2017_2_OR_NEWER && !UNITY_2017_2_0
                    DrawItem("Safe Area", Screen.safeArea.ToString());
#endif
#if UNITY_2019_2_OR_NEWER
                    DrawItem("Cutouts", GetCutoutsString(Screen.cutouts));
#endif
                    DrawItem("Support Resolutions", GetResolutionsString(Screen.resolutions));
                }
                GUILayout.EndVertical();
            }

            private string GetSleepTimeoutDescription(int sleepTimeout)
            {
                if (sleepTimeout == SleepTimeout.NeverSleep)
                {
                    return "Never Sleep";
                }

                if (sleepTimeout == SleepTimeout.SystemSetting)
                {
                    return "System Setting";
                }

                return sleepTimeout.ToString();
            }

            private string GetResolutionString(Resolution resolution)
            {
                // return Utility.Text.Format("{0} x {1} @ {2}Hz", resolution.width, resolution.height, resolution.refreshRate);
                return Utility.Text.Format("{0} x {1} @ {2}Hz", resolution.width, resolution.height, resolution.refreshRateRatio);
            }

            private string GetCutoutsString(Rect[] cutouts)
            {
                string[] cutoutStrings = new string[cutouts.Length];
                for (int i = 0; i < cutouts.Length; i++)
                {
                    cutoutStrings[i] = cutouts[i].ToString();
                }

                return string.Join("; ", cutoutStrings);
            }

            private string GetResolutionsString(Resolution[] resolutions)
            {
                string[] resolutionStrings = new string[resolutions.Length];
                for (int i = 0; i < resolutions.Length; i++)
                {
                    resolutionStrings[i] = GetResolutionString(resolutions[i]);
                }

                return string.Join("; ", resolutionStrings);
            }
        }
    }
}
