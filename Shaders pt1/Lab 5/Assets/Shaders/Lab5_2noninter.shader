//Lab_5 Part2
//Shaders name that will show in unity
Shader "Custom/Lab5_2noninter" {
	SubShader{
		Pass{
		CGPROGRAM

#pragma vertex vert
#pragma fragment frag 

		struct vertexOutput {
		float4 pos : SV_POSITION;  // Position in projection space
		nointerpolation float4 col : TEXCOORD0; // First texture co-ordinate in UV, (non-interpolation)
		};

	//	struct vertexOutput {
	//	float4 pos : SV_POSITION; // Position in projection space
	//	float4 col : TEXCOORD0;   // First texture co-ordinate in UV
	//};

	// Vertex Shader
	vertexOutput vert(float4 vertexPos : POSITION)
	{
		vertexOutput output; //output variable

		output.pos = UnityObjectToClipPos(vertexPos);
		output.col = vertexPos + float4(0.5, 0.5, 0.5, 0.0);
		return output;
	}

	// Fragment shader
	float4 frag(vertexOutput input) : COLOR
	{
		return input.col;
	}

		ENDCG
	}
	}
}