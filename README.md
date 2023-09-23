# YmdDateSelector.Maui

## Overview

YmdDateSelector.Maui is a simple date picker for .NET Maui apps.

## Features

- **Date Range:** You can define a date range, limiting the user's selection to a specific period, such as a minimum and maximum date.

- **Events:** The control provides events for handling date selection and validation, giving you full control over the selected date.

- **Cross-Platform:** This control is compatible with Android, iOS, and Windows platforms, ensuring a consistent experience for your users.

## Installation

You can easily install the YmdDateSelector using NuGet. Follow these steps:

1. Open your .NET MAUI project in Visual Studio.

2. Right-click on your project in the Solution Explorer and select "Manage NuGet Packages."

3. In the NuGet Package Manager, search for "YmdDateSelector" or use the following command in the Package Manager Console:

   ```shell
   Install-Package YmdDateSelector
   ```

4. Once the package is installed, you can start using the YmdDateSelector in your XAML files.

## Usage

1. Add the XML namespace for the custom date picker control in your XAML file:

   ```xml
   xmlns:ymd="clr-namespace:YmdDateSelector.Maui.Views;assembly=YmdDateSelector.Maui"
   ```

2. Use the `YmdDateSelector` control in your XAML layout:

   ```xml
   <ymd:YmdDateSelector
       x:Name="YmdDateSelector"
       MinimumDate="1990/01/01"
       MaximumDate="2023/12/31" />
   ```

3. Customize the control's appearance and behavior by setting its properties in XAML or code-behind.

4. Handle the `DateSelected` event to perform actions when the user selects a date.

```csharp
private void YmdDateSelector_DateSelected(object sender, EventArgs e)
{
    var date = YmdDateSelector.GetDate().ToString();
}
```

## Issues and Contributions

If you encounter any issues or have suggestions for improvements, please [create an issue].

Contributions in the form of pull requests are welcome and encouraged!


---

Thank you for choosing the YmdDateSelector for .NET MAUI! We hope it enhances your app's date selection experience and simplifies your development process. If you find it helpful, please consider giving it a star.
