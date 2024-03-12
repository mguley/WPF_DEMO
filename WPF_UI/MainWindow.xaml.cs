using System.Globalization;
using System.Windows;
using WPF_Library.Abstractions;
using WPF_Library.Models;

namespace WPF_UI;

/// <summary>
/// Represents the main window of the application.
/// </summary>
public partial class MainWindow : Window
{
    private readonly IDataAccess? _dataAccess;
    private readonly ICalculator? _calculator;
    
    /// <summary>
    /// Initializes a new instance of the MainWindow class.
    /// </summary>
    /// <param name="dataAccess">The data access layer used for interacting with person data.</param>
    /// <param name="calculator">The calculator used for performing arithmetic operations.</param>
    public MainWindow(IDataAccess dataAccess, ICalculator calculator)
    {
        _calculator = calculator;
        _dataAccess = dataAccess;
        InitializeComponent();
        RebindDropdown();
    }

    /// <summary>
    /// Rebinds the dropdown list with the latest data from the data access layer.
    /// Sets the source of ComboBox items and defines the property to display.
    /// </summary>
    private void RebindDropdown()
    {
        IModel[]? listItems = _dataAccess?.GetList();
        CmbUsers.ItemsSource = null;
        CmbUsers.ItemsSource = listItems;
        CmbUsers.DisplayMemberPath = "FullName";
    }

    /// <summary>
    /// Handles the Add Person button click event.
    /// Creates a new PersonModel instance from the input fields and adds it to the data store.
    /// Then it updates the dropdown to reflect the addition.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event arguments.</param>
    private void AddPersonButton_OnClick(object sender, RoutedEventArgs e)
    {
        var (firstName, lastName) = (TxtFirstName.Text, TxtLastName.Text);
        IModel model = new PersonModel
        {
            FirstName = firstName,
            LastName = lastName,
        };
        
        _dataAccess?.AddData(model);
        RebindDropdown();
    }

    /// <summary>
    /// Handles the Add button click event for arithmetic operation.
    /// This method performs addition using the calculator service.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event arguments.</param>
    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (_calculator is not null)
        {
            PerformCalculation(_calculator.Add);
        }
    }

    /// <summary>
    /// Handles the Subtract button click event for arithmetic operation.
    /// This method performs subtraction using the calculator service.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event arguments.</param>
    private void SubtractButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (_calculator is not null)
        {
            PerformCalculation(_calculator.Subtract);
        }
    }

    /// <summary>
    /// Handles the Multiply button click event for arithmetic operation.
    /// This method performs multiplication using the calculator service.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event arguments.</param>
    private void MultiplyButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (_calculator is not null)
        {
            PerformCalculation(_calculator.Multiply);
        }
    }

    /// <summary>
    /// Handles the Divide button click event for arithmetic operation.
    /// This method performs division using the calculator service.
    /// It includes a check to avoid division by zero.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event arguments.</param>
    private void DivideButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(TxtSecondNumber.Text, out double y) && y == 0)
        {
            TxtResults.Text = "Division by zero.";
            return;
        }
        
        if (_calculator is not null)
        {
            PerformCalculation(_calculator.Divide);
        }
    }

    /// <summary>
    /// Performs the given arithmetic operation and displays the result.
    /// If the input values are not valid doubles, it sets the result text to "Invalid input".
    /// </summary>
    /// <param name="operation">The arithmetic operation to perform.</param>
    private void PerformCalculation(Func<double, double, double> operation)
    {
        if (double.TryParse(TxtFirstNumber.Text, out double x) && double.TryParse(TxtSecondNumber.Text, out double y))
        {
            TxtResults.Text = operation(x, y).ToString(CultureInfo.CurrentCulture);
        }
        else
        {
            TxtResults.Text = "Invalid input";
        }
    }
}
