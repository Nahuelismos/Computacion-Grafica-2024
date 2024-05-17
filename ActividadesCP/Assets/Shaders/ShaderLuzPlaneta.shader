Shader "Custom/ShaderLuzPlaneta"
{
    Properties
    {
        _LigthPosition_w ("Ligth Position (World)", Vector) = (0, 5, 0, 1)
        _TextTierraDia ("Tierra de Dia", 2D) = "white" {}
        _TextTierraNoche ("Tierra de Noche", 2D) = "white" {}
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
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 position_w : TEXTCOORD1;  
				float3 normal_w : TEXTCOORD0;
            };

			float4 _LigthPosition_w;
            sampler2D _TextTierraDia;
            sampler2D _TextTierraNoche;
            float4 _TextTierraDia_ST;
            float4 _TextTierraNoche_ST;

            v2f vert (appdata v)
            {
                float4 position_w = mul(unity_ObjectToWorld, v.vertex);
				float3 normal_w = UnityObjectToWorldNormal(v.normal);
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.position_w = position_w;
				o.normal_w = normal_w;
                o.uv = v.uv;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                float3 N = normalize(i.normal_w);
                float3 L = normalize(_LigthPosition_w.xyz - i.position_w.xyz);
                // sample the texture
                
                fixed4 col = tex2D(_TextTierraDia, i.uv);
                if(cos(dot(N,L)) < 0) {  
                   col = tex2D(_TextTierraNoche, i.uv);
                }
                return col;
            }
            ENDCG
        }
    }
}