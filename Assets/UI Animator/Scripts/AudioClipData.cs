using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIAnimatorCore
{
	[System.Serializable]
	public class AudioClipData
	{
		public enum CLIP_TRIGGER_POINT
		{
			START_OF_ANIM_STEP,
			END_OF_ANIM_STEP
		}

#if UNITY_EDITOR
#pragma warning disable 0414
		[SerializeField]
		private bool m_editorFoldoutState = false;
#pragma warning restore 0414
#endif

		[SerializeField]
		private AudioClip m_clip;

		[SerializeField]
		private CLIP_TRIGGER_POINT m_triggerPoint;

		[SerializeField]
		private AnimStepVariableFloat m_delay;

		[SerializeField]
		private AnimStepVariableFloat m_offsetTime;

		[SerializeField]
		private AnimStepVariableFloat m_volume;

		[SerializeField]
		private AnimStepVariableFloat m_pitch;

		private List<bool> m_clipActivatedStates = null;

		public AudioClip Clip { get { return m_clip; } }
		public CLIP_TRIGGER_POINT TriggerPoint { get { return m_triggerPoint; } }
		public AnimStepVariableFloat Delay { get { return m_delay; } }
		public AnimStepVariableFloat OffsetTime { get { return m_offsetTime; } }
		public AnimStepVariableFloat Volume { get { return m_volume; } }
		public AnimStepVariableFloat Pitch { get { return m_pitch; } }

		public void Init(int a_numTargets)
		{
			m_delay = new AnimStepVariableFloat (0, a_numTargets);
			m_offsetTime = new AnimStepVariableFloat (0, a_numTargets);
			m_volume = new AnimStepVariableFloat (1, a_numTargets);
			m_pitch = new AnimStepVariableFloat (1, a_numTargets);
		}

		public void UpdateNumTargets(int a_numTargets)
		{
			m_delay.Initialise (a_numTargets);
			m_offsetTime.Initialise (a_numTargets);
			m_volume.Initialise (a_numTargets);
			m_pitch.Initialise (a_numTargets);
		}

		public bool HasAudioClipActivated(int a_targetIndex)
		{
			if (m_clipActivatedStates == null || a_targetIndex >= m_clipActivatedStates.Count)
			{
				return false;
			}

			return m_clipActivatedStates[a_targetIndex];
		}

		public void MarkAudioClipActivated(int a_targetIndex)
		{
			if (m_clipActivatedStates == null)
			{
				m_clipActivatedStates = new List<bool> ();
			}

			if (a_targetIndex >= m_clipActivatedStates.Count)
			{
				// Increase list size to cover the requested target index
				for (int idx = m_clipActivatedStates.Count; idx < (a_targetIndex + 1); idx++)
				{
					m_clipActivatedStates.Add (false);
				}
			}

			m_clipActivatedStates [a_targetIndex] = true;
		}

		public void ResetAll()
		{
			if (m_clipActivatedStates == null)
			{
				return;
			}

			for (int idx = 0; idx < m_clipActivatedStates.Count; idx++)
			{
				m_clipActivatedStates [idx] = false;
			}
		}
	}
}