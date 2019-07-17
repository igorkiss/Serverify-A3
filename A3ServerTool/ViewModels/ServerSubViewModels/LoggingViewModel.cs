﻿using A3ServerTool.Enums;
using A3ServerTool.Models;
using GalaSoft.MvvmLight;
using Interchangeable;
using System;
using System.ComponentModel;

namespace A3ServerTool.ViewModels.ServerSubViewModels
{
    /// <summary>
    /// Represents view model with logging server properties.
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    /// <seealso cref="System.ComponentModel.IDataErrorInfo" />
    public class LoggingViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly ServerViewModel _parentViewModel;

        public Profile CurrentProfile => _parentViewModel.CurrentProfile;

        /// <summary>
        /// Gets or sets the call extension report limit.
        /// </summary>
        public float? CallExtensionReportLimit
        {
            get => CurrentProfile?.ServerConfig.CallExtensionReportLimit;
            set
            {
                if (Equals(value, CurrentProfile?.ServerConfig.CallExtensionReportLimit)) return;
                CurrentProfile.ServerConfig.CallExtensionReportLimit = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the console log file name.
        /// </summary>
        public string LogFileName
        {
            get => CurrentProfile?.ServerConfig?.LogFileName;
            set
            {
                if (Equals(value, CurrentProfile.ServerConfig?.LogFileName)) return;
                CurrentProfile.ServerConfig.LogFileName = !value.Contains(".log")
                    ? value + ".log"
                    : value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [are logs disabled].
        /// </summary>
        public bool AreLogsDisabled
        {
            get => CurrentProfile.ArgumentSettings.AreLogsDisabled;
            set
            {
                if (Equals(value, CurrentProfile.ArgumentSettings.AreLogsDisabled)) return;
                CurrentProfile.ArgumentSettings.AreLogsDisabled = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the time stamp format.
        /// </summary>
        public TimeStampType TimeStampFormat
        {
            get
            {
                Enum.TryParse(CurrentProfile.ServerConfig.TimeStampFormat.FirstLetterToUpperCase(), out TimeStampType timeStampFormat);
                return timeStampFormat;
            }
            set
            {
                if (Equals(value.ToString(), CurrentProfile.ServerConfig.TimeStampFormat)) return;
                CurrentProfile.ServerConfig.TimeStampFormat = value.ToString().ToLower();
                RaisePropertyChanged();
            }
        }

        public LoggingViewModel(ServerViewModel viewModel)
        {
            _parentViewModel = viewModel;
        }

        public string this[string columnName] => string.Empty;

        public string Error => string.Empty;
    }
}
