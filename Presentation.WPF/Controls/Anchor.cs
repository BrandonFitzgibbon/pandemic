﻿using Engine.Implementations;
using Presentation.WPF.Implementations;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Presentation.WPF.Controls
{
    [TemplatePart(Name = "PART_GlowBorder", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "PART_ContentBorder", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "PART_CenterContent", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "PART_UpperLeftContent", Type = typeof(FrameworkElement))]
    public class Anchor : Control
    {
        private Border glowBorder;
        private Border contentBorder;

        private DoubleAnimation opacityAnimation;

        static Anchor()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Anchor), new FrameworkPropertyMetadata(typeof(Anchor)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            opacityAnimation = new DoubleAnimation();

            glowBorder = (Border)Template.FindName("PART_GlowBorder", this);
            contentBorder = (Border)Template.FindName("PART_ContentBorder", this);
            ContentPresenter upperLeftContentPresenter = (ContentPresenter)Template.FindName("PART_UpperLeftContent", this);

            glowBorder.Padding = new Thickness(1.1 * contentBorder.Padding.Left, 1.1 * contentBorder.Padding.Top, 1.1 * contentBorder.Padding.Right, 1.1 * contentBorder.Padding.Bottom);

            contentBorder.PreviewMouseLeftButtonDown += ContentMouseLeftButtonDown;
            contentBorder.MouseRightButtonUp += ContentMouseRightButtonUp;
            contentBorder.MouseEnter += ContentMouseEnter;
            contentBorder.MouseLeave += ContentMouseLeave;

            upperLeftContentPresenter.MouseLeftButtonDown += UpperLeftContentPresenter_MouseLeftButtonDown;
        }

        private void UpperLeftContentPresenter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContentPresenter cp = (ContentPresenter)sender;
            if(cp.IsMouseOver)
            {
                if (!IsUpperLeftContentSelected)
                    IsUpperLeftContentSelected = true;
                else if (IsUpperLeftContentSelected)
                    IsUpperLeftContentSelected = false;
            }
        }

        private void ContentMouseLeave(object sender, MouseEventArgs e)
        {
            MouseOverItem = null;
        }

        private void ContentMouseEnter(object sender, MouseEventArgs e)
        {
            MouseOverItem = Item;
        }

        private void ContentMouseRightButtonUp(object sender, MouseEventArgs e)
        {
            if(IsMouseOver && Command != null)
            {
                Command.Execute(CommandParameter);
            }
        }

        private void ContentMouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            if(IsMouseOver)
            {
                if (IsSelected)
                {
                    IsSelected = false;
                    SelectedItem = null;
                }
                else if (!IsSelected)
                {
                    IsSelected = true;
                    SelectedItem = Item;
                }
            }
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            protected set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(Anchor), new PropertyMetadata(false));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Anchor), new PropertyMetadata(new CornerRadius(0)));


        public SolidColorBrush GlowBrush
        {
            get { return (SolidColorBrush)GetValue(GlowBrushProperty); }
            set { SetValue(GlowBrushProperty, value); }
        }

        public static readonly DependencyProperty GlowBrushProperty =
            DependencyProperty.Register("GlowBrush", typeof(SolidColorBrush), typeof(Anchor), new PropertyMetadata(System.Windows.Media.Brushes.Transparent));

        #region ContentDP

        public object UpperLeftContent
        {
            get { return (object)GetValue(UpperLeftContentProperty); }
            set { SetValue(UpperLeftContentProperty, value); }
        }

        public static readonly DependencyProperty UpperLeftContentProperty =
            DependencyProperty.Register("UpperLeftContent", typeof(object), typeof(Anchor), new PropertyMetadata());


        public DataTemplate UpperLeftContentTemplate
        {
            get { return (DataTemplate)GetValue(UpperLeftContentTemplateProperty); }
            set { SetValue(UpperLeftContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty UpperLeftContentTemplateProperty =
            DependencyProperty.Register("UpperLeftContentTemplate", typeof(DataTemplate), typeof(Anchor), new PropertyMetadata());

        public object UpperRightContent
        {
            get { return (object)GetValue(UpperRightContentProperty); }
            set { SetValue(UpperRightContentProperty, value); }
        }

        public static readonly DependencyProperty UpperRightContentProperty =
            DependencyProperty.Register("UpperRightContent", typeof(object), typeof(Anchor), new PropertyMetadata());

        public DataTemplate UpperRightContentTemplate
        {
            get { return (DataTemplate)GetValue(UpperRightContentTemplateProperty); }
            set { SetValue(UpperRightContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty UpperRightContentTemplateProperty =
            DependencyProperty.Register("UpperRightContentTemplate", typeof(DataTemplate), typeof(Anchor), new PropertyMetadata());

        public object BottomLeftContent
        {
            get { return (object)GetValue(BottomLeftContentProperty); }
            set { SetValue(BottomLeftContentProperty, value); }
        }

        public static readonly DependencyProperty BottomLeftContentProperty =
            DependencyProperty.Register("BottomLeftContent", typeof(object), typeof(Anchor), new PropertyMetadata());

        public DataTemplate BottomLeftContentTemplate
        {
            get { return (DataTemplate)GetValue(BottomLeftContentTemplateProperty); }
            set { SetValue(BottomLeftContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty BottomLeftContentTemplateProperty =
            DependencyProperty.Register("BottomLeftContentTemplate", typeof(DataTemplate), typeof(Anchor), new PropertyMetadata());

        public object BottomRightContent
        {
            get { return (object)GetValue(BottomRightContentProperty); }
            set { SetValue(BottomRightContentProperty, value); }
        }

        public static readonly DependencyProperty BottomRightContentProperty =
            DependencyProperty.Register("BottomRightContent", typeof(object), typeof(Anchor), new PropertyMetadata());

        public DataTemplate BottomRightContentTemplate
        {
            get { return (DataTemplate)GetValue(BottomRightContentTemplateProperty); }
            set { SetValue(BottomRightContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty BottomRightContentTemplateProperty =
            DependencyProperty.Register("BottomRightContentTemplate", typeof(DataTemplate), typeof(Anchor), new PropertyMetadata());

        public object CenterContent
        {
            get { return (object)GetValue(CenterContentProperty); }
            set { SetValue(CenterContentProperty, value); }
        }

        public static readonly DependencyProperty CenterContentProperty =
            DependencyProperty.Register("CenterContent", typeof(object), typeof(Anchor), new PropertyMetadata());

        public DataTemplate CenterContentTemplate
        {
            get { return (DataTemplate)GetValue(CenterContentTemplateProperty); }
            set { SetValue(CenterContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty CenterContentTemplateProperty =
            DependencyProperty.Register("CenterContentTemplate", typeof(DataTemplate), typeof(Anchor), new PropertyMetadata());

        public object TopCenterContent
        {
            get { return (object)GetValue(TopCenterContentProperty); }
            set { SetValue(TopCenterContentProperty, value); }
        }

        public static readonly DependencyProperty TopCenterContentProperty =
            DependencyProperty.Register("TopCenterContent", typeof(object), typeof(Anchor), new PropertyMetadata());

        public DataTemplate TopCenterContentTemplate
        {
            get { return (DataTemplate)GetValue(TopCenterContentTemplateProperty); }
            set { SetValue(TopCenterContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty TopCenterContentTemplateProperty =
            DependencyProperty.Register("TopCenterContentTemplate", typeof(DataTemplate), typeof(Anchor), new PropertyMetadata());

        public object BottomCenterContent
        {
            get { return (object)GetValue(BottomCenterContentProperty); }
            set { SetValue(BottomCenterContentProperty, value); }
        }

        public static readonly DependencyProperty BottomCenterContentProperty =
            DependencyProperty.Register("BottomCenterContent", typeof(object), typeof(Anchor), new PropertyMetadata());

        public DataTemplate BottomCenterContentTemplate
        {
            get { return (DataTemplate)GetValue(BottomCenterContentTemplateProperty); }
            set { SetValue(BottomCenterContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty BottomCenterContentTemplateProperty =
            DependencyProperty.Register("BottomCenterContentTemplate", typeof(DataTemplate), typeof(Anchor), new PropertyMetadata());

        #endregion

        public bool IsUpperLeftContentSelected
        {
            get { return (bool)GetValue(IsUpperLeftContentSelectedProperty); }
            set { SetValue(IsUpperLeftContentSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsUpperLeftContentSelectedProperty =
            DependencyProperty.Register("IsUpperLeftContentSelected", typeof(bool), typeof(Anchor), new PropertyMetadata());


        public object Item
        {
            get { return (object)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register("Item", typeof(object), typeof(Anchor), new PropertyMetadata());

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(Anchor), new PropertyMetadata());

        public object MouseOverItem
        {
            get { return (object)GetValue(MouseOverItemProperty); }
            set { SetValue(MouseOverItemProperty, value); }
        }

        public static readonly DependencyProperty MouseOverItemProperty =
            DependencyProperty.Register("MouseOverItem", typeof(object), typeof(Anchor), new PropertyMetadata());

        public bool IsSelectable
        {
            get { return (bool)GetValue(IsSelectableProperty); }
            set { SetValue(IsSelectableProperty, value); }
        }

        public static readonly DependencyProperty IsSelectableProperty =
            DependencyProperty.Register("IsSelectable", typeof(bool), typeof(Anchor), new PropertyMetadata(true));



        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(Anchor), new PropertyMetadata());

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(Anchor), new PropertyMetadata());

        public bool IsCenterContentEnabled
        {
            get { return (bool)GetValue(IsCenterContentEnabledProperty); }
            set { SetValue(IsCenterContentEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsCenterContentEnabledProperty =
            DependencyProperty.Register("IsCenterContentEnabled", typeof(bool), typeof(Anchor), new PropertyMetadata(true));

        public bool FlashingOnMouseOver
        {
            get { return (bool)GetValue(FlashingOnMouseOverProperty); }
            set { SetValue(FlashingOnMouseOverProperty, value); }
        }

        public static readonly DependencyProperty FlashingOnMouseOverProperty =
            DependencyProperty.Register("FlashingOnMouseOver", typeof(bool), typeof(Anchor), new PropertyMetadata(false, new PropertyChangedCallback(OnFlashingOnMouseOverChange)));

        public static void OnFlashingOnMouseOverChange(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            Anchor anchor = (Anchor)o;
            if ((bool)e.NewValue)
            {
                anchor.contentBorder.MouseEnter += anchor.FlashingEnter;
                anchor.contentBorder.MouseLeave += anchor.FlashingLeave;               
            }
            else
            {
                anchor.contentBorder.MouseEnter -= anchor.FlashingEnter;
                anchor.contentBorder.MouseLeave -= anchor.FlashingLeave;
            }
        }

        private Path p;

        private void FlashingEnter(object sender, MouseEventArgs e)
        {
            opacityAnimation.From = contentBorder.Opacity;
            opacityAnimation.To = 0;
            opacityAnimation.RepeatBehavior = RepeatBehavior.Forever;
            opacityAnimation.AutoReverse = true;
            opacityAnimation.Duration = TimeSpan.FromMilliseconds(750);
            contentBorder.BeginAnimation(Border.OpacityProperty, opacityAnimation);

            Canvas canvas = (Canvas)Parent;
            NodeViewModel nvm = (NodeViewModel)DataContext;

            foreach (Anchor child in canvas.Children)
            {
                if (child.Item == nvm.BoardViewModel.CurrentPlayerViewModel.Location)
                {
                    Point origin = new Point(Canvas.GetLeft(child), Canvas.GetTop(child));
                    Point dest = new Point(Canvas.GetLeft(this), Canvas.GetTop(this));
                    Point bez1;
                    Point bez2;

                    if (Math.Abs(dest.X - origin.X) > Math.Abs(dest.Y - origin.Y))
                    {
                        bez1 = new Point(origin.X + 0.4 * (dest.X - origin.X), origin.Y + 0.5 * (dest.Y - origin.Y));
                        bez2 = new Point(origin.X + 0.6 * (dest.X - origin.X), origin.Y + -0.5 * (dest.Y - origin.Y));
                    }
                    else
                    {
                        bez1 = new Point(origin.X + 0.5 * (dest.X - origin.X), origin.Y + 0.4 * (dest.Y - origin.Y));
                        bez2 = new Point(origin.X + -0.5 * (dest.X - origin.X), origin.Y + 0.6 * (dest.Y - origin.Y));
                    }

                    p = new Path() { Stroke = Brushes.White, StrokeThickness = 4, StrokeDashArray = new DoubleCollection() { 5 } };
                    PathGeometry pg = new PathGeometry();
                    PathFigure pf = new PathFigure() { StartPoint = origin };
                    BezierSegment bezSegment = new BezierSegment(bez1, bez2, dest, true);
                    pf.Segments.Add(bezSegment);
                    pg.Figures.Add(pf);
                    p.Data = pg;

                    p.BeginAnimation(Path.OpacityProperty, opacityAnimation);

                    break;
                }
            }

            canvas.Children.Add(p);
        }

        private void FlashingLeave(object sender, MouseEventArgs e)
        {
            contentBorder.BeginAnimation(Border.OpacityProperty, null);
            Canvas canvas = (Canvas)Parent;
            canvas.Children.Remove(p);
        }
    }
}
