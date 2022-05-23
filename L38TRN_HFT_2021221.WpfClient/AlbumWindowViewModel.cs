using L38TRN_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace L38TRN_HFT_2021221.WpfClient
{
    public class AlbumWindowViewModel : ObservableRecipient
    {
        public RestCollection<Album> Albums { get; set; }
        private Album selectedAlbum;

        public Album SelectedAlbum
        {
            get { return selectedAlbum; }
            set
            {
                if (value != null)
                {
                    selectedAlbum = new Album
                    {
                        ID = value.ID,
                        Title = value.Title

                    };
                    OnPropertyChanged();
                    (DeleteAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateAlbumCommand { get; set; }
        public ICommand DeleteAlbumCommand { get; set; }
        public ICommand UpdateAlbumCommand { get; set; }

        public AlbumWindowViewModel()
        {
            if (!IsInDesignMode)
            {

                Albums = new RestCollection<Album>("http://localhost:3445/", "album", "hub");

                CreateAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Add(new Album()
                    {
                        Title = selectedAlbum.Title
                    });

                });

                UpdateAlbumCommand = new RelayCommand(() =>
                    Albums.Update(SelectedAlbum),
                    () => SelectedAlbum != null
                );

                DeleteAlbumCommand = new RelayCommand(() => {
                    Albums.Delete(SelectedAlbum.ID);
                },
                () =>
                {
                    return SelectedAlbum != null;
                }
                );
                SelectedAlbum = new Album();
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

