using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_todoapp.Models
{
    class TodoModel
    {        
        private bool _isDone;
        private string _text;
        // для автоматического присвания текущей даты и времени в момент создания таска
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}
