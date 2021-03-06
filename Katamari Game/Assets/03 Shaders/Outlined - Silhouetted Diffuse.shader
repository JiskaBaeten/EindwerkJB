/**
* Outline shader - http://wiki.unity3d.com/index.php/Silhouette-Outlined_Diffuse
* Author: AnomalousUnderdog
*
* Content is available under Creative Commons Attribution Share Alike.
* https://creativecommons.org/licenses/by-sa/2.5/
*/

//shader used to create the outline when assigned button is pressed
Shader "Outlined/Silhouetted Bumped Diffuse" {
	Properties{
		_Color("Main Color", Color) = (0,0,0,1) //always takes the original color of the default shader anyway
		//_OutlineColor("Outline Color", Color) = (0.255, 0.2, 0.651, 1) //RGB values divided by 255 to make it normalized BLUE
		_OutlineColor("Outline Color", Color) = (0.937, 0.776, 0.188, 1) //RGB values divided by 255 to make it normalized YELLOW
		_Outline("Outline width", Range(0.0, 3)) = .5 // set how far the max outline may be from original object
		_Size("Outline Thickness", Float) = 1.1
		_MainTex("Base (RGB)", 2D) = "white" { }
	_BumpMap("Bumpmap", 2D) = "bump" {}
	}

		CGINCLUDE
#include "UnityCG.cginc"

		half _Size;
		struct appdata {
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};

	struct v2f {
		float4 pos : POSITION;
		float4 color : COLOR;
	};

	uniform float _Outline;
	uniform float4 _OutlineColor;

	v2f vert(appdata v) {
		// just make a copy of incoming vertex data but scaled according to normal direction
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);

		float3 norm = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
		float2 offset = TransformViewToProjection(norm.xy);
		v.vertex.xyz *= _Size;

		o.pos.xy += offset * o.pos.z * _Outline;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		o.color = _OutlineColor;
		return o;
	}
	ENDCG

		SubShader{
		Tags{ "Queue" = "Transparent" }

		// note that a vertex shader is specified here but its using the one above
		Pass{
		Name "OUTLINE"
		Tags{ "LightMode" = "Always" }
		Cull Off
		ZWrite Off
		ZTest Always

		// you can choose what kind of blending mode you want for the outline
		Blend SrcAlpha OneMinusSrcAlpha // options: Normal, One One (Additive), OneMinusDstColor (Soft Additive), DstColor Zero (Multiplicative), DstColor SrcColor (2x Multiplicative)

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

		half4 frag(v2f i) : COLOR{
		return i.color;
	}
		ENDCG
	}


		CGPROGRAM
#pragma surface surf Lambert
		struct Input {
		float2 uv_MainTex;
		float2 uv_BumpMap;
	};
	sampler2D _MainTex;
	sampler2D _BumpMap;
	uniform float3 _Color;
	void surf(Input IN, inout SurfaceOutput o) {
		o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _Color;
		o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
	}
	ENDCG

	}

		SubShader{
		Tags{ "Queue" = "Transparent" }

		Pass{
		Name "OUTLINE"
		Tags{ "LightMode" = "Always" }
		Cull Front
		ZWrite Off
		ZTest Always
		Offset 15,15

		// you can choose what kind of blending mode you want for the outline
		Blend SrcAlpha OneMinusSrcAlpha // options: Normal, One One (Additive), OneMinusDstColor (Soft Additive), DstColor Zero (Multiplicative), DstColor SrcColor (2x Multiplicative)

		CGPROGRAM
#pragma vertex vert
#pragma exclude_renderers gles xbox360 ps3
		ENDCG
		SetTexture[_MainTex]{ combine primary }
	}

		CGPROGRAM
#pragma surface surf Lambert
		struct Input {
		float2 uv_MainTex;
		float2 uv_BumpMap;
	};
	sampler2D _MainTex;
	sampler2D _BumpMap;
	uniform float3 _Color;
	void surf(Input IN, inout SurfaceOutput o) {
		o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _Color;
		o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
	}
	ENDCG

	}

		Fallback "Outlined/Silhouetted Diffuse"
}