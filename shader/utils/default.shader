Shader ""
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolator
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            Interpolator vert (MeshData In)
            {
                Interpolator Out;
                Out.vertex = UnityObjectToClipPos(In.vertex);
                Out.uv = TRANSFORM_TEX(In.uv, _MainTex);
                return Out;
            }

            float4 frag (Interpolator In) : SV_Target
            {
                float4 col = tex2D(_MainTex, In.uv);
                return col;
            }
            ENDCG
        }
    }
}
