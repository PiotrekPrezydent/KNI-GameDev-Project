using Architecture.Common;
using Architecture.UI.Configs;
using Architecture.UI.Systems;
using UnityEngine;

namespace Architecture.UI
{
    //Todo: add handling multiple popups
    static class PopupSystem
    {
        internal static AbstractPopup CurrentPopup;

        static readonly PopupConfig _config;
        
        internal static void ShowPopup(PopupType type)
        {
            InputSystem.PopupInputs.EnableInput();

            for (int i = 0; i < _config.PopupPrefabs.Length; i++)
            {
                if (_config.PopupPrefabs[i].Type != type)
                    continue;

                InstantiatePopup(_config.PopupPrefabs[i]);
                break;
            }
        }

        internal static void InstantiatePopup(AbstractPopup view)
        {
            AbstractPopup popup = Object.Instantiate(view, UIViewModel.UISceneReferencesHolder.PopupContainer.transform);
            popup.Initialize();
        }

        internal static void CloseCurrentPopup()
        {
            CurrentPopup.Close();
        }
    }
}