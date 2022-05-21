using L38TRN_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace L38TRN_HFT_2021221.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Artist> Artists { get; set; }
        public RestCollection<Album> Albums { get; set; }
        public RestCollection<Song> Songs { get; set; }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Thread.Sleep(3000);
                Artists = new RestCollection<Artist>("http://localhost:3445/", "artist", "hub");
                Albums = new RestCollection<Album>("http://localhost:3445/", "album", "hub");
                Songs = new RestCollection<Song>("http://localhost:3445/", "song");
            }


        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
    }
}
