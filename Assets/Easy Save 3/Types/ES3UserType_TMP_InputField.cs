using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_TextViewport", "m_TextComponent", "m_Placeholder", "m_VerticalScrollbar", "m_VerticalScrollbarEventHandler", "m_LayoutGroup", "m_ScrollSensitivity", "m_ContentType", "m_InputType", "m_AsteriskChar", "m_KeyboardType", "m_LineType", "m_HideMobileInput", "m_HideSoftKeyboard", "m_CharacterValidation", "m_RegexValue", "m_GlobalPointSize", "m_CharacterLimit", "m_OnEndEdit", "m_OnSubmit", "m_OnSelect", "m_OnDeselect", "m_OnTextSelection", "m_OnEndTextSelection", "m_OnValueChanged", "m_OnTouchScreenKeyboardStatusChanged", "m_CaretColor", "m_CustomCaretColor", "m_SelectionColor", "m_Text", "m_CaretBlinkRate", "m_CaretWidth", "m_ReadOnly", "m_RichText", "m_GlobalFontAsset", "m_OnFocusSelectAll", "m_ResetOnDeActivation", "m_RestoreOriginalTextOnEscape", "m_isRichTextEditingAllowed", "m_LineLimit", "m_InputValidator", "text")]
	public class ES3UserType_TMP_InputField : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TMP_InputField() : base(typeof(TMPro.TMP_InputField)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TMPro.TMP_InputField)obj;
			
			writer.WritePrivateFieldByRef("m_TextViewport", instance);
			writer.WritePrivateFieldByRef("m_TextComponent", instance);
			writer.WritePrivateFieldByRef("m_Placeholder", instance);
			writer.WritePrivateFieldByRef("m_VerticalScrollbar", instance);
			writer.WritePrivateFieldByRef("m_VerticalScrollbarEventHandler", instance);
			writer.WritePrivateFieldByRef("m_LayoutGroup", instance);
			writer.WritePrivateField("m_ScrollSensitivity", instance);
			writer.WritePrivateField("m_ContentType", instance);
			writer.WritePrivateField("m_InputType", instance);
			writer.WritePrivateField("m_AsteriskChar", instance);
			writer.WritePrivateField("m_KeyboardType", instance);
			writer.WritePrivateField("m_LineType", instance);
			writer.WritePrivateField("m_HideMobileInput", instance);
			writer.WritePrivateField("m_HideSoftKeyboard", instance);
			writer.WritePrivateField("m_CharacterValidation", instance);
			writer.WritePrivateField("m_RegexValue", instance);
			writer.WritePrivateField("m_GlobalPointSize", instance);
			writer.WritePrivateField("m_CharacterLimit", instance);
			writer.WritePrivateField("m_OnEndEdit", instance);
			writer.WritePrivateField("m_OnSubmit", instance);
			writer.WritePrivateField("m_OnSelect", instance);
			writer.WritePrivateField("m_OnDeselect", instance);
			writer.WritePrivateField("m_OnTextSelection", instance);
			writer.WritePrivateField("m_OnEndTextSelection", instance);
			writer.WritePrivateField("m_OnValueChanged", instance);
			writer.WritePrivateField("m_OnTouchScreenKeyboardStatusChanged", instance);
			writer.WritePrivateField("m_CaretColor", instance);
			writer.WritePrivateField("m_CustomCaretColor", instance);
			writer.WritePrivateField("m_SelectionColor", instance);
			writer.WritePrivateField("m_Text", instance);
			writer.WritePrivateField("m_CaretBlinkRate", instance);
			writer.WritePrivateField("m_CaretWidth", instance);
			writer.WritePrivateField("m_ReadOnly", instance);
			writer.WritePrivateField("m_RichText", instance);
			writer.WritePrivateFieldByRef("m_GlobalFontAsset", instance);
			writer.WritePrivateField("m_OnFocusSelectAll", instance);
			writer.WritePrivateField("m_ResetOnDeActivation", instance);
			writer.WritePrivateField("m_RestoreOriginalTextOnEscape", instance);
			writer.WritePrivateField("m_isRichTextEditingAllowed", instance);
			writer.WritePrivateField("m_LineLimit", instance);
			writer.WritePrivateFieldByRef("m_InputValidator", instance);
			writer.WriteProperty("text", instance.text, ES3Type_string.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TMPro.TMP_InputField)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_TextViewport":
					reader.SetPrivateField("m_TextViewport", reader.Read<UnityEngine.RectTransform>(), instance);
					break;
					case "m_TextComponent":
					reader.SetPrivateField("m_TextComponent", reader.Read<TMPro.TMP_Text>(), instance);
					break;
					case "m_Placeholder":
					reader.SetPrivateField("m_Placeholder", reader.Read<UnityEngine.UI.Graphic>(), instance);
					break;
					case "m_VerticalScrollbar":
					reader.SetPrivateField("m_VerticalScrollbar", reader.Read<UnityEngine.UI.Scrollbar>(), instance);
					break;
					case "m_VerticalScrollbarEventHandler":
					reader.SetPrivateField("m_VerticalScrollbarEventHandler", reader.Read<TMPro.TMP_ScrollbarEventHandler>(), instance);
					break;
					case "m_LayoutGroup":
					reader.SetPrivateField("m_LayoutGroup", reader.Read<UnityEngine.UI.LayoutGroup>(), instance);
					break;
					case "m_ScrollSensitivity":
					reader.SetPrivateField("m_ScrollSensitivity", reader.Read<System.Single>(), instance);
					break;
					case "m_ContentType":
					reader.SetPrivateField("m_ContentType", reader.Read<TMPro.TMP_InputField.ContentType>(), instance);
					break;
					case "m_InputType":
					reader.SetPrivateField("m_InputType", reader.Read<TMPro.TMP_InputField.InputType>(), instance);
					break;
					case "m_AsteriskChar":
					reader.SetPrivateField("m_AsteriskChar", reader.Read<System.Char>(), instance);
					break;
					case "m_KeyboardType":
					reader.SetPrivateField("m_KeyboardType", reader.Read<UnityEngine.TouchScreenKeyboardType>(), instance);
					break;
					case "m_LineType":
					reader.SetPrivateField("m_LineType", reader.Read<TMPro.TMP_InputField.LineType>(), instance);
					break;
					case "m_HideMobileInput":
					reader.SetPrivateField("m_HideMobileInput", reader.Read<System.Boolean>(), instance);
					break;
					case "m_HideSoftKeyboard":
					reader.SetPrivateField("m_HideSoftKeyboard", reader.Read<System.Boolean>(), instance);
					break;
					case "m_CharacterValidation":
					reader.SetPrivateField("m_CharacterValidation", reader.Read<TMPro.TMP_InputField.CharacterValidation>(), instance);
					break;
					case "m_RegexValue":
					reader.SetPrivateField("m_RegexValue", reader.Read<System.String>(), instance);
					break;
					case "m_GlobalPointSize":
					reader.SetPrivateField("m_GlobalPointSize", reader.Read<System.Single>(), instance);
					break;
					case "m_CharacterLimit":
					reader.SetPrivateField("m_CharacterLimit", reader.Read<System.Int32>(), instance);
					break;
					case "m_OnEndEdit":
					reader.SetPrivateField("m_OnEndEdit", reader.Read<TMPro.TMP_InputField.SubmitEvent>(), instance);
					break;
					case "m_OnSubmit":
					reader.SetPrivateField("m_OnSubmit", reader.Read<TMPro.TMP_InputField.SubmitEvent>(), instance);
					break;
					case "m_OnSelect":
					reader.SetPrivateField("m_OnSelect", reader.Read<TMPro.TMP_InputField.SelectionEvent>(), instance);
					break;
					case "m_OnDeselect":
					reader.SetPrivateField("m_OnDeselect", reader.Read<TMPro.TMP_InputField.SelectionEvent>(), instance);
					break;
					case "m_OnTextSelection":
					reader.SetPrivateField("m_OnTextSelection", reader.Read<TMPro.TMP_InputField.TextSelectionEvent>(), instance);
					break;
					case "m_OnEndTextSelection":
					reader.SetPrivateField("m_OnEndTextSelection", reader.Read<TMPro.TMP_InputField.TextSelectionEvent>(), instance);
					break;
					case "m_OnValueChanged":
					reader.SetPrivateField("m_OnValueChanged", reader.Read<TMPro.TMP_InputField.OnChangeEvent>(), instance);
					break;
					case "m_OnTouchScreenKeyboardStatusChanged":
					reader.SetPrivateField("m_OnTouchScreenKeyboardStatusChanged", reader.Read<TMPro.TMP_InputField.TouchScreenKeyboardEvent>(), instance);
					break;
					case "m_CaretColor":
					reader.SetPrivateField("m_CaretColor", reader.Read<UnityEngine.Color>(), instance);
					break;
					case "m_CustomCaretColor":
					reader.SetPrivateField("m_CustomCaretColor", reader.Read<System.Boolean>(), instance);
					break;
					case "m_SelectionColor":
					reader.SetPrivateField("m_SelectionColor", reader.Read<UnityEngine.Color>(), instance);
					break;
					case "m_Text":
					reader.SetPrivateField("m_Text", reader.Read<System.String>(), instance);
					break;
					case "m_CaretBlinkRate":
					reader.SetPrivateField("m_CaretBlinkRate", reader.Read<System.Single>(), instance);
					break;
					case "m_CaretWidth":
					reader.SetPrivateField("m_CaretWidth", reader.Read<System.Int32>(), instance);
					break;
					case "m_ReadOnly":
					reader.SetPrivateField("m_ReadOnly", reader.Read<System.Boolean>(), instance);
					break;
					case "m_RichText":
					reader.SetPrivateField("m_RichText", reader.Read<System.Boolean>(), instance);
					break;
					case "m_GlobalFontAsset":
					reader.SetPrivateField("m_GlobalFontAsset", reader.Read<TMPro.TMP_FontAsset>(), instance);
					break;
					case "m_OnFocusSelectAll":
					reader.SetPrivateField("m_OnFocusSelectAll", reader.Read<System.Boolean>(), instance);
					break;
					case "m_ResetOnDeActivation":
					reader.SetPrivateField("m_ResetOnDeActivation", reader.Read<System.Boolean>(), instance);
					break;
					case "m_RestoreOriginalTextOnEscape":
					reader.SetPrivateField("m_RestoreOriginalTextOnEscape", reader.Read<System.Boolean>(), instance);
					break;
					case "m_isRichTextEditingAllowed":
					reader.SetPrivateField("m_isRichTextEditingAllowed", reader.Read<System.Boolean>(), instance);
					break;
					case "m_LineLimit":
					reader.SetPrivateField("m_LineLimit", reader.Read<System.Int32>(), instance);
					break;
					case "m_InputValidator":
					reader.SetPrivateField("m_InputValidator", reader.Read<TMPro.TMP_InputValidator>(), instance);
					break;
					case "text":
						instance.text = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TMP_InputFieldArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TMP_InputFieldArray() : base(typeof(TMPro.TMP_InputField[]), ES3UserType_TMP_InputField.Instance)
		{
			Instance = this;
		}
	}
}