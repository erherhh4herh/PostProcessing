Shader "Hidden/KyleMapper"
{
	HLSLINCLUDE

	#include "../PostProcessing/Shaders/StdLib.hlsl"

	TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
	
	float a;
	float b;
	float c;
	float d;
	float e;
	float Contrast;
	float Exposure;
	float Saturation;
	
	float4 SaturationFunc (float4 col)
	{
        float greyscale = dot(col.rgb, float3(0.3f, 0.59f, 0.11f)); 
        return float4(lerp(greyscale, col.rgb, Saturation), 1);   
	}
	
	float4 Frag(VaryingsDefault i) : SV_Target
	{
		float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
		
		//return saturate(((color * (a * color + b)) / (color*(c * color + d) + e) * (color + (color - 0.5f) * (Contrast)+0.5f) * Exposure));
		return saturate(SaturationFunc(((color * (a * color + b)) / (color*(c * color + d) + e) * (color + (color - 0.5f) * (Contrast)+0.5f) * Exposure)));
	}

	ENDHLSL

	SubShader
	{
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			HLSLPROGRAM

			#pragma vertex VertDefault
			#pragma fragment Frag

			ENDHLSL
		}
	}
}