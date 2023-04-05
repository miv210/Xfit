using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XFitWpf.Models;

namespace XFitWpf.ViewModels.DialogWindowViewModels
{
    public class AddEmployeeDialogViewModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string TelehoneNumber { get; set; }
        public Command AddEmployeeCommand { get; set; }
        public AddEmployeeDialogViewModel()
        {
            AddEmployeeCommand = new Command(AddEmployee);

        }

        private void AddEmployee(object obj)
        {
            Window wnd = obj as Window;

            
            var newEmployee = new Employee
            {
                Surname = Surname,
                Name = Name,
                Patronymic = Patronymic,
                NumberPhone = TelehoneNumber
            };
            
            using (XFitBd_context db = new XFitBd_context())
            {
                try
                {
                    db.Employees.Add(newEmployee);
                    db.SaveChanges();
                    MessageBox.Show($"Пользователь {newEmployee.Name} добавлен");
                    wnd.DialogResult = true;
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить");
                }
            }
        }
    }
}
