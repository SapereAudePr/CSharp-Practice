using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleToDoDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    void AddTodoButton_Click(object sender, RoutedEventArgs e)
    {
        string todoText = TodoInput.Text;

        if (string.IsNullOrEmpty(todoText)) return;

        TextBlock todoItem = new()
        {
            Text = todoText,
            Margin = new Thickness(5),
            Foreground = new SolidColorBrush(Colors.White),
        };

        TodoList.Children.Add(todoItem);
        TodoInput.Clear();
    }
}