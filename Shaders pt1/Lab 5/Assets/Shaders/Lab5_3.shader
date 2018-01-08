// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//Lab_5 Part3
Shader "Cg shader with all built-in vertex input parameters" {
	SubShader{
		Pass{
		CGPROGRAM

#pragma vertex vert  
#pragma fragment frag 
#include "UnityCG.cginc"

		struct vertexOutput {
		float4 pos : SV_POSITION;
		float4 col : TEXCOORD0;
	};

	vertexOutput vert(appdata_full input)
	{
		vertexOutput output;

		output.pos = UnityObjectToClipPos(input.vertex);
		//output.col = input.texcoord - float4(1.5, 2.3, 1.1, 0.0); Turns black because the ranges are not between 0 - 1
		//output.col = input.texcoord.zzzz; The z co-ordinate i always 0
		//output.col = input.texcoord / tan(0.0); Devide by 0 error
		//output.col = dot(input.normal, input.tangent.xyz) * input.texcoord; tangent to a normal is a 90 degree angle which will lead to a 0
		//output.col = dot(cross(input.normal, input.tangent.xyz),input.normal) * input.texcoord; the dot and cross product cancel each other out
		//output.col = float4(cross(input.normal, input.normal), 1.0); There is no fourth number in the float4
		//output.col = float4(cross(input.normal, input.vertex.xyz), 1.0); //This only works for a sphere because the radius is the same length from the vertex the whole way around,
		//on a cube the corners arent black
		//output.col = radians(input.texcoord); This turns black because it wont always be 0, for the texcoord

		return output;
	}

	float4 frag(vertexOutput input) : COLOR
	{
		return input.col;
	}

		ENDCG
	}
	}
}