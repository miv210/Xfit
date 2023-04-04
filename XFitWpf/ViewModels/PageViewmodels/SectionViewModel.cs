using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using XFitWpf.Models;
using XFitWpf.Views.DialogWindows;

namespace XFitWpf.ViewModels.PageViewmodels
{
    public class SectionViewModel : BaseViewModel
    {
        DataGrid sectionGrid;
        public List<Section> ListSection { get; set; }
        public Section SelectedSection { get; set; }
        public Command AddNewSectionCommand { get; set; }
        public Command DeleteSectionCommand { get; set; }
        public SectionViewModel() 
        { 
            ListSection = GetListSection();
            AddNewSectionCommand= new Command(AddNewSection);
            DeleteSectionCommand = new Command(DeleteSection);
        }

        private void AddNewSection(object obj)
        { 
            AddSectionDialogWindow addSectionWindow = new AddSectionDialogWindow();
            sectionGrid = obj as DataGrid;
            if (addSectionWindow.ShowDialog() == true)
            {
                ListSection = new List<Section>();
                ListSection = GetListSection();
                sectionGrid.ItemsSource = ListSection;
            }
            else
            {
                MessageBox.Show("Не удалось обновить");
            }
            
        }
        private void DeleteSection(object obj)
        {
            sectionGrid = obj as DataGrid;
            if(sectionGrid.SelectedItem != null)
            {
                try
                {
                    using (XFitBd_context db = new XFitBd_context())
                    {
                        db.Sections.Remove((Section)sectionGrid.SelectedItem);
                        db.SaveChanges();
                        MessageBox.Show("Данные удаленны");
                        ListSection = new List<Section>();
                        ListSection = GetListSection();
                        sectionGrid.ItemsSource = ListSection;
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

        private List<Section> GetListSection()
        {
            using (XFitBd_context db = new XFitBd_context())
            {
                ListSection = db.Sections.ToList();
            }
            return ListSection;
        }
    }
}
