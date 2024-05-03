Shader "Lighting/diffused"{
	Properties{
		_MaterialColor ("Material Color",Color)=(0.25,0.5,0.5,1)
		_LigthPosition_w ("Ligth Position (World)", Vector) = (0, 5, 0, 1)
	}

	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 100
		
		Pass {
			CGPROGRAM
		
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			struct vertexData {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				float3 diffCoef : TEXTCOORD0;  
			};

			float4 _MaterialColor;
			float4 _LigthPosition_w;
			
			v2f vert(vertexData v)
			{
				float4 position_w = mul(unity_ObjectToWorld, v.vertex);
				float3 normal_w = normalize(UnityObjectToWorldNormal(v.normal));
				float3 L = normalize(_LigthPosition_w.xyz - position_w.xyz);
				float3 N = normal_w;
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.diffCoef = max(0, dot(N, L));
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 fragColor = 0;
				fragColor.rgb = i.diffCoef*_MaterialColor;
				return fragColor;
			}
			ENDCG
		}
	}
}