Shader "CicolasShaders/Rainbow"
{
    Properties
    {
        _Color1 ("color 1", Color) = (0, 0, 0, 1)

        [Space(20)]
        _ValueX ("Scale", Float) = 0
        _ValueY (" ", Float) = 0

        [Space(20)]
        [IntRange]_Value1 ("Amplitude", Range(20.0, 100.0)) = 0
        _Value2 ("Time scale", Float) = 0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        ZWrite Off
        Cull Off

        Pass
        {
            Blend One One

            CGPROGRAM
            #pragma vertex vert alpha
            #pragma fragment frag alpha

            #define TAU 6.28
            #include "UnityCG.cginc"
            #include "utils/Cicolas.cginc"

            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct Interpolator
            {
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            float4 _Color1;
            float4 _Color2;
            float _ValueX;
            float _ValueY;

            float _Value1;
            float _Value2;

            Interpolator vert (MeshData In)
            {
                Interpolator Out;
                Out.vertex = UnityObjectToClipPos(In.vertex);
                Out.uv = In.uv;
                Out.normal = In.normal;
                return Out;
            }

            float4 frag (Interpolator In) : SV_Target
            {
                _Value1 = (1-((_Value1-20)/80))*80+20;
                float2 uv = In.uv;
                uv *= float2(_ValueX, _ValueY);
            
                float offset = (cos(uv.x * TAU + _Time*_Value2*50)+1)/_Value1*_ValueY;
                float v = (sin((uv.y+offset) * TAU * 5)+1)/2;

                return _Color1 * clamp(v*(1-In.uv.y), 0, 1) * (abs(In.normal.y)<0.999);
                //return float4(uv, 0, 1);
                //return c;
            }
            ENDCG
        }
    }
}
