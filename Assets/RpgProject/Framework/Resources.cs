using System.Collections.Generic;
using UnityEngine;
using RpgProject.Objects;

namespace RpgProject.Framework.Resource
{
    public class ResourcesManager
    {
        public static AnimationClip CONTAINER_FADE_ANIMATION;
        public static AnimationClip BUTTON_BORDER_OVER_ANIMATION;
        public static AnimationClip BUTTON_BORDER_EXIT_ANIMATION;
        public static AnimationClip BUTTON_OVER_ANIMATION;
        public static AnimationClip BUTTON_EXIT_ANIMATION;
        public static AnimationClip BUTTON_FLOATING_OVER_ANIMATION;
        public static AnimationClip BUTTON_FLOATING_EXIT_ANIMATION;
        public static AnimationClip BUTTON_FLOATING_CLICK_ANIMATION;

        public static RuntimeAnimatorController CONTAINER_CONTROLLER;
        public static RuntimeAnimatorController BUTTON_BORDER_CONTROLLER;
        public static RuntimeAnimatorController BUTTON_CONTROLLER;
        public static RuntimeAnimatorController BUTTON_FLOATING_CONTROLLER;

        public static Sprite BUTTON_WHITE_SQUARE;
        public static Sprite BUTTON_ROUNDED_WHITE_SQUARE;
        public static Sprite BUTTON_ROUNDED_WHITE_SQUARE_BORDERED;

        public static Font COMFORTAA_BOLD;
        public static Font COMFORTAA_REGULAR;
        public static Font FONT_AWESOME_SOLID;

        public static void register()
        {
            RpgClass.LOADING_ETA = LOADING_STATE.LOADING_ASSETS;

            /* SPRITES */
            BUTTON_WHITE_SQUARE = Load<Sprite>("Sprites/WhiteSquare");
            BUTTON_ROUNDED_WHITE_SQUARE = Load<Sprite>("Sprites/RoundedWhiteSquare");
            BUTTON_ROUNDED_WHITE_SQUARE_BORDERED = Load<Sprite>("Sprites/RoundedWhiteSquareBorder");

            /* ANIMATIONS */
            CONTAINER_FADE_ANIMATION = Load<AnimationClip>("Animations/Ui/Container/FadeContainer");
            BUTTON_BORDER_OVER_ANIMATION = Load<AnimationClip>("Animations/Ui/Button/over_buttonborder");
            BUTTON_BORDER_EXIT_ANIMATION = Load<AnimationClip>("Animations/Ui/Button/exit_buttonborder");
            BUTTON_OVER_ANIMATION = Load<AnimationClip>("Animations/Ui/Button/over_button");
            BUTTON_EXIT_ANIMATION = Load<AnimationClip>("Animations/Ui/Button/exit_button");
            BUTTON_FLOATING_OVER_ANIMATION = Load<AnimationClip>("Animations/Ui/Button/over_buttonfloating");
            BUTTON_FLOATING_EXIT_ANIMATION = Load<AnimationClip>("Animations/Ui/Button/exit_buttonfloating");
            BUTTON_FLOATING_CLICK_ANIMATION = Load<AnimationClip>("Animations/Ui/Button/click_buttonfloating");

            /* ANIMATIONS CONTROLLER */
            CONTAINER_CONTROLLER = Load<RuntimeAnimatorController>("Animations/Ui/Container/Container");
            BUTTON_BORDER_CONTROLLER = Load<RuntimeAnimatorController>("Animations/Ui/Button/Buttonborder");
            BUTTON_CONTROLLER = Load<RuntimeAnimatorController>("Animations/Ui/Button/Button");
            BUTTON_FLOATING_CONTROLLER = Load<RuntimeAnimatorController>("Animations/Ui/Button/ButtonFloating");

            /* FONTS */
            COMFORTAA_BOLD = Load<Font>("Fonts/Comfortaa-Bold");
            COMFORTAA_REGULAR = Load<Font>("Fonts/Comfortaa-Regular");
            FONT_AWESOME_SOLID = Load<Font>("Fonts/fa-solid");
        }

        public static T Load<T>(string resourcePath) where T : Object
        {
            T loadedResource = Resources.Load<T>(resourcePath);

            if (loadedResource != null)
            {
                RpgClass.RPGLOGGER.Passed("The resource " + resourcePath + " has been loaded");
                return loadedResource as T;
            }
            else
                RpgClass.RPGLOGGER.Error("Failed to load resource: " + resourcePath);

            return null;
        }
    }
}