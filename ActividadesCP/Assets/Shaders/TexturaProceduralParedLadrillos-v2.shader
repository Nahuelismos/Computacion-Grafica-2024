Shader "TexturaProcedural/TexturaProceduralParedLadrillos-v2"
{
	Properties
	{
		_ColorBase  ("Color Base", Color) = (0,0,0,0) 
		_ColorBordes ("Color Bordes", Color) = (0,0,0,0)
		_ColorBrillo ("Color Brillo", Color) = (0,0,0,0)
		_Density("Density", Range(2,50)) = 30
		_cantX("cant de divisiones en x", Range(2,50)) = 10
		_cantY("cant de divisiones en y", Range(2,50)) = 10
		_par1("smotstep1", Range(0,2)) = 0.4
		_par2("smotstep2", Range(0,2)) = 0.5
		_par3("smotstep3", Range(0,1)) = 0.4
		_par4("smotstep4", Range(0,1)) = 0.5
		_desplazamiento1("desplazamiento en el absoluto parte1", Range(0,1)) = 0.5
		_desplazamiento2("desplazamiento en el absoluto parte2", Range(0,1)) = 0.5
		_desplazamiento3("desplazamiento en el absoluto parte3", Range(0,1)) = 0.5

	}
		SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};
			float4 _ColorBase,_ColorBordes, _ColorBrillo;
			float _Density, _cantX, _cantY;
			float _par1, _par2,_par3, _par4, _desplazamiento1, _desplazamiento2, _desplazamiento3;

			v2f vert(float4 pos : POSITION, float2 uv : TEXCOORD0)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(pos);
				o.uv = uv * _Density;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				float2 c = i.uv;
				c = floor(c);
				//float checker = frac((floor(_cantX*c.x)+floor(_cantY*c.y))/2)*_Density; //<-- Pared de bloques
				float pos1 = abs( frac(_cantX*i.uv.x - _desplazamiento1* (floor(_cantY*i.uv.y)/ _Density)) - _desplazamiento2);
				float pos2 = abs( frac(_cantY*i.uv.y) - _desplazamiento3);
				float variacion = max(pos1,pos2);
				float checker = smoothstep(_par1, _par2, variacion);
				if(checker == 0){ 
					return _ColorBase;
				}else{
					return lerp(_ColorBase,_ColorBordes,checker);
				}
				//return lerp(col,_ColorBordes,checker);
			}
			ENDCG
		}
	}
}
