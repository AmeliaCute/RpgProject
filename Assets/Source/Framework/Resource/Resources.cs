using System.Collections.Generic;
using UnityEngine;
using RpgProject.Objects;

namespace RpgProject.Framework.Resource
{
    public class ResourcesManager
    {

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
        public static Sprite STICKERS_CG_THINKING;

        public static Font COMFORTAA_BOLD;
        public static Font COMFORTAA_REGULAR;
        public static Font FONT_AWESOME_SOLID;

        public static Mesh TESTING_SWORD_MESH;

        public static Material FONT_MATERIAL;

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
            STICKERS_CG_THINKING = Load<Sprite>("Sprites/Stickers/CG_THINKING");

            /* FONTS */
            COMFORTAA_BOLD = Load<Font>("Fonts/Comfortaa-Bold");
            COMFORTAA_REGULAR = Load<Font>("Fonts/Comfortaa-Regular");
            FONT_AWESOME_SOLID = Load<Font>("Fonts/fa-solid");

            /* MESHES */
            TESTING_SWORD_MESH = Load<Mesh>("Models/Testing/sword");

            /* MATERIAL */
            FONT_MATERIAL = Load<Material>("Fonts/FontMaterial");
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