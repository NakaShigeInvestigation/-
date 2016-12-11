using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace 矩形選択
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            m_Top = 10;
            m_Left = 10;
            m_Right = 100;
            m_Bottom = 100;

            m_Height = 200;
            m_Width = 200;
        }

        public int Top
        {
            get { return m_Top; }
            set
            {
                m_Top = value;
                OnPropertyChanged("Top");
            }
        }
        public int Left
        {
            get { return m_Left; }
            set
            {
                m_Left = value;
                OnPropertyChanged("Left");
            }
        }
        public int Right
        {
            get { return m_Right; }
            set
            {
                m_Right = value;
                OnPropertyChanged("Right");
            }
        }
        public int Bottom
        {
            get { return m_Bottom; }
            set
            {
                m_Bottom = value;
                OnPropertyChanged("Bottom");
            }
        }

        public int Height
        {
            get { return m_Height; }
            set
            {
                m_Height = value;
                OnPropertyChanged("Height");
            }
        }
        public int Width
        {
            get { return m_Width; }
            set
            {
                m_Width = value;
                OnPropertyChanged("Width");
            }
        }

        public bool Visible
        {
            get { return m_Visible; }
            set
            {
                if (m_Visible != value)
                {
                    m_Visible = value;
                    OnPropertyChanged("Visible");
                }
            }
        }

        private int m_Top;
        private int m_Left;
        private int m_Right;
        private int m_Bottom;
        
        private int m_Height;
        private int m_Width;

        private bool m_Visible = false;

        #region INotifyPropertyChanged メンバー

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
