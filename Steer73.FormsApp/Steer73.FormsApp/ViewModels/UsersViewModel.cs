using Steer73.FormsApp.Framework;
using Steer73.FormsApp.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Steer73.FormsApp.ViewModels
{
    public class UsersViewModel : ViewModel
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        public ICommand DeleteCommand { get; }

        public UsersViewModel(IUserService userService,
                              IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
            DeleteCommand = new Command(DeleteFirstUser);
        }

        private void DeleteFirstUser()
        {
            try
            {
                if (Users != null && Users.Count != 0)
                {
                    Users.RemoveAt(0);
                }
            }
            catch (Exception)
            {

            }

        }

        public async Task Initialize()
        {
            try
            {
                IsBusy = true;

                var users = await _userService.GetUsers();

                foreach (var user in users)
                {
                    Users.Add(user);
                }

                if (Users != null && Users.Count != 0)
                {
                    var orderedUsers = Users.OrderBy(x => x.FullName);
                    Users = new ObservableCollection<User>(orderedUsers);
                }
            }
            catch (Exception ex)
            {
                await _messageService.ShowError(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        ObservableCollection<User> users = new ObservableCollection<User>();
        public ObservableCollection<User> Users
        {
            get { return users; }
            set { SetProperty(ref users, value); }
        }
    }
}
