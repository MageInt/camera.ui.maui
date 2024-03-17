using camera.ui.maui.Pages;

namespace camera.ui.maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell(); 
        }

        public void SetRootPage(Page page)
        {
            MainPage = page;
        }
    }
}
