using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

static class Extensions
{
	public static Rect ToUVCoords(this Rect src, float width, float height, float tiling)
	{
		var stepX = 1.0f / width;
		var stepY = 1.0f / height;

		return new Rect((src.x * stepX) / tiling, (1.0f - (src.y * stepY + src.height * stepY)) / tiling, (src.width * stepX) / tiling, (src.height * stepY) / tiling);
	}

	public static void SetMetallicTexture(this Material mat, Texture tex)
	{
		mat.SetTexture("_MetallicGlossMap", tex);
	}

	public static void SetSmoothness(this Material mat, float val)
	{
		mat.SetFloat("_Glossiness",val);
	}

	public static void SetAlbedoTexture(this Material mat, Texture tex)
	{
		mat.SetTexture("_MainTex", tex);	
	}

	public static void SetAlbedoColor(this Material mat, Color color)
	{
		mat.SetColor("_Color", color);
	}

	public static DateTime StartOfDay(this DateTime date)
	{
		return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
	}

	public static string NormalizeLineEndings(this string str)
	{
		return Regex.Replace(str, @"\r\n|\n\r|\n|\r", System.Environment.NewLine);
	}
}
