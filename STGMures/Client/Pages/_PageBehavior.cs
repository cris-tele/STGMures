using Microsoft.AspNetCore.Components;
using MudBlazor;

using StgMures.Client.Services;

namespace StgMures.Client.Pages
{
    public class PageBehavior :ComponentBase
    {
        private readonly SetAppMenuInfos _appMenuInfos = new();
        protected bool _disabledField   = true;
        protected bool _disabledBtn     = true;
        protected bool _disabledBtnValid= true;
        protected int _currentAction = 0;

        protected enum _actionbtn { None, Add, Edit, Delete };
        public int ItemsCount { set; get; } = 0;

        public bool IsDisabled() 
        {
            Console.WriteLine("Is Disabled called");
            return _disabledField; 
        }
        public int CurrentAction { get; set; } = (int)_actionbtn.None;

        protected void RowClicked<T>(MudTable<T> t)
        {
            if (CurrentAction != (int)_actionbtn.None)
                return;     // don't change selection in the middle

            if (t!.SelectedItem == null)
                return; // no selection

            if (t!.GetFilteredItemsCount() == 0)
                ItemsCount = 0;

            EnableActionButtons();
        }

        protected void DisableAll() // DisableAll()
        {
            _currentAction = (int)_actionbtn.None;
            CurrentAction = (int)_actionbtn.None;
            _disabledField      = true;               // disable editing
            _disabledBtn        = true;               // disable actions
            _disabledBtnValid   = true;               // disable validations
             StateHasChanged();
            _appMenuInfos.SetDisabledState(_disabledField);
        }

        protected void EnableActionButtons() // DisableAll()
        {
            _currentAction = (int)_actionbtn.None;

            _disabledBtn = false;               // disable actions

            _disabledField = true;               // disable editing
            _disabledBtnValid = true;               // disable validations

            _appMenuInfos.SetDisabledState(_disabledField);
            StateHasChanged();

        }

        protected void EnableAll() // EnableAll()
        {
            _disabledField = false;              // enable all editable fields
            _disabledBtn = false;              // enable choices ADD/Edit/Delete butons 
            _disabledBtnValid   = true;               // disable validations: a choice must be made 

            _appMenuInfos.SetDisabledState(_disabledField);

        }

        protected void EnableFields() // EnableAll()
        {
            _disabledField = false;              // enable all editable fields
            _disabledBtn = false;              // enable choices ADD/Edit/Delete butons 
            _disabledBtnValid = true;               // disable validations: a choice must be made 
            _appMenuInfos.SetDisabledState(_disabledField);
            // StateHasChanged();
        }

        public void AddNewRecord()
        {
            CurrentAction = (int)_actionbtn.Add;

            _disabledField = false;              // enable all editable fields
            _disabledBtnValid = false;
            _disabledBtn = true; // disable future actions
            _appMenuInfos.SetDisabledState(_disabledField);
            StateHasChanged();
        }
        protected void UpdateRecord()
        {
            CurrentAction = (int)_actionbtn.Edit;

            _disabledBtn = true;
            _disabledBtnValid = false;
            _appMenuInfos.SetDisabledState(_disabledField);
        }

        protected void DeleteRecord()
        {
            CurrentAction = (int)_actionbtn.Delete;

            _disabledBtn = true;
            _disabledBtnValid = false;
            _appMenuInfos.SetDisabledState(_disabledField);
            // StateHasChanged();
        }

    }

}

