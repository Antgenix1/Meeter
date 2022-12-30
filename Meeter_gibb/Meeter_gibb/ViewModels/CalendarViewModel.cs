using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DevExpress.Maui.Editors;
using Meeter_gibb.Models;

namespace Meeter_gibb.ViewModels
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        DateTime displayDate;
        DateTime? selectedDate;
        DXCalendarViewType activeViewType;
        bool isHolidaysAndObservancesListVisible;
        IEnumerable<SpecialDate> specialDates;

        public CalendarViewModel()
        {
            DisplayDate = DateTime.Today;
            UpdateHolidaysAndObservancesListVisible();
        }

        public IEnumerable<SpecialDate> SpecialDates
        {
            get => specialDates;
            set
            {
                if (specialDates == value)
                    return;

                specialDates = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime DisplayDate
        {
            get => displayDate;
            set
            {
                if (displayDate == value)
                    return;

                displayDate = value;
                UpdateCurrentCalendarIfNeeded();
                SpecialDates = USCalendar.GetSpecialDatesForMonth(DisplayDate.Month);
                NotifyPropertyChanged();
            }
        }

        public DateTime? SelectedDate
        {
            get => selectedDate;
            set
            {
                if (selectedDate == value)
                    return;

                selectedDate = value;
                NotifyPropertyChanged();
            }
        }

        public DXCalendarViewType ActiveViewType
        {
            get => activeViewType;
            set
            {
                if (activeViewType == value)
                    return;

                activeViewType = value;
                UpdateHolidaysAndObservancesListVisible();
                NotifyPropertyChanged();
            }
        }

        public bool IsHolidaysAndObservancesListVisible
        {
            get => isHolidaysAndObservancesListVisible;
            set
            {
                if (isHolidaysAndObservancesListVisible == value)
                    return;

                isHolidaysAndObservancesListVisible = value;
                NotifyPropertyChanged();
            }
        }

        USCalendar USCalendar { get; set; }

        public SpecialDate TryFindSpecialDate(DateTime date)
        {
            return SpecialDates.FirstOrDefault(x => x.Date == date);
        }

        void UpdateHolidaysAndObservancesListVisible()
        {
            IsHolidaysAndObservancesListVisible = ActiveViewType == DXCalendarViewType.Month;
        }

        void UpdateCurrentCalendarIfNeeded()
        {
            if (USCalendar == null || USCalendar.Year != DisplayDate.Year)
                USCalendar = new USCalendar(DisplayDate.Year);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

