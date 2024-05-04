Shader "Lighting/diffusedFrag(spot)"{
	Properties{
		_LigthPosition_w ("Ligth Position (World)", Vector) = (0, 5, 0, 1)
		_DirLPosition_w ("Direction Position Ligth (Word)", Vector) = (0, -5 , 0 ,1)
		_Spot_Angle ("Angle", float) = 30
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
				float4 position_w : TEXTCOORD1;  
				float3 normal_w : TEXTCOORD0;
			};

			float4 _LigthPosition_w;
			float4 _DirLPosition_w;
			float _Spot_Angle;
			
			v2f vert(vertexData v)
			{
				float4 position_w = mul(unity_ObjectToWorld, v.vertex);
				float3 normal_w = normalize(UnityObjectToWorldNormal(v.normal));
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.position_w = position_w;
				o.normal_w = normal_w;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 fragColor = 0;
				float3 L = normalize(_LigthPosition_w.xyz - i.position_w.xyz);
				float3 N = normalize(i.normal_w);
				float diffCoef = max(0, dot(N, L));
				//if(acos(dot(-_DirLPosition_w,L))<(_Spot_Angle*3.14/180))
				if(dot(-_DirLPosition_w,L) > cos(_Spot_Angle))	
					fragColor.rgb = diffCoef;
				return fragColor;
			}
			ENDCG
		}
	}
}