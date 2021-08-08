Shader "CicolasShaders/pixelizeAlpha"
{
    Properties
    {
        _Tex ("Texture", 2D) = "white" {}
        [IntRange] _Factor ("Resolution", Range(8.0, 256.0)) = 0
        [Toggle] _TextureAlpha ("Use texture alpha", Float) = 0 
        [Toggle] _UseAlpha ("Use absolute alpha", Float) = 0 
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert alpha
            #pragma fragment frag alpha

            #include "UnityCG.cginc"
            #include "utils/Cicolas.cginc"

            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
                float2 texcoord : TEXCOORD0;
            };

            struct Interpolator
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
                float2 uv : TEXCOORD1;
                float2 tex : TEXCOORD2;
            };

            sampler2D _Tex;
            float4 _Tex_ST;
            float _Factor;
            float _TextureAlpha;
            float _UseAlpha;

            Interpolator vert (MeshData In)
            {
                Interpolator Out;
                Out.vertex = UnityObjectToClipPos (In.vertex);
                Out.normal = In.normal;

                Out.uv = In.uv;

                Out.tex = In.texcoord;
                return Out;
            }

            float4 frag (Interpolator In) : SV_Target
            {
                float2 uv = In.uv;
                uv = floorAll(uv, _Factor);

                float4 tex = tex2D(_Tex, uv);
                float texW = tex2D(_Tex, In.uv).w;
                float finalTexW = lerp(tex.w, texW, _TextureAlpha);
                finalTexW = lerp(finalTexW, ceil(finalTexW-.25), _UseAlpha);

                return float4(tex.xyz, finalTexW);
            }
            ENDCG
        }
    }
}
