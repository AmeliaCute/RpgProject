using UnityEngine;

namespace RpgProject.FrameworkV2
{
    public class HexColor
    {
        public static Color convert(string hex)
        {
            if (ColorUtility.TryParseHtmlString("#" + hex, out Color newColor))
                return newColor;
            
            // Return a default color if parsing fails
            return Color.white;
        }
    }
}