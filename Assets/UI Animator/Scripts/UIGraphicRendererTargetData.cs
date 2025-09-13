using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIAnimatorCore
{
	[System.Serializable]
	public class UIGraphicRendererTargetData : BaseRendererTargetData
	{
		[SerializeField]
		private Graphic[] m_graphics;

		public override int NumRenderers { get { return m_graphics != null ? m_graphics.Length : 0; } }

		public override float GetRendererAlpha (int a_rendererIndex)
		{
			if (m_graphics == null || a_rendererIndex >= m_graphics.Length || m_graphics [a_rendererIndex] == null)
			{
				return 1f;
			}

			return m_graphics [a_rendererIndex].color.a;
		}

		public override void SetRendererAlpha (int a_rendererIndex, float a_alphaValue)
		{
			if (m_graphics == null || a_rendererIndex >= m_graphics.Length || m_graphics [a_rendererIndex] == null)
			{
				return;
			}

			m_cachedColor = m_graphics [a_rendererIndex].color;
			m_cachedColor.a = a_alphaValue;
			m_graphics [a_rendererIndex].color = m_cachedColor;
		}

		public UIGraphicRendererTargetData(Graphic[] a_graphics)
		{
			m_graphics = new Graphic[a_graphics.Length];

			for(int idx=0; idx < a_graphics.Length; idx++)
			{
				m_graphics[idx] = a_graphics[idx];
			}

			SetupMasterData();
		}
	}
}