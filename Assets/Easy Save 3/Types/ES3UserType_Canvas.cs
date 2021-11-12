using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("renderMode", "scaleFactor", "referencePixelsPerUnit", "overridePixelPerfect", "pixelPerfect", "planeDistance", "overrideSorting", "sortingOrder", "targetDisplay", "sortingLayerID", "additionalShaderChannels", "sortingLayerName", "worldCamera", "normalizedSortingGridSize", "enabled", "name")]
	public class ES3UserType_Canvas : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Canvas() : base(typeof(UnityEngine.Canvas)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.Canvas)obj;
			
			writer.WriteProperty("renderMode", instance.renderMode);
			writer.WriteProperty("scaleFactor", instance.scaleFactor, ES3Type_float.Instance);
			writer.WriteProperty("referencePixelsPerUnit", instance.referencePixelsPerUnit, ES3Type_float.Instance);
			writer.WriteProperty("overridePixelPerfect", instance.overridePixelPerfect, ES3Type_bool.Instance);
			writer.WriteProperty("pixelPerfect", instance.pixelPerfect, ES3Type_bool.Instance);
			writer.WriteProperty("planeDistance", instance.planeDistance, ES3Type_float.Instance);
			writer.WriteProperty("overrideSorting", instance.overrideSorting, ES3Type_bool.Instance);
			writer.WriteProperty("sortingOrder", instance.sortingOrder, ES3Type_int.Instance);
			writer.WriteProperty("targetDisplay", instance.targetDisplay, ES3Type_int.Instance);
			writer.WriteProperty("sortingLayerID", instance.sortingLayerID, ES3Type_int.Instance);
			writer.WriteProperty("additionalShaderChannels", instance.additionalShaderChannels);
			writer.WriteProperty("sortingLayerName", instance.sortingLayerName, ES3Type_string.Instance);
			writer.WritePropertyByRef("worldCamera", instance.worldCamera);
			writer.WriteProperty("normalizedSortingGridSize", instance.normalizedSortingGridSize, ES3Type_float.Instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.Canvas)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "renderMode":
						instance.renderMode = reader.Read<UnityEngine.RenderMode>();
						break;
					case "scaleFactor":
						instance.scaleFactor = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "referencePixelsPerUnit":
						instance.referencePixelsPerUnit = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "overridePixelPerfect":
						instance.overridePixelPerfect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "pixelPerfect":
						instance.pixelPerfect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "planeDistance":
						instance.planeDistance = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "overrideSorting":
						instance.overrideSorting = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "sortingOrder":
						instance.sortingOrder = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "targetDisplay":
						instance.targetDisplay = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "sortingLayerID":
						instance.sortingLayerID = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "additionalShaderChannels":
						instance.additionalShaderChannels = reader.Read<UnityEngine.AdditionalCanvasShaderChannels>();
						break;
					case "sortingLayerName":
						instance.sortingLayerName = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "worldCamera":
						instance.worldCamera = reader.Read<UnityEngine.Camera>(ES3Type_Camera.Instance);
						break;
					case "normalizedSortingGridSize":
						instance.normalizedSortingGridSize = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_CanvasArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CanvasArray() : base(typeof(UnityEngine.Canvas[]), ES3UserType_Canvas.Instance)
		{
			Instance = this;
		}
	}
}