using Microsoft.AspNetCore.Components;

namespace StgMures.Client.Pages
{
    public class _RazorPageBehaviorBase :ComponentBase
    {
        protected bool _disabledField = true;
        protected bool _disabledBtn = true;
        protected bool _disabledBtnValid = true;
        protected int _currentAction = 0;
        protected int _currentPage = 0;          // start with first page

        protected int _pageSize = 10;

        protected enum _actionbtn { None, Add, Edit, Delete };

        protected void ClearCurrentSelection()
        {
            _disabledField = true;                  // disable editing
            _disabledBtn = true;                 // disable actions
            _disabledBtnValid = true;               // disable validations

            StateHasChanged();
        }
        protected void EnableCurrentSelection()
        {
            _disabledField = false;                  // disable editing
            _disabledBtn = false;                 // disable actions
            _disabledBtnValid = false;               // disable validations

            StateHasChanged();
        }


        protected void AddNewRecord()
        {
            _currentAction = (int)_actionbtn.Add;
            _disabledBtn = true;
            _disabledBtnValid = false;
            StateHasChanged();
        }
        protected void UpdateRecord()
        {
            _currentAction = (int)_actionbtn.Edit;
            _disabledBtn = true;
            _disabledBtnValid = false;
            StateHasChanged();
        }

        protected void DeleteRecord()
        {
            _currentAction = (int)_actionbtn.Delete;
            _disabledBtn = true;
            _disabledBtnValid = false;
            StateHasChanged();
        }

    }

}

