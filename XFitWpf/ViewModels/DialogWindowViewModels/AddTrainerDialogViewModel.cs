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
    public class AddTrainerDialogViewModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public List<Section> ListSection { get; set; }
        public Section SelectedSection { get; set; }
        public Command AddTrainerCommand { get; set; }
        public Command SetSelectedSectionCommand { get; set; }
        public AddTrainerDialogViewModel()
        {
            ListSection = GetSections();
            AddTrainerCommand = new Command(AddTrainer);
            SetSelectedSectionCommand = new Command(SetSelectedSection);
            
        }

        private void AddTrainer(object obj)
        {
            Window wnd = obj as Window;
            var newTrainer = new Trainer
            {
                Surname = Surname,
                Name = Name,
                Patronymic = Patronymic,
                SectionId = SelectedSection.Id
            };
            using (XFitBd_context db = new XFitBd_context())
            {
                try
                {
                    db.Trainers.Add(newTrainer);
                    db.SaveChanges();
                    MessageBox.Show($"Секция {newTrainer.Name} добавлена");
                    wnd.DialogResult = true;
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить");
                }
            }
        }
        private void SetSelectedSection(object obj) 
        { 
            Section section = obj as Section;
            SelectedSection = section;
        }
        private List<Section> GetSections()
        {
            using (XFitBd_context db = new XFitBd_context())
            {
                ListSection= db.Sections.ToList();
            }
            return ListSection;
        }
    }
}

