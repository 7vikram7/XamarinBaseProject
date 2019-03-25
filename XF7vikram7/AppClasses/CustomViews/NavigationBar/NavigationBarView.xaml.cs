namespace XF7vikram7.AppClasses.CustomViews.NavigationBar
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using XF7vikram7.AppClasses.CustomViews.Base;
    using Xamarin.Forms;

    public partial class NavigationBarView : BaseView
    {
        #region Fields

        public static readonly BindableProperty LeftButtonCommandProperty =
            BindableProperty.Create(
                "LeftButtonCommand",
                typeof(ICommand),
                typeof(NavigationBarView),
                defaultValue: null);

        public static readonly BindableProperty RightButtonCommandProperty =
            BindableProperty.Create(
                "RightButtonCommand",
                typeof(ICommand),
                typeof(NavigationBarView),
                defaultValue: null);

        public static readonly BindableProperty InnerRightButtonCommandProperty =
            BindableProperty.Create(
                "InnerRightButtonCommand",
                typeof(ICommand),
                typeof(NavigationBarView),
                defaultValue: null);

        public static readonly BindableProperty LeftImageProperty =
            BindableProperty.Create(
                propertyName: "LeftImage",
                returnType: typeof(string),
                declaringType: typeof(NavigationBarView),
                defaultValue: string.Empty,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: LeftImagePropertyChanged);

        public static readonly BindableProperty RightImageProperty =
            BindableProperty.Create(
                propertyName: "RightImage",
                returnType: typeof(string),
                declaringType: typeof(NavigationBarView),
                defaultValue: string.Empty,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: RightImagePropertyChanged);

        public static readonly BindableProperty InnerRightImageProperty =
            BindableProperty.Create(
                propertyName: "InnerRightImage",
                returnType: typeof(string),
                declaringType: typeof(NavigationBarView),
                defaultValue: string.Empty,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: InnerRightImagePropertyChanged);

        public static readonly BindableProperty RightTextProperty =
            BindableProperty.Create(
                propertyName: "RightText",
                returnType: typeof(string),
                declaringType: typeof(NavigationBarView),
                defaultValue: string.Empty,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: RightTextPropertyChanged);

        public static readonly BindableProperty InnerRightTextProperty =
            BindableProperty.Create(
                propertyName: "InnerRightText",
                returnType: typeof(string),
                declaringType: typeof(NavigationBarView),
                defaultValue: string.Empty,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: InnerRightTextPropertyChanged);

        public static readonly BindableProperty TitleTextProperty =
            BindableProperty.Create(
                propertyName: "TitleText",
                returnType: typeof(string),
                declaringType: typeof(NavigationBarView),
                defaultValue: string.Empty,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: TitleTextPropertyChanged);

        #endregion

        #region Constructor

        public NavigationBarView()
        {
            this.InitializeComponent();

            TapGestureRecognizer leftGest = new TapGestureRecognizer();
            leftStackLayout.GestureRecognizers.Add(leftGest);
            leftGest.SetBinding(
                TapGestureRecognizer.CommandProperty,
                new Binding(
                    nameof(this.LeftButtonCommand),
                    source: this));
            leftGest.CommandParameter = this.leftStackLayout;

            TapGestureRecognizer rightGest = new TapGestureRecognizer();
            rightStackLayout.GestureRecognizers.Add(rightGest);
            rightGest.SetBinding(
                TapGestureRecognizer.CommandProperty,
                new Binding(
                    nameof(this.RightButtonCommand),
                    source: this));
            rightGest.CommandParameter = this.rightStackLayout;

            TapGestureRecognizer innerRightGest = new TapGestureRecognizer();
            innerRightStackLayout.GestureRecognizers.Add(innerRightGest);
            innerRightGest.SetBinding(
                TapGestureRecognizer.CommandProperty,
                new Binding(
                    nameof(this.InnerRightButtonCommand),
                    source: this));
            innerRightGest.CommandParameter = this.innerRightStackLayout;

            // Use this to set binding to command
            // leftButton.SetBinding(Button.CommandProperty, new Binding(nameof(this.LeftButtonCommand), source: this));
        }

        #endregion

        #region Properties

        public string LeftImage
        {
            get;
            set;
        }

        public string RightImage
        {
            get;
            set;
        }

        public string InnerRightImage
        {
            get;
            set;
        }

        public string RightText
        {
            get;
            set;
        }

        public string InnerRightText
        {
            get;
            set;
        }

        public string TitleText
        {
            get;
            set;
        }

        #endregion

        #region Events

        public ICommand LeftButtonCommand
        {
            get
            {
                return (ICommand)GetValue(LeftButtonCommandProperty);
            }

            set
            {
                this.SetValue(LeftButtonCommandProperty, value);
            }
        }

        public ICommand RightButtonCommand
        {
            get
            {
                return (ICommand)GetValue(RightButtonCommandProperty);
            }

            set
            {
                this.SetValue(RightButtonCommandProperty, value);
            }
        }

        public ICommand InnerRightButtonCommand
        {
            get
            {
                return (ICommand)GetValue(InnerRightButtonCommandProperty);
            }

            set
            {
                this.SetValue(InnerRightButtonCommandProperty, value);
            }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        private static void LeftImagePropertyChanged(
            BindableObject bindable,
            object oldValue,
            object newValue)
        {
            var control = (NavigationBarView)bindable;
            control.leftImage.Source = ImageSource.FromFile(newValue.ToString());
            if (newValue.ToString() != string.Empty)
            {
                control.leftImage.IsVisible = true;
            }
            else
            {
                control.leftImage.IsVisible = false;
            }
        }

        private static void RightTextPropertyChanged(
            BindableObject bindable,
            object oldValue,
            object newValue)
        {
            var control = (NavigationBarView)bindable;
            control.rightLabel.Text = newValue.ToString();
            if (newValue.ToString() != string.Empty)
            {
                control.rightLabel.IsVisible = true;
            }
            else
            {
                control.rightLabel.IsVisible = false;
            }
        }

        private static void RightImagePropertyChanged(
            BindableObject bindable,
            object oldValue,
            object newValue)
        {
            var control = (NavigationBarView)bindable;
            control.rightImage.Source = ImageSource.FromFile(newValue.ToString());
            if (newValue.ToString() != string.Empty)
            {
                control.rightImage.IsVisible = true;
            }
            else
            {
                control.rightImage.IsVisible = false;
            }
        }

        private static void InnerRightTextPropertyChanged(
            BindableObject bindable,
            object oldValue,
            object newValue)
        {
            var control = (NavigationBarView)bindable;
            control.innerRightLabel.Text = newValue.ToString();
            if (newValue.ToString() != string.Empty)
            {
                control.innerRightLabel.IsVisible = true;
            }
            else
            {
                control.innerRightLabel.IsVisible = false;
            }
        }

        private static void InnerRightImagePropertyChanged(
            BindableObject bindable,
            object oldValue,
            object newValue)
        {
            var control = (NavigationBarView)bindable;
            control.innerRightImage.Source = ImageSource.FromFile(newValue.ToString());
            if (newValue.ToString() != string.Empty)
            {
                control.innerRightImage.IsVisible = true;
            }
            else
            {
                control.innerRightImage.IsVisible = false;
            }
        }

        private static void TitleTextPropertyChanged(
            BindableObject bindable,
            object oldValue,
            object newValue)
        {
            var control = (NavigationBarView)bindable;
            control.titleLabel.Text = newValue.ToString();
            if (newValue.ToString() != string.Empty)
            {
                control.titleLabel.IsVisible = true;
            }
            else
            {
                control.titleLabel.IsVisible = false;
            }
        }
        #endregion
    }
}
