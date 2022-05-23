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
    public class SongWindowViewModel : ObservableRecipient
    {
        public RestCollection<Song> Songs { get; set; }
        private Song selectedSong;

        public Song SelectedSong
        {
            get { return selectedSong; }
            set
            {
                if (value != null)
                {
                    selectedSong = new Song
                    {
                        ID = value.ID,
                        SongName = value.SongName

                    };
                    OnPropertyChanged();
                    (DeleteSongCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateSongCommand { get; set; }
        public ICommand DeleteSongCommand { get; set; }
        public ICommand UpdateSongCommand { get; set; }

        public SongWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Songs = new RestCollection<Song>("http://localhost:3445/", "song", "hub");

                CreateSongCommand = new RelayCommand(() =>
                {
                    Songs.Add(new Song()
                    {
                        SongName = selectedSong.SongName
                    });

                });

                UpdateSongCommand = new RelayCommand(() =>
                    Songs.Update(SelectedSong),
                    () => SelectedSong != null
                );

                DeleteSongCommand = new RelayCommand(() => {
                    Songs.Delete(SelectedSong.ID);
                },
                () =>
                {
                    return SelectedSong != null;
                }
                );
                SelectedSong = new Song();
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
