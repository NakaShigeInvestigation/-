using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace 矩形選択
{
    [TemplatePart(Name = "top", Type = typeof(Thumb))]
    [TemplatePart(Name = "left", Type = typeof(Thumb))]
    [TemplatePart(Name = "right", Type = typeof(Thumb))]
    [TemplatePart(Name = "bottom", Type = typeof(Thumb))]

    public class SelectableRect : Thumb
    {
        static SelectableRect()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SelectableRect), new FrameworkPropertyMetadata(typeof(SelectableRect)));
        }

        public SelectableRect()
        {
            this.Background = Brushes.Transparent;
            this.BorderThickness = new Thickness(1);
            this.BorderBrush = new SolidColorBrush(Colors.Gray);
            this.Margin = new Thickness(0, 0, 0, 0);
            this.Width = 200;
            this.Height = 200;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Thumb top = GetTemplateChild("top") as Thumb;
            top.DragStarted += new DragStartedEventHandler(Thumb_DragStarted);
            top.DragCompleted += new DragCompletedEventHandler(Thumb_DragCompleted);
            top.DragDelta += new DragDeltaEventHandler(top_DragDelta);
            Thumb left = GetTemplateChild("left") as Thumb;
            left.DragStarted += new DragStartedEventHandler(Thumb_DragStarted);
            left.DragCompleted += new DragCompletedEventHandler(Thumb_DragCompleted);
            left.DragDelta += new DragDeltaEventHandler(left_DragDelta);
            Thumb right = GetTemplateChild("right") as Thumb;
            right.DragStarted += new DragStartedEventHandler(Thumb_DragStarted);
            right.DragCompleted += new DragCompletedEventHandler(Thumb_DragCompleted);
            right.DragDelta += new DragDeltaEventHandler(right_DragDelta);
            Thumb bottom = GetTemplateChild("bottom") as Thumb;
            bottom.DragStarted += new DragStartedEventHandler(Thumb_DragStarted);
            bottom.DragCompleted += new DragCompletedEventHandler(Thumb_DragCompleted);
            bottom.DragDelta += new DragDeltaEventHandler(bottom_DragDelta);

            this.DragStarted += new DragStartedEventHandler(Thumb_DragStarted);
            this.DragCompleted += new DragCompletedEventHandler(Thumb_DragCompleted);
            this.DragDelta += new DragDeltaEventHandler(SelectableRect_DragDelta);
        }
        void Thumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            e.Handled = true;
        }
        void Thumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            e.Handled = true;
        }
        void SelectableRect_DragDelta(object sender, DragDeltaEventArgs e)
        {
            this.Margin = new Thickness(this.Margin.Left + e.HorizontalChange, this.Margin.Top + e.VerticalChange, 0, 0);
            e.Handled = true;
        }
        void top_DragDelta(object sender, DragDeltaEventArgs e)
        {
            this.Margin = new Thickness(this.Margin.Left, this.Margin.Top + e.VerticalChange, 0, 0);
            this.Height -= e.VerticalChange;
            e.Handled = true;
        }
        void left_DragDelta(object sender, DragDeltaEventArgs e)
        {
            this.Margin = new Thickness(this.Margin.Left + e.HorizontalChange, this.Margin.Top, 0, 0);
            this.Width -= e.HorizontalChange;
            e.Handled = true;
        }
        void right_DragDelta(object sender, DragDeltaEventArgs e)
        {
            this.Width += e.HorizontalChange;
            e.Handled = true;
        }
        void bottom_DragDelta(object sender, DragDeltaEventArgs e)
        {
            this.Height += e.VerticalChange;
            e.Handled = true;
        }
    }

}
