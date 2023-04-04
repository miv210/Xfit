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
    public class AddSectionDialogViewModel
    {
        public string Title { get; set; } 
        public string AmountOne { get; set; }
        public Command AddSectionCommand { get; set; }
        public AddSectionDialogViewModel() 
        { 
            AddSectionCommand= new Command(AddSection);
        }

        private void AddSection(object obj)
        {
            Window wnd = obj as Window;
            var newSection = new Section
            {
                Lessons = Title,
                AmountForOneLesson=Convert.ToUInt32( AmountOne)
            };
            using(XFitBd_context db = new XFitBd_context())
            {
                try
                {
                    db.Sections.Add(newSection);
                    db.SaveChanges();
                    MessageBox.Show($"Секция {newSection.Lessons} добавлена");
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
