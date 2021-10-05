using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProXoft.WinForms
{
    public class RepeatButton : Button
    {
        private Timer m_timerRepeater;
        private IContainer m_components;
        private bool m_disposed = false;
        private MouseEventArgs m_mouseDownArgs = (MouseEventArgs)null;

        public RepeatButton()
        {
            this.InitializeComponent();
            this.InitialDelay = 400;
            this.RepeatInterval = 62;
        }

        [Description("Initial delay. Time in milliseconds between button press and first repeat action.")]
        [DefaultValue(400)]
        [Category("Enhanced")]
        public int InitialDelay { set; get; }

        [Category("Enhanced")]
        [Description("Repeat Interval. Repeat between each repeat action while button is hold pressed.")]
        [DefaultValue(62)]
        public int RepeatInterval { set; get; }

        private void InitializeComponent()
        {
            this.m_components = (IContainer)new Container();
            this.m_timerRepeater = new Timer(this.m_components);
            this.SuspendLayout();
            this.m_timerRepeater.Tick += new EventHandler(this.timerRepeater_Tick);
            this.ResumeLayout(false);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            this.m_mouseDownArgs = mevent;
            this.m_timerRepeater.Enabled = false;
            this.timerRepeater_Tick((object)null, EventArgs.Empty);
        }

        private void timerRepeater_Tick(object sender, EventArgs e)
        {
            base.OnMouseDown(this.m_mouseDownArgs);
            this.m_timerRepeater.Interval = !this.m_timerRepeater.Enabled ? this.InitialDelay : this.RepeatInterval;
            this.m_timerRepeater.Enabled = true;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            this.m_timerRepeater.Enabled = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (this.m_disposed)
                return;
            if (disposing)
            {
                if (this.m_components != null)
                    this.m_components.Dispose();
                this.m_timerRepeater.Dispose();
            }
            this.m_disposed = true;
            base.Dispose(disposing);
        }
    }
}

namespace ProXoft.WinForms
{
    public static class ControlExtension
    {
        private static Dictionary<Control, bool> draggables = new Dictionary<Control, bool>();
        private static Size mouseOffset;
        private static Point initialControlLocation;

        public static void Draggable(this Control control, bool enable)
        {
            if (enable)
            {
                if (draggables.ContainsKey(control))
                    return;
                draggables.Add(control, false);
                control.MouseDown += new MouseEventHandler(control_MouseDown);
                control.MouseUp += new MouseEventHandler(control_MouseUp);
                control.MouseMove += new MouseEventHandler(control_MouseMove);
            }
            else
            {
                if (!draggables.ContainsKey(control))
                    return;
                control.MouseDown -= new MouseEventHandler(control_MouseDown);
                control.MouseUp -= new MouseEventHandler(control_MouseUp);
                control.MouseMove -= new MouseEventHandler(control_MouseMove);
                draggables.Remove(control);
            }
        }

        private static void control_MouseDown(object sender, MouseEventArgs e)
        {
            mouseOffset = new Size(e.Location);
            draggables[(Control)sender] = true;
            initialControlLocation = ((Control)sender).Location;
        }

        private static void control_MouseUp(object sender, MouseEventArgs e) => draggables[(Control)sender] = false;

        private static void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (!draggables[(Control)sender])
                return;
            Point point = e.Location - mouseOffset;
            ((Control)sender).Left += point.X;
            ((Control)sender).Top += point.Y;
        }

        public static bool IsDragging(this Control control) => draggables.ContainsKey(control) && initialControlLocation != control.Location;
    }
}