using ModuleA.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private ModelA ModelA { get; }

        public ViewAViewModel(ModelA modelA)
        {
            ModelA = modelA;
            Message = modelA.Message;
        }
    }
}
