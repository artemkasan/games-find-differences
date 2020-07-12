Shader "Custom/Highlight"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_ShadowShift("ShadowShift", Float) = 0
		_Offeset("Offset", Vector) = ( 0, 0, 0, 0 )
	}
	SubShader
	{
		Tags
		{
			"Queue"="Transparent"
			"IgnoreProjector"="True"
			"RenderType"="Transparent"
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}
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
			float _ShadowShift;
			float4 _Offeset;

			float4 fragmentShader(vertexOutput i) : COLOR
			{
				float2 texCoord = {
					i.texcoord.x - _Offeset.x,
					i.texcoord.y - _Offeset.y
				};

				float4 fg = tex2D(_MainTex, 
				UnityStereoScreenSpaceUVAdjust(
				texCoord, _MainTex_ST));

				float2 shadowTexCoord = {
					i.texcoord.x - _ShadowShift,
					i.texcoord.y + _ShadowShift
				};

				float4 colorBack = tex2D(_MainTex, 
				UnityStereoScreenSpaceUVAdjust(
				shadowTexCoord, _MainTex_ST));
				if(colorBack.w == 0)
				{
					return fg;
				}
				float bg = 0.299 * colorBack.x
				+ 0.587 * colorBack.y
				+ 0.114 * colorBack.z;
				float rA = 1 - (1 - fg.w) * (1 - colorBack.w);
				if (rA < 1.0e-6) {
					return rA; // Fully transparent -- R,G,B not important
				}

				float4 result = { 
					fg.x * fg.w / rA + bg * colorBack.w * (1 - fg.w) / rA,
					fg.y * fg.w / rA + bg * colorBack.w * (1 - fg.w) / rA,
					fg.z * fg.w / rA + bg * colorBack.w * (1 - fg.w) / rA,
					rA
				};
				return result;
			}
			ENDCG
		}
	}
}
