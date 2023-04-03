using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFitWpf.Models;
using XFitWpf.Views.DialogWindows;

namespace XFitWpf.ViewModels.PageViewmodels
{
    public class SectionViewModel : BaseViewModel
    {
        public List<Section> ListSection { get; set; }
        public Command AddNewSectionCommand { get; set; }
        public SectionViewModel() 
        { 
            ListSection = GetListSection();
            AddNewSectionCommand= new Command(AddNewSection);
        }

        private void AddNewSection()
        {
            AddSectionDialogWindow addSectionWindow = new AddSectionDialogWindow();
            addSectionWindow.ShowDialog();
            ListSection = new List<Section>();
            ListSection = GetListSection();
        }

        private List<Section> GetListSection()
        {
            using (XFitBd_context db = new XFitBd_context())
            {
                ListSection = db.Sections.ToList();
            }
            return new List<Section>();
        }
    }
}
