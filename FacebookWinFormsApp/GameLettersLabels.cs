using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    class GameLettersLabels: ILabelsUpdater
    {
        private Label[] m_CharLabels;

        public Label[] CharLabels { get { return m_CharLabels; } }

        public GameLettersLabels(int i_Height, int i_Width, int i_TotalChars, int i_InitLocationX, int i_InitLocationY, Dictionary<char, List<int>> i_PageLettersIndices)
        {
            int currentLabelX = (i_InitLocationX) - (i_TotalChars * 10) + 20;
            int currentLabelY = i_InitLocationY + 100;

            m_CharLabels = new Label[i_TotalChars];
            for (int i = 0; i < i_TotalChars; i++)
            {
                m_CharLabels[i] = new Label();
                m_CharLabels[i].Height = i_Height;
                m_CharLabels[i].Width = i_Width;
                m_CharLabels[i].Location = new System.Drawing.Point(currentLabelX, currentLabelY);
                m_CharLabels[i].Visible = true;
                storeCurrectCharInLabel(i, i_PageLettersIndices);
                currentLabelX += 50;
            }
        }

        private void storeCurrectCharInLabel(int i_LabelIndex, Dictionary<char, List<int>> i_PageLettersIndices)
        {
            if (i_PageLettersIndices.ContainsKey(' ') && i_PageLettersIndices[' '].Contains(i_LabelIndex))
            {
                m_CharLabels[i_LabelIndex].Text = " ";
            }
            else if (i_PageLettersIndices.ContainsKey('.') && i_PageLettersIndices['.'].Contains(i_LabelIndex))//m_GuessGame.ChosenPageLetters.PageLettersIndices.ContainsKey('.') && m_GuessGame.ChosenPageLetters.PageLettersIndices['.'].Contains(i_LabelIndex))
            {
                m_CharLabels[i_LabelIndex].Text = ".";
            }
            else if (i_PageLettersIndices.ContainsKey('\'') && i_PageLettersIndices['\''].Contains(i_LabelIndex))
            {
                m_CharLabels[i_LabelIndex].Text = "\'";
            }
            else if (i_PageLettersIndices.ContainsKey(',') && i_PageLettersIndices[','].Contains(i_LabelIndex))
            {
                m_CharLabels[i_LabelIndex].Text = ",";
            }
            else
            {
                m_CharLabels[i_LabelIndex].Text = "?";
            }
        }

        public void UpdateLabels(List<int> i_Indices, string i_C)
        {
            foreach (int i in i_Indices)
            {
                m_CharLabels[i].Text = i_C;
            }
        }

        public void Disappear()
        {
            foreach (Label labelChar in m_CharLabels)
            {
                labelChar.Visible = false;
            }
        }

        public void Restart()
        {
            foreach (Label labelChar in m_CharLabels)
            {
                labelChar.Dispose();
            }
        }
    }
}
