using L38TRN_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace L38TRN_HFT_2021221.WpfClient
{
    public class ArtistWindowViewModel : ObservableRecipient
    {
        public RestCollection<Artist> Artists { get; set; }
        private Artist selectedArtist;

        public Artist SelectedArtist
        {
            get { return selectedArtist; }
            set 
            {
                if (value != null)
                {
                    selectedArtist = new Artist
                    {
                        ID = value.ID,
                        ArtistName = value.ArtistName
                        
                    };
                    OnPropertyChanged();
                    (DeleteArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateArtistCommand { get; set; }
        public ICommand DeleteArtistCommand { get; set; }
        public ICommand UpdateArtistCommand { get; set; }

        public ArtistWindowViewModel()
        {
            if (!IsInDesignMode)
            {

                Artists = new RestCollection<Artist>("http://localhost:3445/", "artist", "hub");

                CreateArtistCommand = new RelayCommand(() => 
                {
                    Artists.Add(new Artist()
                    {
                        ArtistName = selectedArtist.ArtistName
                    }); 

                });

                UpdateArtistCommand = new RelayCommand(() =>
                    Artists.Update(SelectedArtist),
                    () => SelectedArtist != null
                );

                DeleteArtistCommand = new RelayCommand(() => { 
                    Artists.Delete(SelectedArtist.ID);
                }, 
                () =>
                {
                    return SelectedArtist != null;
                }
                );
                SelectedArtist = new Artist();
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
