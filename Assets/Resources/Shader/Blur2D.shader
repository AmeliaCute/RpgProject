Shader "Custom/Blur2D"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurRadius ("Blur Radius", Range(0.1, 1000.0)) = 1.0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "GaussianBlur.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _BlurRadius;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                pixel_info pinfo;
                pinfo.tex = _MainTex;
                pinfo.uv = i.uv;
                pinfo.texelSize = float4(1.0 / _ScreenParams.xy, 0.0, 0.0); // Changed from float2 to float4

                float4 origColor = tex2D(_MainTex, i.uv); // Original image color with alpha
                float4 blurredColor = GaussianBlur(pinfo, _BlurRadius, float2(1.0, 0.0)); // Blur horizontally
                blurredColor = GaussianBlur(pinfo, _BlurRadius, float2(0.0, 1.0)); // Blur vertically

                // Blend blurred color with original color based on original alpha
                float4 finalColor = lerp(origColor, blurredColor, origColor.a);

                return finalColor;
            }


            ENDCG
        }
    }
}
