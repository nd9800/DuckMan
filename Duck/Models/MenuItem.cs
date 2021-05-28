using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duck.Models
{
    class MenuItem
    {
        public string Icon { set; get; }
        public string Title { set; get; }

        public MenuItem(string icon, string title)
        {
            Icon = icon;
            Title = title;
        }
    }
}
