using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_Version", "m_SourceFontFileGUID", "m_SourceFontFile_EditorRef", "m_SourceFontFile", "m_AtlasPopulationMode", "m_FaceInfo", "m_GlyphTable", "m_GlyphLookupDictionary", "m_CharacterTable", "m_CharacterLookupDictionary", "m_AtlasTexture", "m_AtlasTextures", "m_AtlasTextureIndex", "m_IsMultiAtlasTexturesEnabled", "m_ClearDynamicDataOnBuild", "m_UsedGlyphRects", "m_FreeGlyphRects", "m_fontInfo", "atlas", "m_AtlasWidth", "m_AtlasHeight", "m_AtlasPadding", "m_AtlasRenderMode", "m_glyphInfoList", "m_KerningTable", "m_FontFeatureTable", "fallbackFontAssets", "m_FallbackFontAssetTable", "m_CreationSettings", "m_FontWeightTable", "fontWeights", "normalStyle", "normalSpacingOffset", "boldStyle", "boldSpacing", "italicStyle", "tabSize", "IsFontAssetLookupTablesDirty", "s_DefaultMaterialSuffix", "FallbackSearchQueryLookup", "k_SearchedFontAssetLookup", "k_FontAssets_FontFeaturesUpdateQueue", "k_FontAssets_FontFeaturesUpdateQueueLookup", "k_FontAssets_AtlasTexturesUpdateQueue", "k_FontAssets_AtlasTexturesUpdateQueueLookup", "m_GlyphsToRender", "m_GlyphsRendered", "m_GlyphIndexList", "m_GlyphIndexListNewlyAdded", "m_GlyphsToAdd", "m_GlyphsToAddLookup", "m_CharactersToAdd", "m_CharactersToAddLookup", "s_MissingCharacterList", "m_MissingUnicodesFromFontFile", "k_GlyphIndexArray", "m_InstanceID", "hashCode", "material", "materialHashCode", "version", "sourceFontFile", "atlasPopulationMode", "faceInfo", "glyphTable", "characterTable", "atlasTextures", "isMultiAtlasTexturesEnabled", "clearDynamicDataOnBuild", "usedGlyphRects", "freeGlyphRects", "atlasWidth", "atlasHeight", "atlasPadding", "atlasRenderMode", "fontFeatureTable", "fallbackFontAssetTable", "creationSettings", "fontWeightTable", "name")]
	public class ES3UserType_TMP_FontAsset : ES3ScriptableObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TMP_FontAsset() : base(typeof(TMPro.TMP_FontAsset)){ Instance = this; priority = 1; }


		protected override void WriteScriptableObject(object obj, ES3Writer writer)
		{
			var instance = (TMPro.TMP_FontAsset)obj;
			
			writer.WritePrivateField("m_Version", instance);
			writer.WritePrivateField("m_SourceFontFileGUID", instance);
			writer.WritePrivateFieldByRef("m_SourceFontFile_EditorRef", instance);
			writer.WritePrivateFieldByRef("m_SourceFontFile", instance);
			writer.WritePrivateField("m_AtlasPopulationMode", instance);
			writer.WritePrivateField("m_FaceInfo", instance);
			writer.WritePrivateField("m_GlyphTable", instance);
			writer.WritePrivateField("m_GlyphLookupDictionary", instance);
			writer.WritePrivateField("m_CharacterTable", instance);
			writer.WritePrivateField("m_CharacterLookupDictionary", instance);
			writer.WritePrivateFieldByRef("m_AtlasTexture", instance);
			writer.WritePrivateField("m_AtlasTextures", instance);
			writer.WritePrivateField("m_AtlasTextureIndex", instance);
			writer.WritePrivateField("m_IsMultiAtlasTexturesEnabled", instance);
			writer.WritePrivateField("m_ClearDynamicDataOnBuild", instance);
			writer.WritePrivateField("m_UsedGlyphRects", instance);
			writer.WritePrivateField("m_FreeGlyphRects", instance);
			writer.WritePrivateField("m_fontInfo", instance);
			writer.WritePropertyByRef("atlas", instance.atlas);
			writer.WritePrivateField("m_AtlasWidth", instance);
			writer.WritePrivateField("m_AtlasHeight", instance);
			writer.WritePrivateField("m_AtlasPadding", instance);
			writer.WritePrivateField("m_AtlasRenderMode", instance);
			writer.WritePrivateField("m_glyphInfoList", instance);
			writer.WritePrivateField("m_KerningTable", instance);
			writer.WritePrivateField("m_FontFeatureTable", instance);
			writer.WritePrivateField("fallbackFontAssets", instance);
			writer.WritePrivateField("m_FallbackFontAssetTable", instance);
			writer.WritePrivateField("m_CreationSettings", instance);
			writer.WritePrivateField("m_FontWeightTable", instance);
			writer.WritePrivateField("fontWeights", instance);
			writer.WriteProperty("normalStyle", instance.normalStyle, ES3Type_float.Instance);
			writer.WriteProperty("normalSpacingOffset", instance.normalSpacingOffset, ES3Type_float.Instance);
			writer.WriteProperty("boldStyle", instance.boldStyle, ES3Type_float.Instance);
			writer.WriteProperty("boldSpacing", instance.boldSpacing, ES3Type_float.Instance);
			writer.WriteProperty("italicStyle", instance.italicStyle, ES3Type_byte.Instance);
			writer.WriteProperty("tabSize", instance.tabSize, ES3Type_byte.Instance);
			writer.WritePrivateField("IsFontAssetLookupTablesDirty", instance);
			writer.WritePrivateField("s_DefaultMaterialSuffix", instance);
			writer.WritePrivateField("FallbackSearchQueryLookup", instance);
			writer.WritePrivateField("k_SearchedFontAssetLookup", instance);
			writer.WritePrivateField("k_FontAssets_FontFeaturesUpdateQueue", instance);
			writer.WritePrivateField("k_FontAssets_FontFeaturesUpdateQueueLookup", instance);
			writer.WritePrivateField("k_FontAssets_AtlasTexturesUpdateQueue", instance);
			writer.WritePrivateField("k_FontAssets_AtlasTexturesUpdateQueueLookup", instance);
			writer.WritePrivateField("m_GlyphsToRender", instance);
			writer.WritePrivateField("m_GlyphsRendered", instance);
			writer.WritePrivateField("m_GlyphIndexList", instance);
			writer.WritePrivateField("m_GlyphIndexListNewlyAdded", instance);
			writer.WritePrivateField("m_GlyphsToAdd", instance);
			writer.WritePrivateField("m_GlyphsToAddLookup", instance);
			writer.WritePrivateField("m_CharactersToAdd", instance);
			writer.WritePrivateField("m_CharactersToAddLookup", instance);
			writer.WritePrivateField("s_MissingCharacterList", instance);
			writer.WritePrivateField("m_MissingUnicodesFromFontFile", instance);
			writer.WritePrivateField("k_GlyphIndexArray", instance);
			writer.WritePrivateField("m_InstanceID", instance);
			writer.WriteProperty("hashCode", instance.hashCode, ES3Type_int.Instance);
			writer.WritePropertyByRef("material", instance.material);
			writer.WriteProperty("materialHashCode", instance.materialHashCode, ES3Type_int.Instance);
			writer.WritePrivateProperty("version", instance);
			writer.WritePrivatePropertyByRef("sourceFontFile", instance);
			writer.WriteProperty("atlasPopulationMode", instance.atlasPopulationMode);
			writer.WriteProperty("faceInfo", instance.faceInfo);
			writer.WritePrivateProperty("glyphTable", instance);
			writer.WritePrivateProperty("characterTable", instance);
			writer.WriteProperty("atlasTextures", instance.atlasTextures, ES3Type_Texture2DArray.Instance);
			writer.WriteProperty("isMultiAtlasTexturesEnabled", instance.isMultiAtlasTexturesEnabled, ES3Type_bool.Instance);
			writer.WritePrivateProperty("clearDynamicDataOnBuild", instance);
			writer.WritePrivateProperty("usedGlyphRects", instance);
			writer.WritePrivateProperty("freeGlyphRects", instance);
			writer.WritePrivateProperty("atlasWidth", instance);
			writer.WritePrivateProperty("atlasHeight", instance);
			writer.WritePrivateProperty("atlasPadding", instance);
			writer.WritePrivateProperty("atlasRenderMode", instance);
			writer.WritePrivateProperty("fontFeatureTable", instance);
			writer.WriteProperty("fallbackFontAssetTable", instance.fallbackFontAssetTable);
			writer.WriteProperty("creationSettings", instance.creationSettings);
			writer.WritePrivateProperty("fontWeightTable", instance);
			writer.WriteProperty("name", instance.name, ES3Type_string.Instance);
		}

		protected override void ReadScriptableObject<T>(ES3Reader reader, object obj)
		{
			var instance = (TMPro.TMP_FontAsset)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_Version":
					reader.SetPrivateField("m_Version", reader.Read<System.String>(), instance);
					break;
					case "m_SourceFontFileGUID":
					reader.SetPrivateField("m_SourceFontFileGUID", reader.Read<System.String>(), instance);
					break;
					case "m_SourceFontFile_EditorRef":
					reader.SetPrivateField("m_SourceFontFile_EditorRef", reader.Read<UnityEngine.Font>(), instance);
					break;
					case "m_SourceFontFile":
					reader.SetPrivateField("m_SourceFontFile", reader.Read<UnityEngine.Font>(), instance);
					break;
					case "m_AtlasPopulationMode":
					reader.SetPrivateField("m_AtlasPopulationMode", reader.Read<TMPro.AtlasPopulationMode>(), instance);
					break;
					case "m_FaceInfo":
					reader.SetPrivateField("m_FaceInfo", reader.Read<UnityEngine.TextCore.FaceInfo>(), instance);
					break;
					case "m_GlyphTable":
					reader.SetPrivateField("m_GlyphTable", reader.Read<System.Collections.Generic.List<UnityEngine.TextCore.Glyph>>(), instance);
					break;
					case "m_GlyphLookupDictionary":
					reader.SetPrivateField("m_GlyphLookupDictionary", reader.Read<System.Collections.Generic.Dictionary<System.UInt32, UnityEngine.TextCore.Glyph>>(), instance);
					break;
					case "m_CharacterTable":
					reader.SetPrivateField("m_CharacterTable", reader.Read<System.Collections.Generic.List<TMPro.TMP_Character>>(), instance);
					break;
					case "m_CharacterLookupDictionary":
					reader.SetPrivateField("m_CharacterLookupDictionary", reader.Read<System.Collections.Generic.Dictionary<System.UInt32, TMPro.TMP_Character>>(), instance);
					break;
					case "m_AtlasTexture":
					reader.SetPrivateField("m_AtlasTexture", reader.Read<UnityEngine.Texture2D>(), instance);
					break;
					case "m_AtlasTextures":
					reader.SetPrivateField("m_AtlasTextures", reader.Read<UnityEngine.Texture2D[]>(), instance);
					break;
					case "m_AtlasTextureIndex":
					reader.SetPrivateField("m_AtlasTextureIndex", reader.Read<System.Int32>(), instance);
					break;
					case "m_IsMultiAtlasTexturesEnabled":
					reader.SetPrivateField("m_IsMultiAtlasTexturesEnabled", reader.Read<System.Boolean>(), instance);
					break;
					case "m_ClearDynamicDataOnBuild":
					reader.SetPrivateField("m_ClearDynamicDataOnBuild", reader.Read<System.Boolean>(), instance);
					break;
					case "m_UsedGlyphRects":
					reader.SetPrivateField("m_UsedGlyphRects", reader.Read<System.Collections.Generic.List<UnityEngine.TextCore.GlyphRect>>(), instance);
					break;
					case "m_FreeGlyphRects":
					reader.SetPrivateField("m_FreeGlyphRects", reader.Read<System.Collections.Generic.List<UnityEngine.TextCore.GlyphRect>>(), instance);
					break;
					case "m_fontInfo":
					reader.SetPrivateField("m_fontInfo", reader.Read<TMPro.FaceInfo_Legacy>(), instance);
					break;
					case "atlas":
						instance.atlas = reader.Read<UnityEngine.Texture2D>(ES3Type_Texture2D.Instance);
						break;
					case "m_AtlasWidth":
					reader.SetPrivateField("m_AtlasWidth", reader.Read<System.Int32>(), instance);
					break;
					case "m_AtlasHeight":
					reader.SetPrivateField("m_AtlasHeight", reader.Read<System.Int32>(), instance);
					break;
					case "m_AtlasPadding":
					reader.SetPrivateField("m_AtlasPadding", reader.Read<System.Int32>(), instance);
					break;
					case "m_AtlasRenderMode":
					reader.SetPrivateField("m_AtlasRenderMode", reader.Read<UnityEngine.TextCore.LowLevel.GlyphRenderMode>(), instance);
					break;
					case "m_glyphInfoList":
					reader.SetPrivateField("m_glyphInfoList", reader.Read<System.Collections.Generic.List<TMPro.TMP_Glyph>>(), instance);
					break;
					case "m_KerningTable":
					reader.SetPrivateField("m_KerningTable", reader.Read<TMPro.KerningTable>(), instance);
					break;
					case "m_FontFeatureTable":
					reader.SetPrivateField("m_FontFeatureTable", reader.Read<TMPro.TMP_FontFeatureTable>(), instance);
					break;
					case "fallbackFontAssets":
					reader.SetPrivateField("fallbackFontAssets", reader.Read<System.Collections.Generic.List<TMPro.TMP_FontAsset>>(), instance);
					break;
					case "m_FallbackFontAssetTable":
					reader.SetPrivateField("m_FallbackFontAssetTable", reader.Read<System.Collections.Generic.List<TMPro.TMP_FontAsset>>(), instance);
					break;
					case "m_CreationSettings":
					reader.SetPrivateField("m_CreationSettings", reader.Read<TMPro.FontAssetCreationSettings>(), instance);
					break;
					case "m_FontWeightTable":
					reader.SetPrivateField("m_FontWeightTable", reader.Read<TMPro.TMP_FontWeightPair[]>(), instance);
					break;
					case "fontWeights":
					reader.SetPrivateField("fontWeights", reader.Read<TMPro.TMP_FontWeightPair[]>(), instance);
					break;
					case "normalStyle":
						instance.normalStyle = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "normalSpacingOffset":
						instance.normalSpacingOffset = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "boldStyle":
						instance.boldStyle = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "boldSpacing":
						instance.boldSpacing = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "italicStyle":
						instance.italicStyle = reader.Read<System.Byte>(ES3Type_byte.Instance);
						break;
					case "tabSize":
						instance.tabSize = reader.Read<System.Byte>(ES3Type_byte.Instance);
						break;
					case "IsFontAssetLookupTablesDirty":
					reader.SetPrivateField("IsFontAssetLookupTablesDirty", reader.Read<System.Boolean>(), instance);
					break;
					case "s_DefaultMaterialSuffix":
					reader.SetPrivateField("s_DefaultMaterialSuffix", reader.Read<System.String>(), instance);
					break;
					case "FallbackSearchQueryLookup":
					reader.SetPrivateField("FallbackSearchQueryLookup", reader.Read<System.Collections.Generic.HashSet<System.Int32>>(), instance);
					break;
					case "k_SearchedFontAssetLookup":
					reader.SetPrivateField("k_SearchedFontAssetLookup", reader.Read<System.Collections.Generic.HashSet<System.Int32>>(), instance);
					break;
					case "k_FontAssets_FontFeaturesUpdateQueue":
					reader.SetPrivateField("k_FontAssets_FontFeaturesUpdateQueue", reader.Read<System.Collections.Generic.List<TMPro.TMP_FontAsset>>(), instance);
					break;
					case "k_FontAssets_FontFeaturesUpdateQueueLookup":
					reader.SetPrivateField("k_FontAssets_FontFeaturesUpdateQueueLookup", reader.Read<System.Collections.Generic.HashSet<System.Int32>>(), instance);
					break;
					case "k_FontAssets_AtlasTexturesUpdateQueue":
					reader.SetPrivateField("k_FontAssets_AtlasTexturesUpdateQueue", reader.Read<System.Collections.Generic.List<TMPro.TMP_FontAsset>>(), instance);
					break;
					case "k_FontAssets_AtlasTexturesUpdateQueueLookup":
					reader.SetPrivateField("k_FontAssets_AtlasTexturesUpdateQueueLookup", reader.Read<System.Collections.Generic.HashSet<System.Int32>>(), instance);
					break;
					case "m_GlyphsToRender":
					reader.SetPrivateField("m_GlyphsToRender", reader.Read<System.Collections.Generic.List<UnityEngine.TextCore.Glyph>>(), instance);
					break;
					case "m_GlyphsRendered":
					reader.SetPrivateField("m_GlyphsRendered", reader.Read<System.Collections.Generic.List<UnityEngine.TextCore.Glyph>>(), instance);
					break;
					case "m_GlyphIndexList":
					reader.SetPrivateField("m_GlyphIndexList", reader.Read<System.Collections.Generic.List<System.UInt32>>(), instance);
					break;
					case "m_GlyphIndexListNewlyAdded":
					reader.SetPrivateField("m_GlyphIndexListNewlyAdded", reader.Read<System.Collections.Generic.List<System.UInt32>>(), instance);
					break;
					case "m_GlyphsToAdd":
					reader.SetPrivateField("m_GlyphsToAdd", reader.Read<System.Collections.Generic.List<System.UInt32>>(), instance);
					break;
					case "m_GlyphsToAddLookup":
					reader.SetPrivateField("m_GlyphsToAddLookup", reader.Read<System.Collections.Generic.HashSet<System.UInt32>>(), instance);
					break;
					case "m_CharactersToAdd":
					reader.SetPrivateField("m_CharactersToAdd", reader.Read<System.Collections.Generic.List<TMPro.TMP_Character>>(), instance);
					break;
					case "m_CharactersToAddLookup":
					reader.SetPrivateField("m_CharactersToAddLookup", reader.Read<System.Collections.Generic.HashSet<System.UInt32>>(), instance);
					break;
					case "s_MissingCharacterList":
					reader.SetPrivateField("s_MissingCharacterList", reader.Read<System.Collections.Generic.List<System.UInt32>>(), instance);
					break;
					case "m_MissingUnicodesFromFontFile":
					reader.SetPrivateField("m_MissingUnicodesFromFontFile", reader.Read<System.Collections.Generic.HashSet<System.UInt32>>(), instance);
					break;
					case "k_GlyphIndexArray":
					reader.SetPrivateField("k_GlyphIndexArray", reader.Read<System.UInt32[]>(), instance);
					break;
					case "m_InstanceID":
					reader.SetPrivateField("m_InstanceID", reader.Read<System.Int32>(), instance);
					break;
					case "hashCode":
						instance.hashCode = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "material":
						instance.material = reader.Read<UnityEngine.Material>(ES3Type_Material.Instance);
						break;
					case "materialHashCode":
						instance.materialHashCode = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "version":
					reader.SetPrivateProperty("version", reader.Read<System.String>(), instance);
					break;
					case "sourceFontFile":
					reader.SetPrivateProperty("sourceFontFile", reader.Read<UnityEngine.Font>(), instance);
					break;
					case "atlasPopulationMode":
						instance.atlasPopulationMode = reader.Read<TMPro.AtlasPopulationMode>();
						break;
					case "faceInfo":
						instance.faceInfo = reader.Read<UnityEngine.TextCore.FaceInfo>();
						break;
					case "glyphTable":
					reader.SetPrivateProperty("glyphTable", reader.Read<System.Collections.Generic.List<UnityEngine.TextCore.Glyph>>(), instance);
					break;
					case "characterTable":
					reader.SetPrivateProperty("characterTable", reader.Read<System.Collections.Generic.List<TMPro.TMP_Character>>(), instance);
					break;
					case "atlasTextures":
						instance.atlasTextures = reader.Read<UnityEngine.Texture2D[]>(ES3Type_Texture2DArray.Instance);
						break;
					case "isMultiAtlasTexturesEnabled":
						instance.isMultiAtlasTexturesEnabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "clearDynamicDataOnBuild":
					reader.SetPrivateProperty("clearDynamicDataOnBuild", reader.Read<System.Boolean>(), instance);
					break;
					case "usedGlyphRects":
					reader.SetPrivateProperty("usedGlyphRects", reader.Read<System.Collections.Generic.List<UnityEngine.TextCore.GlyphRect>>(), instance);
					break;
					case "freeGlyphRects":
					reader.SetPrivateProperty("freeGlyphRects", reader.Read<System.Collections.Generic.List<UnityEngine.TextCore.GlyphRect>>(), instance);
					break;
					case "atlasWidth":
					reader.SetPrivateProperty("atlasWidth", reader.Read<System.Int32>(), instance);
					break;
					case "atlasHeight":
					reader.SetPrivateProperty("atlasHeight", reader.Read<System.Int32>(), instance);
					break;
					case "atlasPadding":
					reader.SetPrivateProperty("atlasPadding", reader.Read<System.Int32>(), instance);
					break;
					case "atlasRenderMode":
					reader.SetPrivateProperty("atlasRenderMode", reader.Read<UnityEngine.TextCore.LowLevel.GlyphRenderMode>(), instance);
					break;
					case "fontFeatureTable":
					reader.SetPrivateProperty("fontFeatureTable", reader.Read<TMPro.TMP_FontFeatureTable>(), instance);
					break;
					case "fallbackFontAssetTable":
						instance.fallbackFontAssetTable = reader.Read<System.Collections.Generic.List<TMPro.TMP_FontAsset>>();
						break;
					case "creationSettings":
						instance.creationSettings = reader.Read<TMPro.FontAssetCreationSettings>();
						break;
					case "fontWeightTable":
					reader.SetPrivateProperty("fontWeightTable", reader.Read<TMPro.TMP_FontWeightPair[]>(), instance);
					break;
					case "name":
						instance.name = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TMP_FontAssetArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TMP_FontAssetArray() : base(typeof(TMPro.TMP_FontAsset[]), ES3UserType_TMP_FontAsset.Instance)
		{
			Instance = this;
		}
	}
}