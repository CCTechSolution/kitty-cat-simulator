using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UIAnimatorCore
{
	public static class UIAnimatorHelper
	{
#if UNITY_EDITOR
		public static bool RenderListEditingButtons<T>(	List<T> a_list,
														ref int a_listEntryIndex,
														bool a_forceAtLeastOne = false,
														bool a_forceDisableMoveUp = false,
														bool a_forceDisableMoveDown = false,
														bool a_confirmBeforeDeletion = false)
		{
			if (a_listEntryIndex == 0 || a_forceDisableMoveUp)
			{
				GUI.enabled = false;
			}

			if (GUILayout.Button ("\u25B2", EditorStyles.toolbarButton, GUILayout.Width(18)))
			{
				// Move anim up one in the list
				T currentEntry = a_list[a_listEntryIndex];
				a_list.RemoveAt(a_listEntryIndex);
				a_list.Insert (a_listEntryIndex - 1, currentEntry);
			}

			GUI.enabled = true;

			if (a_listEntryIndex == a_list.Count - 1 || a_forceDisableMoveDown)
			{
				GUI.enabled = false;
			}

			if (GUILayout.Button ("\u25BC", EditorStyles.toolbarButton, GUILayout.Width(18)))
			{
				// Move anim up one in the list
				T currentEntry = a_list[a_listEntryIndex];
				a_list.RemoveAt(a_listEntryIndex);
				a_list.Insert (a_listEntryIndex + 1, currentEntry);
			}

			GUI.enabled = true;
			Color colourCache = GUI.backgroundColor;
			GUI.backgroundColor = Color.red;

			if (a_forceAtLeastOne && a_list.Count == 1)
			{
				GUI.enabled = false;
			}

			if (GUILayout.Button ("x", EditorStyles.toolbarButton, GUILayout.Width(18)))
			{
				if(!a_confirmBeforeDeletion || EditorUtility.DisplayDialog("Confirm Deletion", "Are you sure?", "Yes", "No"))
				{
					a_list.RemoveAt(a_listEntryIndex);
					a_listEntryIndex--;
					return true;
				}
			}

			GUI.backgroundColor = colourCache;
			GUI.enabled = true;

			return false;
		}

		// Returns TRUE if the list has been changed in any way
		public static bool RenderListEditingButtons(	SerializedProperty a_list,
														ref int a_listEntryIndex,
														bool a_forceAtLeastOne = false,
														bool a_forceDisableMoveUp = false,
														bool a_forceDisableMoveDown = false,
														bool a_confirmBeforeDeletion = false,
														System.Action a_onMovedUpEvent = null,
														System.Action a_onMovedDownEvent = null,
														System.Action a_onDeleteEvent = null)
		{
			if (!a_list.isArray)
			{
				Debug.LogWarning ("RenderListEditingButtons() Not been passed a SerializedProperty that is an Array!");
				return false;
			}

			if (a_listEntryIndex == 0 || a_forceDisableMoveUp)
			{
				GUI.enabled = false;
			}

			if (GUILayout.Button ("\u25B2", EditorStyles.toolbarButton, GUILayout.Width(18)))
			{
				// Move entry up one in the list
				a_list.MoveArrayElement (a_listEntryIndex, a_listEntryIndex - 1);

				if (a_onMovedUpEvent != null)
				{
					a_onMovedUpEvent ();
				}

				return true;
			}

			GUI.enabled = true;

			if (a_listEntryIndex == a_list.arraySize - 1 || a_forceDisableMoveDown)
			{
				GUI.enabled = false;
			}

			if (GUILayout.Button ("\u25BC", EditorStyles.toolbarButton, GUILayout.Width(18)))
			{
				// Move entry down in list
				a_list.MoveArrayElement (a_listEntryIndex, a_listEntryIndex + 1);

				if (a_onMovedDownEvent != null)
				{
					a_onMovedDownEvent ();
				}

				return true;
			}

			GUI.enabled = true;
			Color colourCache = GUI.backgroundColor;
			GUI.backgroundColor = Color.red;

			if (a_forceAtLeastOne && a_list.arraySize == 1)
			{
				GUI.enabled = false;
			}

			GUILayout.Space (4);

			if (GUILayout.Button ("\u2716", EditorStyles.toolbarButton, GUILayout.Width(18)))
			{
				if(!a_confirmBeforeDeletion || EditorUtility.DisplayDialog("Confirm Deletion", "Are you sure?", "Yes", "No"))
				{
					if (a_list.GetArrayElementAtIndex (a_listEntryIndex).propertyType == SerializedPropertyType.ObjectReference)
					{
						a_list.GetArrayElementAtIndex (a_listEntryIndex).objectReferenceValue = null;
					}
					a_list.DeleteArrayElementAtIndex (a_listEntryIndex);

					a_listEntryIndex--;

					if (a_onDeleteEvent != null)
					{
						a_onDeleteEvent ();
					}
					return true;
				}
			}

			GUI.backgroundColor = colourCache;
			GUI.enabled = true;

			return false;
		}

		public static void BetterPropertyField(SerializedProperty a_property, float a_labelWidth, float a_totalWidth)
		{
			float cachedLabelWidth = EditorGUIUtility.labelWidth;
			EditorGUIUtility.labelWidth = a_labelWidth;
			EditorGUILayout.PropertyField( a_property, GUILayout.Width(a_totalWidth));
			EditorGUIUtility.labelWidth = cachedLabelWidth;
		}

		public static void BetterPropertyField(SerializedProperty a_property, GUIContent a_customLabel, float a_labelWidth, float a_totalWidth)
		{
			float cachedLabelWidth = EditorGUIUtility.labelWidth;
			EditorGUIUtility.labelWidth = a_labelWidth;
			EditorGUILayout.PropertyField( a_property, a_customLabel, GUILayout.Width(a_totalWidth));
			EditorGUIUtility.labelWidth = cachedLabelWidth;
		}

		public static void BetterPropertyField(SerializedProperty a_property, GUIContent a_customLabel, float a_labelWidth)
		{
			float cachedLabelWidth = EditorGUIUtility.labelWidth;
			EditorGUIUtility.labelWidth = a_labelWidth;
			EditorGUILayout.PropertyField( a_property, a_customLabel);
			EditorGUIUtility.labelWidth = cachedLabelWidth;
		}
#endif
	}
}