﻿using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Account
{
    public class AccountUpdateViewCommand : CommandBase
    {
        private readonly AccountPanelViewModel _accountPanelVM;

        public AccountUpdateViewCommand(AccountPanelViewModel accountPanelVM)
        {
            _accountPanelVM = accountPanelVM;
        }

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "Library")
            {
                _accountPanelVM.SelectedViewModel = new LibraryViewModel();
            }
        }
    }
}
