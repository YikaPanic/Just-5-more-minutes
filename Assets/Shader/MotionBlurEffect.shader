Shader "Custom/SpriteMotionBlur"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _BlurAmount ("Blur Amount", Range(0, 5)) = 2.5
        _BlurDirection ("Blur Direction", Vector) = (1, 0, 0, 0)
        _Color ("Tint", Color) = (1, 1, 1, 1)
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "RenderType" = "Transparent"
        }
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                fixed4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                fixed4 color : COLOR;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _BlurAmount;
            float2 _BlurDirection;
            fixed4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color * _Color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) * i.color;
                col += tex2D(_MainTex, i.uv + _BlurDirection * _BlurAmount * 0.002) * i.color;
                col += tex2D(_MainTex, i.uv - _BlurDirection * _BlurAmount * 0.002) * i.color;
                col /= 3;
                return col;
            }
            ENDCG
        }
    }
}
