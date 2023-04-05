using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using XFitWpf.Models;
using XFitWpf.Views.DialogWindows;
using Microsoft.EntityFrameworkCore;

namespace XFitWpf.ViewModels.PageViewmodels
{
    public class EmployeeViewModel : BaseViewModel
    {
        DataGrid employeeGrid;
        public List<Employee> ListEmployee { get; set; }
        public Section SelectedEmployee { get; set; }
        public Command AddNewEmployeeCommand { get; set; }
        public Command AddNewSeasonTicketCommand { get; set; }
        public Command DeleteEmployeeCommand { get; set; }
        public EmployeeViewModel()
        {
            ListEmployee = GetListEmployee();
            AddNewEmployeeCommand = new Command(AddNewEmployee);
            AddNewSeasonTicketCommand = new Command(AddNewSeasonTicket);
            DeleteEmployeeCommand = new Command(DeleteEmployee);
        }
        private void AddNewEmployee(object obj)
        {
            AddEmployeeDialogWindow addEmployeeWindow = new AddEmployeeDialogWindow();
            employeeGrid = obj as DataGrid;
            if (addEmployeeWindow.ShowDialog() == true)
            {
                ListEmployee = new List<Employee>();
                ListEmployee = GetListEmployee();
                employeeGrid.ItemsSource = ListEmployee;
            }
            else
            {
                MessageBox.Show("Не удалось обновить");
            }

        }
        private void AddNewSeasonTicket(object obj)
        {
            AddSeasonTicketDialogWindow addSeasonTicketWindow = new AddSeasonTicketDialogWindow();
            employeeGrid = obj as DataGrid;
            if (addSeasonTicketWindow.ShowDialog() == true)
            {
                ListEmployee = new List<Employee>();
                ListEmployee = GetListEmployee();
                employeeGrid.ItemsSource = ListEmployee;
            }
            else
            {
                MessageBox.Show("Не удалось обновить");
            }

        }
        private void DeleteEmployee(object obj)
        {
            employeeGrid = obj as DataGrid;
            if (employeeGrid.SelectedItem != null)
            {
                try
                {
                    using (XFitBd_context db = new XFitBd_context())
                    {
                        db.Employees.Remove((Employee)employeeGrid.SelectedItem);
                        db.SaveChanges();
                        MessageBox.Show("Данные удаленны");
                        ListEmployee = new List<Employee>();
                        ListEmployee = GetListEmployee();
                        employeeGrid.ItemsSource = ListEmployee;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Выберете объект для удаления");
            }

        }

        private List<Employee> GetListEmployee()
        {
            using (XFitBd_context db = new XFitBd_context())
            {
                ListEmployee = db.Employees.Include(p=> p.SeasonTicket)
                    .Include(p=> p.SeasonTicket!.Amount)
                    .Include(p=> p.SeasonTicket!.Trainer!.Section).ToList();
            }
            return ListEmployee;
        }
    }
}
