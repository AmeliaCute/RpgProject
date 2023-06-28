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
        public static Sprite WORLD_TALK_ICON;
        public static Sprite ITEM_DEBUG;
        public static Sprite ITEM_DEBUG_ALT;
        public static Sprite ITEM_DEBUG_SWORD;
        public static Sprite ITEM_DEBUG_SWORD_ALT;
        public static Sprite ITEM_IRON_ORE; // Implement other resources later
        public static Sprite ITEM_WOODEN_STICK;
        public static Sprite ITEM_WOODEN_SWORD;
        public static Sprite ITEM_WOODEN_WAND;
        public static Sprite ITEM_LETTER;
        public static Sprite GLOW_TEXTURE;
        public static Sprite GLOW_TEXTURE_ALT;

        public static Font COMFORTAA_BOLD;
        public static Font COMFORTAA_REGULAR;
        public static Font FONT_AWESOME_SOLID;

        public static Mesh TESTING_SWORD_MESH;

        public static void register()
        {
            RpgClass.LOADING_ETA = LOADING_STATE.LOADING_ASSETS;

            /* SPRITES */
            BUTTON_WHITE_SQUARE = Load<Sprite>("Sprites/WhiteSquare");
            BUTTON_ROUNDED_WHITE_SQUARE = Load<Sprite>("Sprites/RoundedWhiteSquare");
            BUTTON_ROUNDED_WHITE_SQUARE_BORDERED = Load<Sprite>("Sprites/RoundedWhiteSquareBorder");
            WORLD_TALK_ICON = Load<Sprite>("Sprites/World/TalkIcon");
            ITEM_DEBUG = Load<Sprite>("Sprites/Items/DEBUG_ITEM");
            ITEM_DEBUG_ALT = Load<Sprite>("Sprites/Items/DEBUG_ITEM_ALT");
            ITEM_DEBUG_SWORD = Load<Sprite>("Sprites/Items/DEBUG_SWORD");
            ITEM_DEBUG_SWORD_ALT = Load<Sprite>("Sprites/Items/DEBUG_SWORD_ALT");
            ITEM_IRON_ORE = Load<Sprite>("Sprites/Items/IRON_ORE");
            ITEM_WOODEN_STICK = Load<Sprite>("Sprites/Items/WOODEN_STICK");
            ITEM_WOODEN_SWORD = Load<Sprite>("Sprites/Items/WOODEN_SWORD");
            ITEM_WOODEN_WAND = Load<Sprite>("Sprites/Items/WOODEN_WAND");
            ITEM_LETTER = Load<Sprite>("Sprites/Items/LETTER");
            GLOW_TEXTURE = Load<Sprite>("Sprites/Hud/GLOW");
            GLOW_TEXTURE_ALT = Load<Sprite>("Sprites/Hud/GLOW_ALT");

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

            /* MESHES */
            TESTING_SWORD_MESH = Load<Mesh>("Models/Testing/sword");
        }

        public static T Load<T>(string resourcePath) where T : Object
        {
            T loadedResource = Resources.Load<T>(resourcePath);

            if (loadedResource != null)
            {
                RpgClass.LOGGER.Passed("The resource " + resourcePath + " has been loaded");
                return loadedResource as T;
            }
            else
                RpgClass.LOGGER.Error("Failed to load resource: " + resourcePath);

            return null;
        }
    }
}