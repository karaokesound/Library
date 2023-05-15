﻿using Library.UI.Commands.Account;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class AccountPanelViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set 
            { 
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand AccountUpdateViewCommand { get; }

        public AccountPanelViewModel()
        {
            AccountUpdateViewCommand = new AccountUpdateViewCommand(this);
        }
    }
}
