using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using XFitWpf.Models;
using XFitWpf.Views.DialogWindows;
using MvvmHelpers.Commands;
using Microsoft.EntityFrameworkCore;

namespace XFitWpf.ViewModels.PageViewmodels
{
    public class TrainerViewModel
    {
        DataGrid trainerGrid;
        public List<Trainer> ListTrainer { get; set; }
        public Section SelectedSection { get; set; }
        public Command AddNewTrainerCommand { get; set; }
        public Command DeleteTrainerCommand { get; set; }
        public TrainerViewModel()
        {
            ListTrainer = GetListTrainer();
            AddNewTrainerCommand = new Command(AddNewTrainer);
            DeleteTrainerCommand = new Command(DeleteTrainer);
        }

        private void AddNewTrainer(object obj)
        {
            AddTrainerDialogWindow addTrainerWindow = new AddTrainerDialogWindow();
            trainerGrid = obj as DataGrid;
            if (addTrainerWindow.ShowDialog() == true)
            {
                ListTrainer = new List<Trainer>();
                ListTrainer = GetListTrainer();
                trainerGrid.ItemsSource = ListTrainer;
            }
            else
            {
                MessageBox.Show("Не удалось обновить");
            }

        }
        private void DeleteTrainer(object obj)
        {
            trainerGrid = obj as DataGrid;
            if (trainerGrid.SelectedItem != null)
            {
                try
                {
                    using (XFitBd_context db = new XFitBd_context())
                    {
                        db.Trainers.Remove((Trainer)trainerGrid.SelectedItem);
                        db.SaveChanges();
                        MessageBox.Show("Данные удаленны");
                        ListTrainer = new List<Trainer>();
                        ListTrainer = GetListTrainer();
                        trainerGrid.ItemsSource = ListTrainer;
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

        private List<Trainer> GetListTrainer()
        {
            using (XFitBd_context db = new XFitBd_context())
            {
                ListTrainer = db.Trainers.Include(p=> p.Section).ToList();
            }
            return ListTrainer;
        }
    }
}

