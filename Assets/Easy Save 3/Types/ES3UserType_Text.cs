using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_Text", "font", "text", "supportRichText", "resizeTextForBestFit", "resizeTextMinSize", "resizeTextMaxSize", "alignment", "alignByGeometry", "fontSize", "horizontalOverflow", "verticalOverflow", "lineSpacing", "fontStyle", "onCullStateChanged", "maskable", "color", "raycastTarget", "material", "enabled", "name")]
	public class ES3UserType_Text : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Text() : base(typeof(UnityEngine.UI.Text)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.Text)obj;
			
			writer.WritePrivateField("m_Text", instance);
			writer.WritePropertyByRef("font", instance.font);
			writer.WriteProperty("text", instance.text, ES3Type_string.Instance);
			writer.WriteProperty("supportRichText", instance.supportRichText, ES3Type_bool.Instance);
			writer.WriteProperty("resizeTextForBestFit", instance.resizeTextForBestFit, ES3Type_bool.Instance);
			writer.WriteProperty("resizeTextMinSize", instance.resizeTextMinSize, ES3Type_int.Instance);
			writer.WriteProperty("resizeTextMaxSize", instance.resizeTextMaxSize, ES3Type_int.Instance);
			writer.WriteProperty("alignment", instance.alignment);
			writer.WriteProperty("alignByGeometry", instance.alignByGeometry, ES3Type_bool.Instance);
			writer.WriteProperty("fontSize", instance.fontSize, ES3Type_int.Instance);
			writer.WriteProperty("horizontalOverflow", instance.horizontalOverflow);
			writer.WriteProperty("verticalOverflow", instance.verticalOverflow);
			writer.WriteProperty("lineSpacing", instance.lineSpacing, ES3Type_float.Instance);
			writer.WriteProperty("fontStyle", instance.fontStyle);
			writer.WriteProperty("onCullStateChanged", instance.onCullStateChanged);
			writer.WriteProperty("maskable", instance.maskable, ES3Type_bool.Instance);
			writer.WriteProperty("color", instance.color, ES3Type_Color.Instance);
			writer.WriteProperty("raycastTarget", instance.raycastTarget, ES3Type_bool.Instance);
			writer.WritePropertyByRef("material", instance.material);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.Text)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_Text":
					reader.SetPrivateField("m_Text", reader.Read<System.String>(), instance);
					break;
					case "font":
						instance.font = reader.Read<UnityEngine.Font>(ES3Type_Font.Instance);
						break;
					case "text":
						instance.text = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "supportRichText":
						instance.supportRichText = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "resizeTextForBestFit":
						instance.resizeTextForBestFit = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "resizeTextMinSize":
						instance.resizeTextMinSize = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "resizeTextMaxSize":
						instance.resizeTextMaxSize = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "alignment":
						instance.alignment = reader.Read<UnityEngine.TextAnchor>();
						break;
					case "alignByGeometry":
						instance.alignByGeometry = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "fontSize":
						instance.fontSize = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "horizontalOverflow":
						instance.horizontalOverflow = reader.Read<UnityEngine.HorizontalWrapMode>();
						break;
					case "verticalOverflow":
						instance.verticalOverflow = reader.Read<UnityEngine.VerticalWrapMode>();
						break;
					case "lineSpacing":
						instance.lineSpacing = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "fontStyle":
						instance.fontStyle = reader.Read<UnityEngine.FontStyle>();
						break;
					case "onCullStateChanged":
						instance.onCullStateChanged = reader.Read<UnityEngine.UI.MaskableGraphic.CullStateChangedEvent>();
						break;
					case "maskable":
						instance.maskable = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "color":
						instance.color = reader.Read<UnityEngine.Color>(ES3Type_Color.Instance);
						break;
					case "raycastTarget":
						instance.raycastTarget = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "material":
						instance.material = reader.Read<UnityEngine.Material>(ES3Type_Material.Instance);
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


	public class ES3UserType_TextArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TextArray() : base(typeof(UnityEngine.UI.Text[]), ES3UserType_Text.Instance)
		{
			Instance = this;
		}
	}
}