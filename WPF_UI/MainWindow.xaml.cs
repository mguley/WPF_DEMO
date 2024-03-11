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
    
    /// <summary>
    /// Initializes a new instance of the MainWindow class.
    /// </summary>
    /// <param name="dataAccess">The data access layer used for interacting with person data.</param>
    public MainWindow(IDataAccess dataAccess)
    {
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
}
