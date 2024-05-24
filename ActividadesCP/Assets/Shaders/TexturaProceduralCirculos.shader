Shader "TexturaProcedural/Circulos"
{
	Properties
	{
		_Density("Density", Range(2,50)) = 30
		_par1("smotstep1", Range(0,1)) = 0.3
		_par2("smotstep2", Range(0,1)) = 0.32
		_par3("smotstep3", Range(0,5)) = 0.5
		_par4("smotstep4", Range(0,10)) = 5
		_par5("smotstep5", Range(0,1)) = 0.5
		_par6("smotstep6", Range(0,1)) = 0.6

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
			
			float _par1, _par2, _par3, _par4, _par5, _par6, _Density;

			v2f vert(float4 pos : POSITION, float2 uv : TEXCOORD0)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(pos);
				o.uv = uv;// * _Density;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				float2 c = i.uv;
				c = floor(c);

				float salida = _Density*smoothstep(_par1, _par2,length(frac(_par4*i.uv)-_par3));
				return salida;
			}
			ENDCG
		}
	}
}
