using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_UiScaleMode", "m_ReferencePixelsPerUnit", "m_ScaleFactor", "m_ReferenceResolution", "m_ScreenMatchMode", "m_MatchWidthOrHeight", "m_PhysicalUnit", "m_FallbackScreenDPI", "m_DefaultSpriteDPI", "m_DynamicPixelsPerUnit", "m_Canvas", "m_PresetInfoIsWorld", "uiScaleMode", "referencePixelsPerUnit", "scaleFactor", "referenceResolution", "screenMatchMode", "matchWidthOrHeight", "physicalUnit", "fallbackScreenDPI", "defaultSpriteDPI", "dynamicPixelsPerUnit", "enabled", "name")]
	public class ES3UserType_CanvasScaler : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_CanvasScaler() : base(typeof(UnityEngine.UI.CanvasScaler)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.CanvasScaler)obj;
			
			writer.WritePrivateField("m_UiScaleMode", instance);
			writer.WritePrivateField("m_ReferencePixelsPerUnit", instance);
			writer.WritePrivateField("m_ScaleFactor", instance);
			writer.WritePrivateField("m_ReferenceResolution", instance);
			writer.WritePrivateField("m_ScreenMatchMode", instance);
			writer.WritePrivateField("m_MatchWidthOrHeight", instance);
			writer.WritePrivateField("m_PhysicalUnit", instance);
			writer.WritePrivateField("m_FallbackScreenDPI", instance);
			writer.WritePrivateField("m_DefaultSpriteDPI", instance);
			writer.WritePrivateField("m_DynamicPixelsPerUnit", instance);
			writer.WritePrivateFieldByRef("m_Canvas", instance);
			writer.WritePrivateField("m_PresetInfoIsWorld", instance);
			writer.WriteProperty("uiScaleMode", instance.uiScaleMode);
			writer.WriteProperty("referencePixelsPerUnit", instance.referencePixelsPerUnit, ES3Type_float.Instance);
			writer.WriteProperty("scaleFactor", instance.scaleFactor, ES3Type_float.Instance);
			writer.WriteProperty("referenceResolution", instance.referenceResolution, ES3Type_Vector2.Instance);
			writer.WriteProperty("screenMatchMode", instance.screenMatchMode);
			writer.WriteProperty("matchWidthOrHeight", instance.matchWidthOrHeight, ES3Type_float.Instance);
			writer.WriteProperty("physicalUnit", instance.physicalUnit);
			writer.WriteProperty("fallbackScreenDPI", instance.fallbackScreenDPI, ES3Type_float.Instance);
			writer.WriteProperty("defaultSpriteDPI", instance.defaultSpriteDPI, ES3Type_float.Instance);
			writer.WriteProperty("dynamicPixelsPerUnit", instance.dynamicPixelsPerUnit, ES3Type_float.Instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.CanvasScaler)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_UiScaleMode":
					reader.SetPrivateField("m_UiScaleMode", reader.Read<UnityEngine.UI.CanvasScaler.ScaleMode>(), instance);
					break;
					case "m_ReferencePixelsPerUnit":
					reader.SetPrivateField("m_ReferencePixelsPerUnit", reader.Read<System.Single>(), instance);
					break;
					case "m_ScaleFactor":
					reader.SetPrivateField("m_ScaleFactor", reader.Read<System.Single>(), instance);
					break;
					case "m_ReferenceResolution":
					reader.SetPrivateField("m_ReferenceResolution", reader.Read<UnityEngine.Vector2>(), instance);
					break;
					case "m_ScreenMatchMode":
					reader.SetPrivateField("m_ScreenMatchMode", reader.Read<UnityEngine.UI.CanvasScaler.ScreenMatchMode>(), instance);
					break;
					case "m_MatchWidthOrHeight":
					reader.SetPrivateField("m_MatchWidthOrHeight", reader.Read<System.Single>(), instance);
					break;
					case "m_PhysicalUnit":
					reader.SetPrivateField("m_PhysicalUnit", reader.Read<UnityEngine.UI.CanvasScaler.Unit>(), instance);
					break;
					case "m_FallbackScreenDPI":
					reader.SetPrivateField("m_FallbackScreenDPI", reader.Read<System.Single>(), instance);
					break;
					case "m_DefaultSpriteDPI":
					reader.SetPrivateField("m_DefaultSpriteDPI", reader.Read<System.Single>(), instance);
					break;
					case "m_DynamicPixelsPerUnit":
					reader.SetPrivateField("m_DynamicPixelsPerUnit", reader.Read<System.Single>(), instance);
					break;
					case "m_Canvas":
					reader.SetPrivateField("m_Canvas", reader.Read<UnityEngine.Canvas>(), instance);
					break;
					case "m_PresetInfoIsWorld":
					reader.SetPrivateField("m_PresetInfoIsWorld", reader.Read<System.Boolean>(), instance);
					break;
					case "uiScaleMode":
						instance.uiScaleMode = reader.Read<UnityEngine.UI.CanvasScaler.ScaleMode>();
						break;
					case "referencePixelsPerUnit":
						instance.referencePixelsPerUnit = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "scaleFactor":
						instance.scaleFactor = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "referenceResolution":
						instance.referenceResolution = reader.Read<UnityEngine.Vector2>(ES3Type_Vector2.Instance);
						break;
					case "screenMatchMode":
						instance.screenMatchMode = reader.Read<UnityEngine.UI.CanvasScaler.ScreenMatchMode>();
						break;
					case "matchWidthOrHeight":
						instance.matchWidthOrHeight = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "physicalUnit":
						instance.physicalUnit = reader.Read<UnityEngine.UI.CanvasScaler.Unit>();
						break;
					case "fallbackScreenDPI":
						instance.fallbackScreenDPI = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "defaultSpriteDPI":
						instance.defaultSpriteDPI = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "dynamicPixelsPerUnit":
						instance.dynamicPixelsPerUnit = reader.Read<System.Single>(ES3Type_float.Instance);
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


	public class ES3UserType_CanvasScalerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CanvasScalerArray() : base(typeof(UnityEngine.UI.CanvasScaler[]), ES3UserType_CanvasScaler.Instance)
		{
			Instance = this;
		}
	}
}