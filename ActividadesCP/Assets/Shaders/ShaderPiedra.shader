Shader "Custom/ShaderPiedra"
{
    Properties
    {
        _LigthPosition_w ("Ligth Position (World)", Vector) = (0, 5, 0, 1)
        _TextPiedraBase ("Piedra bases", 2D) = "white" {}
        _TextPiedraSombras ("Sombras de la piedra", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
    Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog
            
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 position_w : TEXTCOORD1;  
				float3 normal_w : TEXTCOORD0;
            };

			float4 _LigthPosition_w;
            sampler2D _TextPiedraBase;
            sampler2D _TextPiedraSombras;

            v2f vert (appdata v)
            {
                float4 position_w = mul(unity_ObjectToWorld, v.vertex);
				float3 normal_w = UnityObjectToWorldNormal(v.normal);
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.position_w = position_w;
				o.normal_w = (-1)*normal_w;
                o.uv = v.uv;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = 0;
                col = tex2D(_TextPiedraBase, i.uv) * tex2D(_TextPiedraSombras, i.uv);
                return col;
            }
            ENDCG
        }
    }
}