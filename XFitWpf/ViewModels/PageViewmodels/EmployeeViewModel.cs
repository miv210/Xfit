using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFitWpf.ViewModels.PageViewmodels
{
    public class EmployeeViewModel : BaseViewModel
    {
        public Command AddNewEmployeeCommand { get; set; }
        public EmployeeViewModel() { }

        private void AddNewEmployee()
        {

        }
    }
}
