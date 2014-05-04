using System;
using System.ComponentModel;
using System.Windows;
using ICSharpCode.AvalonEdit;

namespace WPFPresentation
{
    public class MvvmTextEditor : TextEditor, INotifyPropertyChanged
    {
        public static DependencyProperty CaretOffsetProperty =
            DependencyProperty.Register("CaretOffset", typeof(int), typeof(MvvmTextEditor),
            // binding changed callback: set value of underlying property
            new PropertyMetadata((obj, args) =>
            {
                MvvmTextEditor target = (MvvmTextEditor)obj;
                target.CaretOffset = (int)args.NewValue;
            })
        );

        public static DependencyProperty TextProperty =
           DependencyProperty.Register("Text", typeof(string), typeof(MvvmTextEditor),
            // binding changed callback: set value of underlying property
           new PropertyMetadata((obj, args) =>
           {
               MvvmTextEditor target = (MvvmTextEditor)obj;
               target.Text = (string)args.NewValue;
           })
       );

       // public static DependencyProperty FontSizeProperty =
       //    DependencyProperty.Register("FontSize", typeof(double), typeof(MvvmTextEditor),
       //     // binding changed callback: set value of underlying property
       //    new PropertyMetadata((obj, args) =>
       //    {
       //        MvvmTextEditor target = (MvvmTextEditor)obj;
       //        target.FontSize = (double)args.NewValue;
       //    })
       //);

        //public new double FontSize
        //{
        //    get { return base.FontSize; }
        //    set { base.FontSize = value; }
        //}

        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public new int CaretOffset
        {
            get { return base.CaretOffset; }
            set { base.CaretOffset = value; }
        }

        public int Length { get { return base.Text.Length; } }

        protected override void OnTextChanged(EventArgs e)
        {
            RaisePropertyChanged("Length");
            base.OnTextChanged(e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
