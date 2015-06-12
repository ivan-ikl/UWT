using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using UWT.Portable.Models;

namespace UWT.App.Models
{
    class ProductViewModel : Product
    {        
        public Visibility MessagesVisible
        {
            get { return Messages == 0 ? Visibility.Collapsed : Visibility.Visible; }
        }

        public List<DailySail> Sails {
            get { return DailySails.Select(array => new DailySail { Day = array[0], Sold = array[1] }).ToList(); }
        }
    }

    public class DailySail
    {
        public int Day { get; set; }
        public int Sold { get; set; }
    }
}
