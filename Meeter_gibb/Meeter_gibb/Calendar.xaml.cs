using System;
using DevExpress.Maui.Editors;
using Meeter_gibb.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Meeter_gibb.Models;

namespace Meeter_gibb
{
    public partial class Calendar : ContentPage
    {
        public static readonly BindablePropertyKey OrientationPropertyKey = BindableProperty.CreateReadOnly("Orientation", typeof(StackOrientation), typeof(MainPage), StackOrientation.Vertical);
        public static readonly BindableProperty OrientationProperty = OrientationPropertyKey.BindableProperty;
        public StackOrientation Orientation => (StackOrientation)GetValue(OrientationProperty);

        public Calendar()
        {
            InitializeComponent();
            ViewModel = new CalendarViewModel();
            BindingContext = ViewModel;
        }

        CalendarViewModel ViewModel { get; }

        void CustomDayCellAppearance(object sender, CustomSelectableCellAppearanceEventArgs e)
        {
            if (e.Date == DateTime.Today)
                return;

            if (ViewModel.SelectedDate != null && e.Date == ViewModel.SelectedDate.Value)
                return;

            SpecialDate specialDate = ViewModel.TryFindSpecialDate(e.Date);
            if (specialDate == null)
                return;

            e.FontAttributes = FontAttributes.Bold;
            Color textColor;
            if (specialDate.IsHoliday)
            {
                textColor = (Color)Resources["CalendarViewHolidayTextColor"];
                e.EllipseBackgroundColor = Color.FromRgba(textColor.Red, textColor.Green, textColor.Blue, 0.25);
                e.TextColor = textColor;

                return;
            }
            textColor = (Color)Resources["CalendarViewTextColor"];
            e.EllipseBackgroundColor = Color.FromRgba(textColor.Red, textColor.Green, textColor.Blue, 0.15);
            e.TextColor = textColor;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            SetValue(OrientationPropertyKey, width > height ? StackOrientation.Horizontal : StackOrientation.Vertical);
        }
    }
}