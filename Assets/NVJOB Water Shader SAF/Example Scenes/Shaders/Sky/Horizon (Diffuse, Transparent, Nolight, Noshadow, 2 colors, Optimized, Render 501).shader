﻿// Copyright (c) 2016 Unity Technologies. MIT license - license_unity.txt
// NVJOB Sky Shader - simple and fast. MIT license - license_nvjob.txt
// NVJOB Sky Shader - simple and fast V2.1 - https://github.com/nvjob/nvjob-sky-shader-simple-and-fast
// #NVJOB Nicholas Veselov (independent developer) - https://nvjob.pro, http://nvjob.dx.am


Shader "#NVJOB/Nature/Sky/Horizon (Transparent, Nolight, Noshadow, 2 colors)" {


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



Properties{
//----------------------------------------------

_Level1Color("Level1Color", Color) = (0.65,0.86,0.63,1)
_Level1("Level1", Float) = 10
_Level0Color("Level0Color", Color) = (0.37,0.78,0.92,1)
_Level0("Level0", Float) = 0

//----------------------------------------------
}



//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



SubShader{
///////////////////////////////////////////////////////////////////////////////////////////////////////////////

Tags{ "Queue" = "Geometry+501" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
Blend SrcAlpha OneMinusSrcAlpha
LOD 200

CGPROGRAM
#pragma surface surf Nolight alpha:fade exclude_path:prepass nofog nolightmap nometa nolppv noshadowmask noshadow noshadow noforwardadd novertexlights halfasview

//----------------------------------------------

half4 LightingNolight(SurfaceOutput s, half3 nullA, half nullB) {
half4 c;
c.rgb = s.Albedo;
c.a = s.Alpha;
return c;
}

//----------------------------------------------

half _Level1;
fixed4 _Level1Color;

half _Level0;
fixed4 _Level0Color;

//----------------------------------------------

struct Input {
float3 worldPos;
};

//----------------------------------------------

void surf(Input IN, inout SurfaceOutput o) {
fixed4 c;
fixed4 pixelWorldSpacePosition = IN.worldPos.y;
fixed pixelWpY = pixelWorldSpacePosition.y;

if (pixelWpY >= _Level1) c = lerp(_Level0Color, _Level1Color, (pixelWpY - _Level0) / (_Level1 - _Level0));
if (pixelWpY < _Level0) c = _Level0Color;

o.Albedo = c.rgb;
o.Alpha = c.a;
}

//----------------------------------------------

ENDCG

///////////////////////////////////////////////////////////////////////////////////////////////////////////////
}


Fallback "Legacy Shaders/VertexLit"

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
