using System.Collections;
using YmdDateSelector.Maui.Utils;

namespace YmdDateSelector.Maui.Views;

public partial class YmdDateSelector : ContentView
{
    public static readonly BindableProperty YearItemsSourceProperty =
            BindableProperty.Create(nameof(YearItemsSource), typeof(IList), typeof(YmdDateSelector));

    public static readonly BindableProperty MonthItemsSourceProperty =
        BindableProperty.Create(nameof(MonthItemsSource), typeof(IList), typeof(YmdDateSelector));

    public static readonly BindableProperty DayItemsSourceProperty =
        BindableProperty.Create(nameof(DayItemsSource), typeof(IList), typeof(YmdDateSelector));

    public static readonly BindableProperty YearSelectedIndexProperty =
        BindableProperty.Create(nameof(YearSelectedIndex), typeof(int), typeof(YmdDateSelector), -1, BindingMode.TwoWay,
            propertyChanged: OnSelectedYearIndexChanged);

    public static readonly BindableProperty MonthSelectedIndexProperty =
        BindableProperty.Create(nameof(MonthSelectedIndex), typeof(int), typeof(YmdDateSelector), -1, BindingMode.TwoWay,
            propertyChanged: OnSelectedMonthIndexChanged);

    public static readonly BindableProperty DaySelectedIndexProperty =
        BindableProperty.Create(nameof(DaySelectedIndex), typeof(int), typeof(YmdDateSelector), -1, BindingMode.TwoWay,
            propertyChanged: OnSelectedDayIndexChanged);

    public static readonly BindableProperty SelectedYearProperty =
        BindableProperty.Create(nameof(SelectedYear), typeof(object), typeof(YmdDateSelector), null, BindingMode.TwoWay,
            propertyChanged: OnSelectedYearItemChanged);

    public static readonly BindableProperty SelectedMonthProperty =
        BindableProperty.Create(nameof(SelectedMonth), typeof(object), typeof(YmdDateSelector), null, BindingMode.TwoWay,
            propertyChanged: OnSelectedMonthItemChanged);

    public static readonly BindableProperty SelectedDayProperty =
        BindableProperty.Create(nameof(SelectedDay), typeof(object), typeof(YmdDateSelector), null, BindingMode.TwoWay,
            propertyChanged: OnSelectedDayItemChanged);

    public static readonly BindableProperty DateProperty =
        BindableProperty.Create(nameof(Date), typeof(DateTime), typeof(YmdDateSelector), DateTime.Today, BindingMode.TwoWay);

    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(nameof(FontSize), typeof(string), typeof(YmdDateSelector), default(string), BindingMode.TwoWay);

    public static readonly BindableProperty FontFamilyProperty =
        BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(YmdDateSelector), default(string), BindingMode.TwoWay);

    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(YmdDateSelector), default(Color), BindingMode.TwoWay);

    public static readonly BindableProperty TitleColorProperty =
        BindableProperty.Create(nameof(TitleColor), typeof(Color), typeof(YmdDateSelector), default(Color), BindingMode.TwoWay);

    public static readonly BindableProperty MinimumDateProperty =
        BindableProperty.Create(nameof(MinimumDate), typeof(DateTime?), typeof(YmdDateSelector), null, BindingMode.TwoWay,
            propertyChanged: OnMinimumDateSelected);

    public static readonly BindableProperty MaximumDateProperty =
        BindableProperty.Create(nameof(MaximumDate), typeof(DateTime?), typeof(YmdDateSelector), null, BindingMode.TwoWay,
            propertyChanged: OnMaximumDateSelected);

    public IList? YearItemsSource
    {
        get => (IList)GetValue(YearItemsSourceProperty);
        set => SetValue(YearItemsSourceProperty, value);
    }

    public IList? MonthItemsSource
    {
        get => (IList)GetValue(MonthItemsSourceProperty);
        set => SetValue(MonthItemsSourceProperty, value);
    }

    public IList? DayItemsSource
    {
        get => (IList)GetValue(DayItemsSourceProperty);
        set => SetValue(DayItemsSourceProperty, value);
    }

    public int YearSelectedIndex
    {
        get => (int)GetValue(YearSelectedIndexProperty);
        set => SetValue(YearSelectedIndexProperty, value);
    }

    public int MonthSelectedIndex
    {
        get => (int)GetValue(MonthSelectedIndexProperty);
        set => SetValue(MonthSelectedIndexProperty, value);
    }

    public int DaySelectedIndex
    {
        get => (int)GetValue(DaySelectedIndexProperty);
        set => SetValue(DaySelectedIndexProperty, value);
    }

    public object? SelectedYear
    {
        get => (object)GetValue(SelectedYearProperty);
        set => SetValue(SelectedYearProperty, value);
    }

    public object? SelectedMonth
    {
        get => (object)GetValue(SelectedMonthProperty);
        set => SetValue(SelectedMonthProperty, value);
    }

    public object? SelectedDay
    {
        get => (object)GetValue(SelectedDayProperty);
        set => SetValue(SelectedDayProperty, value);
    }

    /// <summary>
    /// Gets/sets the font size of the picker
    /// </summary>
    public string FontSize
    {
        get => (string)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    /// <summary>
    /// Gets/sets the font family of the picker 
    /// </summary>
    public string FontFamily
    {
        get => (string)GetValue(FontFamilyProperty);
        set => SetValue(FontFamilyProperty, value);
    }

    /// <summary>
    /// Gets/sets the text color for the picker
    /// </summary>
    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    /// <summary>
    /// Gets/sets the text color for the picker title/label
    /// </summary>
    public Color TitleColor
    {
        get => (Color)GetValue(TitleColorProperty);
        set => SetValue(TitleColorProperty, value);
    }

    private DateTime? Date
    {
        get => (DateTime)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }

    /// <summary>
    /// Gets/sets the lowest date selectable
    /// </summary>
    public DateTime? MinimumDate
    {
        get => (DateTime?)GetValue(MinimumDateProperty);
        set => SetValue(MinimumDateProperty, value);
    }

    /// <summary>
    /// Gets/sets the highest date selectable
    /// </summary>
    public DateTime? MaximumDate
    {
        get => (DateTime?)GetValue(MaximumDateProperty);
        set => SetValue(MaximumDateProperty, value);
    }

    public event EventHandler? YearSelectedIndexChanged;

    public event EventHandler? MonthSelectedIndexChanged;

    public event EventHandler? DaySelectedIndexChanged;

    /// <summary>
    /// Event raised after a date is selected
    /// </summary>
    public event EventHandler? DateSelected;

    public YmdDateSelector()
	{
		InitializeComponent();

        // ItemsSource property binding
        YearPicker.SetBinding(Picker.ItemsSourceProperty, new Binding(nameof(YearItemsSource), source: this));

        MonthPicker.SetBinding(Picker.ItemsSourceProperty, new Binding(nameof(MonthItemsSource), source: this));

        DayPicker.SetBinding(Picker.ItemsSourceProperty, new Binding(nameof(DayItemsSource), source: this));

        // Selected Index
        YearPicker.SetBinding(Picker.SelectedIndexProperty, new Binding(nameof(YearSelectedIndex), source: this));

        MonthPicker.SetBinding(Picker.SelectedIndexProperty, new Binding(nameof(MonthSelectedIndex), source: this));

        DayPicker.SetBinding(Picker.SelectedIndexProperty, new Binding(nameof(DaySelectedIndex), source: this));

        // Selected Item
        YearPicker.SetBinding(Picker.SelectedItemProperty, new Binding(nameof(SelectedYear), source: this));

        MonthPicker.SetBinding(Picker.SelectedItemProperty, new Binding(nameof(SelectedMonth), source: this));

        DayPicker.SetBinding(Picker.SelectedItemProperty, new Binding(nameof(SelectedDay), source: this));

        // Font Size property binding
        YearPicker.SetBinding(Picker.FontSizeProperty, new Binding(nameof(FontSize), source: this));
        MonthPicker.SetBinding(Picker.FontSizeProperty, new Binding(nameof(FontSize), source: this));
        DayPicker.SetBinding(Picker.FontSizeProperty, new Binding(nameof(FontSize), source: this));

        // Font Family property binding
        YearPicker.SetBinding(Picker.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
        MonthPicker.SetBinding(Picker.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
        DayPicker.SetBinding(Picker.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));

        // Picker Text color property binding
        YearPicker.SetBinding(Picker.TextColorProperty, new Binding(nameof(TextColor), source: this));
        MonthPicker.SetBinding(Picker.TextColorProperty, new Binding(nameof(TextColor), source: this));
        YearPicker.SetBinding(Picker.TextColorProperty, new Binding(nameof(TextColor), source: this));

        // Picker Text color property binding
        YearPicker.SetBinding(Picker.TitleColorProperty, new Binding(nameof(TitleColor), source: this));
        MonthPicker.SetBinding(Picker.TitleColorProperty, new Binding(nameof(TitleColor), source: this));
        DayPicker.SetBinding(Picker.TitleColorProperty, new Binding(nameof(TitleColor), source: this));

        YearItemsSource = DateUtil.GetYears();

        MonthItemsSource = DateUtil.MonthNames;

        MonthPicker.SelectedIndexChanged += MonthPicker_MonthSelectionChanged;

        YearPicker.SelectedIndexChanged += YearPicker_SelectionChanged;
    }

    private void UpdateSelectedYearIndex(object selectedItem)
    {
        if (YearItemsSource == null) return;

        YearSelectedIndex = YearItemsSource.IndexOf(selectedItem);
    }

    private void UpdateSelectedMonthIndex(object selectedItem)
    {
        if (MonthItemsSource == null) return;

        MonthSelectedIndex = MonthItemsSource.IndexOf(selectedItem);
    }

    private void UpdateSelectedDayIndex(object selectedItem)
    {
        if (DayItemsSource == null) return;

        DaySelectedIndex = DayItemsSource.IndexOf(selectedItem);
    }

    private void UpdateSelectedYearItem(int index)
    {
        if (index == -1)
        {
            SelectedYear = null;

            return;
        }

        if (YearItemsSource == null) return;

        SelectedYear = YearItemsSource[index];

        YearPicker.Title = SelectedYear!.ToString();

        SetDate();
    }

    private void UpdateSelectedMonthItem(int index)
    {
        try
        {
            if (SelectedYear == null)
            {
                SelectedMonth = null;

                return;
            }

            if (index == -1)
            {
                SelectedMonth = null;

                return;
            }

            if (MonthItemsSource != null)
            {
                SelectedMonth = MonthItemsSource[index];

                MonthPicker.Title = SelectedMonth.ToString();

                SetDate();

                //Reset Day
                if (SelectedDay != null && DayItemsSource != null)
                {
                    if (Convert.ToInt32(SelectedDay) > DayItemsSource.Count)
                    {
                        SelectedDay = null;

                        DaySelectedIndex = -1;

                        DayPicker.Title = "Day";
                    }
                }

                return;
            }
        }
        catch (Exception)
        {
            //
        }
    }

    private void UpdateSelectedDayItem(int index)
    {
        if (SelectedMonth == null)
        {
            SelectedDay = null;

            return;
        }

        if (index == -1)
        {
            SelectedDay = null;

            return;
        }

        if (DayItemsSource != null)
        {
            SelectedDay = DayItemsSource[index];

            DayPicker.Title = SelectedDay!.ToString();

            SetDate();

            DateSelected?.Invoke(this, EventArgs.Empty);
        }
    }

    private void SetMinimumDate(DateTime? minimumDate)
    {
        if (minimumDate == null) return;

        MinimumDate = minimumDate;

        SetYearItems();
    }

    private void SetMaximumDate(DateTime? maximumDate)
    {
        if (maximumDate == null) return;

        MaximumDate = maximumDate;

        SetYearItems();
    }

    private void SetYearItems()
    {
        YearItemsSource = DateUtil.GetYears(MinimumDate.GetValueOrDefault().Year, MaximumDate.GetValueOrDefault().Year);

        MonthItemsSource = DateUtil.GetFilteredMonths(MinimumDate.GetValueOrDefault().Month);
    }

    public static void OnSelectedYearIndexChanged(object bindable, object oldValue, object newValue)
    {
        var picker = (YmdDateSelector)bindable;

        picker.UpdateSelectedYearItem(picker.YearSelectedIndex);

        picker.YearSelectedIndexChanged?.Invoke(bindable, EventArgs.Empty);
    }

    public static void OnSelectedMonthIndexChanged(object bindable, object oldValue, object newValue)
    {
        var picker = (YmdDateSelector)bindable;

        picker.UpdateSelectedMonthItem(picker.MonthSelectedIndex);

        picker.MonthSelectedIndexChanged?.Invoke(bindable, EventArgs.Empty);
    }

    public static void OnSelectedDayIndexChanged(object bindable, object oldValue, object newValue)
    {
        var picker = (YmdDateSelector)bindable;

        picker.UpdateSelectedDayItem(picker.DaySelectedIndex);

        picker.DaySelectedIndexChanged?.Invoke(bindable, EventArgs.Empty);
    }

    public static void OnSelectedYearItemChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var picker = (YmdDateSelector)bindable;

        picker.UpdateSelectedYearIndex(newValue);
    }

    public static void OnSelectedMonthItemChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var picker = (YmdDateSelector)bindable;

        picker.UpdateSelectedMonthIndex(newValue);
    }

    public static void OnSelectedDayItemChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var picker = (YmdDateSelector)bindable;

        picker.UpdateSelectedDayIndex(newValue);
    }

    public static void OnMinimumDateSelected(BindableObject bindable, object oldValue, object newValue)
    {
        var picker = (YmdDateSelector)bindable;

        picker.SetMinimumDate(DateTime.Parse(newValue.ToString()));
    }

    public static void OnMaximumDateSelected(BindableObject bindable, object oldValue, object newValue)
    {
        var picker = (YmdDateSelector)bindable;

        picker.SetMaximumDate(DateTime.Parse(newValue.ToString()));
    }

    private void MonthPicker_MonthSelectionChanged(object sender, EventArgs e)
    {
        try
        {
            if (SelectedMonth == null) return;

            var year = Convert.ToInt32(SelectedYear?.ToString());

            var month = Convert.ToInt32(DateUtil.GetMonthIndex((string)SelectedMonth).ToString());

            if (MinimumDate != null && MaximumDate != null)
            {
                ResetDay();

                if (year == MinimumDate.Value.Year && month == MinimumDate.Value.Month)
                {
                    ResetDay();

                    DayItemsSource = DateUtil.GetFilteredDays(DateUtil.GetMonthIndex(SelectedMonth.ToString()).ToString(), MinimumDate.Value.Day);
                }
                else if (year == MaximumDate.Value.Year && month == MaximumDate.Value.Month)
                {
                    ResetDay();

                    DayItemsSource = DateUtil.GetFilteredDaysMax(DateUtil.GetMonthIndex(SelectedMonth.ToString()).ToString(), MaximumDate.Value.Day);
                }
                else if (year == MaximumDate.Value.Year && month < MaximumDate.Value.Month)
                {
                    ResetDay();

                    DayItemsSource = DateUtil.GetDays(DateUtil.GetMonthIndex((string)SelectedMonth).ToString(),
                        Convert.ToInt32((string)SelectedYear!));
                }
                else if (year == MinimumDate.Value.Year && month > MinimumDate.Value.Month)
                {
                    ResetDay();

                    DayItemsSource = DateUtil.GetDays(DateUtil.GetMonthIndex((string)SelectedMonth).ToString(),
                        Convert.ToInt32((string)SelectedYear!));
                }
                else if (year < MaximumDate.Value.Year)
                {
                    ResetDay();

                    DayItemsSource = DateUtil.GetDays(DateUtil.GetMonthIndex((string)SelectedMonth).ToString(),
                        Convert.ToInt32((string)SelectedYear!));
                }
            }
            else if (MinimumDate != null && MaximumDate == null)
            {
                if (year > MinimumDate.Value.Year
                    || month > MinimumDate.Value.Month)
                {
                    ResetDay();

                    DayItemsSource = DateUtil.GetDays(DateUtil.GetMonthIndex((string)SelectedMonth).ToString(),
                        Convert.ToInt32((string)SelectedYear!));
                }
                else
                {
                    ResetDay();

                    DayItemsSource = DateUtil.GetFilteredDays(DateUtil.GetMonthIndex(SelectedMonth.ToString()).ToString(), MinimumDate.Value.Day);
                }
            }
            else if (MinimumDate == null && MaximumDate != null)
            {
                if (year == MaximumDate.Value.Year && month == MaximumDate.Value.Month)
                {
                    ResetDay();

                    DayItemsSource = DateUtil.GetFilteredDaysMax(DateUtil.GetMonthIndex(SelectedMonth.ToString()).ToString(), MaximumDate.Value.Day);
                }
            }
            else
            {
                DayItemsSource = DateUtil.GetDays(DateUtil.GetMonthIndex((string)SelectedMonth).ToString(),
                    Convert.ToInt32((string)SelectedYear!));
            }
        }
        catch (Exception)
        {
            //
        }
    }

    private void YearPicker_SelectionChanged(object sender, EventArgs e)
    {
        if (SelectedYear == null) return;

        var year = Convert.ToInt32(SelectedYear.ToString());

        if (MinimumDate != null && MaximumDate != null)
        {
            ResetMonth();

            if (year < MaximumDate.Value.Year)
            {
                MonthItemsSource = year > MinimumDate.Value.Year
                    ? DateUtil.MonthNames
                    : DateUtil.GetFilteredMonths(MinimumDate.Value.Month);
            }
            else
            {
                MonthItemsSource = DateUtil.GetFilteredMonths(MaximumDate.Value.Month);
            }
        }
        else if (MinimumDate != null && MaximumDate == null)
        {
            ResetMonth();

            if (year > MinimumDate.Value.Year) MonthItemsSource = DateUtil.MonthNames;
        }
        else if (MinimumDate == null && MaximumDate != null)
        {
            ResetMonth();

            if (year == MaximumDate.Value.Year)
                MonthItemsSource = DateUtil.GetFilteredMonths(MaximumDate.Value.Month);
        }
    }

    /// <summary>
    /// Gets the selected date
    /// </summary>
    /// <returns>A <see cref="DateTime"/></returns>
    public DateTime? GetDate() => Date;

    /// <summary>
    /// Sets the date
    /// </summary>
    /// <param name="date">The date to be set</param>
    public void SetDate(DateTime? date)
    {
        try
        {
            SelectedYear = date!.Value.Year;

            YearSelectedIndex = YearItemsSource!.IndexOf(date.Value.Year);

            YearPicker.Title = date.Value.Year.ToString();

            SelectedMonth = DateUtil.GetMonthName(date.Value.Month);

            MonthSelectedIndex = MonthItemsSource!.IndexOf(DateUtil.GetMonthName(date.Value.Month));

            MonthPicker.Title = DateUtil.GetMonthName(date.Value.Month);

            DayItemsSource ??= DateUtil.GetDays(date.Value.Month.ToString(), date.Value.Year);

            SelectedDay = date.Value.Day;

            DaySelectedIndex = DayItemsSource.IndexOf(date.Value.Day);

            DayPicker.Title = date.Value.ToString();

            Date = date;
        }
        catch (Exception)
        {
            //
        }
    }

    protected void SetDate()
    {
        try
        {
            if (SelectedYear == null || SelectedMonth == null || SelectedDay == null) return;

            Date = new DateTime(Convert.ToInt32(SelectedYear),
                Convert.ToInt32(DateUtil.GetMonthIndex((string)SelectedMonth).ToString()),
                Convert.ToInt32(SelectedDay));
        }
        catch (Exception)
        {
            //
        }
    }

    /// <summary>
    /// Clears the set date 
    /// </summary>
    public void ClearDate()
    {
        ResetYear();

        ResetMonth();

        ResetDay();

        Date = null;
    }

    private void ResetDay()
    {
        SelectedDay = null;
        DaySelectedIndex = -1;
        DayPicker.Title = "Day";
    }

    private void ResetMonth()
    {
        SelectedMonth = null;
        MonthSelectedIndex = -1;
        MonthPicker.Title = "Month";
    }

    private void ResetYear()
    {
        SelectedYear = null;
        YearSelectedIndex = -1;
        MonthPicker.Title = "Year";
    }
}