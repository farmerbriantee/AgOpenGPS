using System.Windows.Forms;

namespace Keypad
{
    public partial class GenericKeypad : UserControl
    {
        public GenericKeypad()
        {
            InitializeComponent();
        }

        #region Events

        public event KeyPressEventHandler ButtonPressed;

        #endregion Events

        #region Methods

        public void RaiseButtonPressed(char WhatToSend)

        {
            ButtonPressed?.Invoke(this, new KeyPressEventArgs(WhatToSend));
        }

        #endregion Methods
    }
}