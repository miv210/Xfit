using Microsoft.EntityFrameworkCore;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using XFitWpf.Models;

namespace XFitWpf.ViewModels.DialogWindowViewModels
{
    public class AddSeasonTicketDialogViewModel
    {
        public string CountSeason { get; set; }
        public string WorkingHours { get; set; }
        public List<Employee> ListEmployee { get; set; }
        public Employee SelectedEmployee { get; set; }
        public List<Trainer> ListTrainer { get; set; }
        public Trainer SelectedTrainer { get; set; }

        public Command AddSeasonTicketCommand { get; set; }
        public Command SetSelectedSEmployeeCommand { get; set; }
        public Command SetSelectedTrainerCommand { get; set; }
        public AddSeasonTicketDialogViewModel()
        {
            ListEmployee = GetEmployee();
            ListTrainer = GetTrainer();

            AddSeasonTicketCommand= new Command(AddSeasonTicket);
            SetSelectedSEmployeeCommand = new Command(SetSelectedEmloyee);
            SetSelectedTrainerCommand = new Command(SetSelectedTrainer);
        }

        private void AddSeasonTicket(object obj)
        {
            Window wnd = obj as Window;
            var newSeasonTicket = new SeasonTicket
            {
                TrainerId = SelectedTrainer.Id,
                EmployeeId = SelectedEmployee.Id,
                WorkingHours = Convert.ToInt32(WorkingHours),
                CountSeason = Convert.ToInt32(CountSeason),
                
            };
            var newAmount = new Amount
            {
                SeasonTicketId = newSeasonTicket.Id,
                SectionId= SelectedTrainer.SectionId,
                Total = newSeasonTicket.CountSeason * SelectedTrainer.Section.AmountForOneLesson,
                SeasonTicket = newSeasonTicket
            };
            using (XFitBd_context db = new XFitBd_context())
            {
                try
                {
                    db.SeasonTickets.Add(newSeasonTicket);
                    db.Amounts.Add(newAmount);
                    db.SaveChanges();
                    MessageBox.Show($"Абонемент {newSeasonTicket.Id} добавлен");
                    wnd.DialogResult = true;
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить");
                }
            }
        }
        private void SetSelectedEmloyee(object obj)
        {
            Employee employee = obj as Employee;
            SelectedEmployee = employee;
        }
        private void SetSelectedTrainer(object obj)
        {
            Trainer trainer = obj as Trainer;
            SelectedTrainer = trainer;
        }
        private List<Employee> GetEmployee()
        {
            using (XFitBd_context db = new XFitBd_context())
            {
                ListEmployee = db.Employees.Include(p=> p.SeasonTicket).ToList();
            }
            return ListEmployee;
        }
        private List<Trainer> GetTrainer()
        {
            using (XFitBd_context db = new XFitBd_context())
            {
                ListTrainer = db.Trainers.Include(p=>p.Section).ToList();
            }
            return ListTrainer;
        }
    }
}
