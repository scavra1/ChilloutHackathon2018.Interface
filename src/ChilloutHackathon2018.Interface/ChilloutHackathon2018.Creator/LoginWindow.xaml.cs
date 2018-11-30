namespace ChilloutHackathon2018.Creator
{
    using ChilloutHackathon2018.Creator.ApiConection;
    using InterfaceModels.User;
    using System.Windows;

    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            userContext = new UserContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var userCredentials = new UserCredentials
            {
                UserName = loginBox.Text,
                Password = passwordBox.Password
            };

            var userInfo = userContext.Login(userCredentials);

            if (userInfo != null)
            {
                MainWindow = new MainWindow(userInfo);
                Hide();
                var result = MainWindow.ShowDialog();
                if (result.Value)
                {
                    Show();
                }
            }
        }

        public MainWindow MainWindow { get; set; }

        private UserContext userContext;
    }
}
