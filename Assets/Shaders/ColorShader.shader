Shader "Custom/ColorShader"
{
	Properties
	{
		_MainTex ("Source", 2D) = "white" {}
		_Red ("Red", Vector) = (1, 0, 0, 1)
		_Green("Green", Vector) = (0, 1, 0, 1)
		_Blue("Blue", Vector) = (0, 0, 1, 1)
		_Color ("Tint", Color) = (1, 1, 1, 1)
	}
	SubShader
	{
		Pass
		{
			ZTest Always
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Back

			CGPROGRAM
			#pragma vertex vertexShader
			#pragma fragment fragmentShader
			
			#include "UnityCG.cginc"

			struct vertexInput
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct vertexOutput
			{
				float2 texcoord : TEXCOORD0;
				float4 position : SV_POSITION;
			};

			vertexOutput vertexShader(vertexInput i)
			{
				vertexOutput o;
				o.position = UnityObjectToClipPos(i.vertex);
				o.texcoord = i.texcoord;
				return o;
			}
			
			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Red;
			float4 _Green;
			float4 _Blue;

			float4 fragmentShader(vertexOutput i) : COLOR
			{
				float4 color = tex2D(_MainTex, 
				UnityStereoScreenSpaceUVAdjust(
				i.texcoord, _MainTex_ST));
				if (color.w == 0 )
				{
					return color;
				}

				float4 result = {
					_Red.x * color.x + _Red.y * color.y + _Red.z * color.z,
					_Green.x * color.x + _Green.y * color.y + _Green.z * color.z,
					_Blue.x * color.x + _Blue.y * color.y + _Blue.z * color.z,
				color.w };

				return result;
			}
			ENDCG
		}
	}
}
