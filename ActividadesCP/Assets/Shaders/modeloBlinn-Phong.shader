Shader "Lighting/Modelo Phong"{
	Properties{
		_LigthPosition_w ("Ligth Position (World)", Vector) = (0, 5, 0, 1)
		_LigthIntensity ("LigthIntensity", Color) = (1, 1, 1, 1)
		_AmbientLigth("AmbientLigth", Color) = (1, 1, 1, 1)

		_MateriaKa("MaterialKa", Vector) = (0, 0, 0, 0)
		_MateriaKd("MaterialKd", Vector) = (0, 0, 0, 0)
		_MateriaKs("MaterialKs", Vector) = (0, 0, 0, 0)
		_Material_n("Material_n",float) = 0.5
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
			float4 _LigthIntensity;
			float4 _AmbientLigth;
			float4 _MateriaKa;
			float4 _MateriaKd;
			float4 _MateriaKs;
			float _Material_n;
			
			v2f vert(vertexData v)
			{
				float4 position_w = mul(unity_ObjectToWorld, v.vertex);
				float3 normal_w = UnityObjectToWorldNormal(v.normal);
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.position_w = position_w;
				o.normal_w = normal_w;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target {	
				fixed4 fragColor = 0;
				float3 L = normalize(_LigthPosition_w.xyz - i.position_w.xyz);
				float3 N = normalize(i.normal_w);
				float3 R = reflect(-L,N);
				float3 V = normalize(_WorldSpaceCameraPos-i.position_w.xyz);
				//float3 V = normalize(pot(mul(V,R)));
				float3 Iambient = _AmbientLigth * _MateriaKa;
				float3 Idiffuse = _LigthIntensity.xyz * _MateriaKd.xyz * max(0,dot(L,N));
				float3 Ispecular = _LigthIntensity.xyz * _MateriaKs.xyz * pow(max(0,dot(R,V)),_Material_n);
				fragColor.rgb = Iambient + Idiffuse + Ispecular;
				//fragColor.rgb = Ispecular;
				return fragColor;
			}
			ENDCG
		}
	}
}