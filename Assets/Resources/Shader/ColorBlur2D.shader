Shader "Custom/BackgroundBlurPostProcess"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _BlurSize ("Blur Size", Range(0, 10)) = 1
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0
            
            #include "UnityCG.cginc"
            
            struct appdata_t
            {
                float4 vertex   : POSITION;
                float2 uv       : TEXCOORD0;
            };
            
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            sampler2D _MainTex;
            float _BlurSize;
            
            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            half4 frag(v2f i) : SV_Target
            {
                float2 blurDir = _BlurSize * _ScreenParams.xy;
                half4 col = half4(0, 0, 0, 0);
                
                // Sample surrounding pixels and accumulate color
                for (int x = -3; x <= 3; x++)
                {
                    for (int y = -3; y <= 3; y++)
                    {
                        col += tex2D(_MainTex, i.uv + float2(x, y) * blurDir);
                    }
                }
                
                // Average the color
                col /= 49; // Number of samples
                return col;
            }
            ENDCG
        }
    }
    FallBack "Hidden/ScreenSpaceBlurred"
}