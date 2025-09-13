using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UIAnimatorCore
{
	[System.Serializable]
	public class AnimStepVariableFloat : BaseAnimStepVariable
	{
		[SerializeField]
		private float m_from;

		[SerializeField]
		private float m_to;

		[SerializeField]
		private float[] m_masterValues;

		[SerializeField]
		private int m_numTargets;

		public float MinValue { get { return m_type == VariableType.Range ? ( m_from > m_to ? m_to : m_from ) : m_from; } }
		public float LargestValue { get { return m_type == VariableType.Range ? ( m_from > m_to ? m_from : m_to ) : m_from; } }

		public AnimStepVariableFloat()
		{
			m_offsettingEnabled = false;
			m_type = VariableType.Single;
		}

		public AnimStepVariableFloat(bool a_offsettingEnabled)
		{
			m_offsettingEnabled = a_offsettingEnabled;
			m_type = m_offsettingEnabled ? VariableType.Offset : VariableType.Single;
		}

		public AnimStepVariableFloat(VariableType a_startType, bool a_offsettingEnabled)
		{
			m_type = a_startType;
			m_offsettingEnabled = a_offsettingEnabled;
		}

		public AnimStepVariableFloat (float a_startValue, int a_numTargets = 1)
		{
			Initialise( new float[] { a_startValue } );

			m_offsettingEnabled = false;
			m_type = VariableType.Single;
			m_numTargets = a_numTargets;
		}

		public void Initialise( float[] a_masterValues)
		{
			m_from = a_masterValues[0];
			m_to = a_masterValues[0];

			m_masterValues = a_masterValues;
			m_numTargets = m_masterValues.Length;
		}

		public void Initialise( int a_numTargets)
		{
			m_numTargets = a_numTargets;
		}

		public float GetValue(int a_targetIndex)
		{
			if (m_type == VariableType.Single || (m_type == VariableType.Range && m_numTargets == 1))
			{
				return m_from;
			}
			else if(m_type == VariableType.Offset)
			{
				return m_masterValues[a_targetIndex] + (m_from - m_masterValues[0]);
			}
			else if(m_type == VariableType.Range)
			{
				if (m_masterValues.Length > 1)
				{
					return m_masterValues [a_targetIndex] + Mathf.LerpUnclamped (m_from - m_masterValues [0], m_to - m_masterValues [0], (float)a_targetIndex / (m_masterValues.Length - 1));
				}
				else
				{
					return Mathf.LerpUnclamped (m_from, m_to, (float)a_targetIndex / (m_numTargets - 1));
				}
			}

			return m_from;
		}

#if UNITY_EDITOR
		protected override void FromOffsetProperty(SerializedProperty a_sProperty, GUIContent a_propertyLabel, float a_labelWidth)
		{
			float cachedLabelWidth = EditorGUIUtility.labelWidth;
			EditorGUIUtility.labelWidth = a_labelWidth;

			SerializedProperty fromValueProperty = a_sProperty.FindPropertyRelative ("m_from");
			fromValueProperty.floatValue = EditorGUILayout.FloatField (a_propertyLabel, fromValueProperty.floatValue - m_masterValues[0]) + m_masterValues[0];

			EditorGUIUtility.labelWidth = cachedLabelWidth;
		}

		protected override void ToOffsetProperty(SerializedProperty a_sProperty)
		{
			SerializedProperty toValueProperty = a_sProperty.FindPropertyRelative ("m_to");
			toValueProperty.floatValue = EditorGUILayout.FloatField (new GUIContent(" "), toValueProperty.floatValue - m_masterValues[0]) + m_masterValues[0];
		}
#endif
	}
}