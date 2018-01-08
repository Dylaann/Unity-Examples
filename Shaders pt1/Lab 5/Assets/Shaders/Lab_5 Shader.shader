//Lab_5 Part1
//Shaders name that will show in unity
Shader "Custom/Lab_5 Shader" {
  SubShader {
      Pass {
         CGPROGRAM
         #pragma vertex vert 
        #pragma fragment frag

            // vertex shader changes the position of the attached shaders object
         float4 vert(float4 vertexPos : POSITION) : SV_POSITION 
         {
            return UnityObjectToClipPos(float4(1.0, 0.1, 1.0, 1.0) * vertexPos); //flatttens object
         }

         // fragment shader, changes colour of the shader
         float4 frag(void) : COLOR
         {
            return float4(0.6, 0.0, 1.0, 1.0); 
               // (red = 0.6, green = 0.0, blue = 1.0, alpha = 1.0)
        }
         ENDCG
      }
   }
}
