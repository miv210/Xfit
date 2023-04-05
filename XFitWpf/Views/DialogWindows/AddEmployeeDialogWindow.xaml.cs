using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using XFitWpf.ViewModels.DialogWindowViewModels;

namespace XFitWpf.Views.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeDialogWindow.xaml
    /// </summary>
    public partial class AddEmployeeDialogWindow : Window
    {
        public AddEmployeeDialogWindow()
        {
            InitializeComponent();
            DataContext = new AddEmployeeDialogViewModel();
        }
    }
}
