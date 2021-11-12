using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_ElementType", "m_Unicode", "m_TextAsset", "m_GlyphIndex", "m_Scale", "textAsset")]
	public class ES3UserType_TMP_TextElement : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TMP_TextElement() : base(typeof(TMPro.TMP_TextElement)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (TMPro.TMP_TextElement)obj;
			
			writer.WritePrivateField("m_ElementType", instance);
			writer.WritePrivateField("m_Unicode", instance);
			writer.WritePrivateFieldByRef("m_TextAsset", instance);
			writer.WritePrivateField("m_GlyphIndex", instance);
			writer.WritePrivateField("m_Scale", instance);
			writer.WritePropertyByRef("textAsset", instance.textAsset);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (TMPro.TMP_TextElement)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_ElementType":
					reader.SetPrivateField("m_ElementType", reader.Read<TMPro.TextElementType>(), instance);
					break;
					case "m_Unicode":
					reader.SetPrivateField("m_Unicode", reader.Read<System.UInt32>(), instance);
					break;
					case "m_TextAsset":
					reader.SetPrivateField("m_TextAsset", reader.Read<TMPro.TMP_Asset>(), instance);
					break;
					case "m_GlyphIndex":
					reader.SetPrivateField("m_GlyphIndex", reader.Read<System.UInt32>(), instance);
					break;
					case "m_Scale":
					reader.SetPrivateField("m_Scale", reader.Read<System.Single>(), instance);
					break;
					case "textAsset":
						instance.textAsset = reader.Read<TMPro.TMP_Asset>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new TMPro.TMP_TextElement();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_TMP_TextElementArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TMP_TextElementArray() : base(typeof(TMPro.TMP_TextElement[]), ES3UserType_TMP_TextElement.Instance)
		{
			Instance = this;
		}
	}
}