using UnityEngine;
using UnityEngine.UI;
     
namespace RpgProject.FrameworkV2.Generator
{   

    //!!! Could be simplified
    public class RoundedTexture : MonoBehaviour
    {
        public int borderRadius;
        public Color color;
        
        RectTransform rt;
        Texture2D tex;
        
        Rect innerRect;
        Rect xSpanRect;
        Rect ySpanRect;
        
        Vector2 center;
        
        float width;
        float height;
        
        Vector2 innerTL;
        Vector2 innerTR;
        Vector2 innerBL;
        Vector2 innerBR;

        public void Generate()
        {
            rt = GetComponent<RectTransform>();
            width = rt.sizeDelta.x * rt.localScale.x;
            height = rt.sizeDelta.y * rt.localScale.y;

            RawImage rawImage = GetComponent<RawImage>();
            //tex = (Texture2D)(rawImage.texture != null ? rawImage.texture :  new Texture2D(Mathf.RoundToInt(width), Mathf.RoundToInt(height)));

            tex = new Texture2D(Mathf.RoundToInt(width), Mathf.RoundToInt(height));
            tex.filterMode = FilterMode.Point;
            tex.Apply();
            rawImage.texture = tex;

            center = new Vector2(width * 0.5f, height * 0.5f);
            innerRect = new Rect(width * 0.5f, height * 0.5f, width - (borderRadius * 2), height - (borderRadius * 2));
       
            innerTL = new Vector2((-(width * 0.5f)) + borderRadius, (height * 0.5f) - borderRadius);
            innerTR = new Vector2(((width * 0.5f)) - borderRadius, (height * 0.5f) - borderRadius);
            innerBL = new Vector2((-(width * 0.5f)) + borderRadius, -(height * 0.5f) + borderRadius);
            innerBR = new Vector2(((width * 0.5f)) - borderRadius, -(height * 0.5f) + borderRadius);
    
            innerRect.position = new Vector2(borderRadius, borderRadius);
            innerRect.width = width - (borderRadius * 2);
            innerRect.height = height - (borderRadius * 2);
    
            xSpanRect = new Rect(0, borderRadius, width, innerRect.height);
            ySpanRect = new Rect(borderRadius, 0, innerRect.width, height);
    
            for (int x = 0; x < tex.width; x++) {
                for (int y = 0; y < tex.height; y++) {
                        Vector2 pos = new Vector2((x + 0.5f) - (width * 0.5f), (y + 0.5f) - (height * 0.5f));

                    if(Vector2.Distance(pos, innerTL) <= borderRadius || Vector2.Distance(pos, innerTR) <= borderRadius || Vector2.Distance(pos, innerBL) <= borderRadius || Vector2.Distance(pos, innerBR) <= borderRadius){
                        tex.SetPixel(x, y, color);
                    }else{
                        tex.SetPixel(x, y, Color.clear);
                    }
                    if(xSpanRect.Contains(new Vector2(x, y)) || ySpanRect.Contains(new Vector2(x, y))){
                        tex.SetPixel(x, y, color);
                    }
                }
            }
            tex.Apply();
        }
    }
}
