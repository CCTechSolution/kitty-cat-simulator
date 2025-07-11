using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIAnimatorCore
{
	[System.Serializable]
	public abstract class BaseRendererTargetData
	{
		[SerializeField]
		private float[] m_masterAlphas;
		[SerializeField]
		private bool[] m_activeStates;

		protected Color m_cachedColor;

		public abstract int NumRenderers { get; }
		public abstract float GetRendererAlpha (int a_rendererIndex);
		public abstract void SetRendererAlpha (int a_rendererIndex, float a_alphaValue);

		public void SetupMasterData()
		{
			m_masterAlphas = new float[NumRenderers];
			m_activeStates = new bool[NumRenderers];

			for(int idx=0; idx < NumRenderers; idx++)
			{
				m_masterAlphas[idx] = GetRendererAlpha(idx);
				m_activeStates[idx] = true;
			}
		}

		public void SetToMasterValues()
		{
			for (int idx = 0; idx < NumRenderers; idx++)
			{
				SetRendererAlpha (idx, m_masterAlphas[idx]);
			}
		}

		public void SetFadeProgress(float a_animatedAlpha, float a_progress)
		{
			for (int idx = 0; idx < NumRenderers; idx++)
			{
				if (!m_activeStates[idx])
				{
					continue;
				}

				SetRendererAlpha(idx, Mathf.LerpUnclamped (a_animatedAlpha, m_masterAlphas[idx], a_progress));
			}
		}
	}
}