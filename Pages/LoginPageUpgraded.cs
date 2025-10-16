using Microsoft.Playwright;

namespace PlaywrightDemo.Pages;

public class LoginPageUpgraded
{
    private readonly IPage _page;
    
    public LoginPageUpgraded(IPage page) => _page = page;
    
    private ILocator LinkLogin => _page.Locator("text=Login");
    private ILocator InputUsername => _page.Locator("#UserName");
    private ILocator InputPassword => _page.Locator("#Password");
    private ILocator ButtonLogin => _page.Locator("input" ,new PageLocatorOptions { HasTextString = "Log in" });
    private ILocator LinkEmployeeDetails => _page.Locator("text='Employee Details'");
    private ILocator LinkEmployeeList => _page.Locator("text='Employee List'");

    public async Task ClickLogin()
    {
        await _page.RunAndWaitForNavigationAsync(async () =>
            {
                await LinkLogin.ClickAsync();
            }, 
            new PageRunAndWaitForNavigationOptions
            {
                UrlString = "**/Login"
            });
    } 
    
    public async Task ClickEmployeeList() => await LinkEmployeeList.ClickAsync();
    public async Task Login(string username = "admin", string password = "password")
    {
        await InputUsername.FillAsync(username);
        await InputPassword.FillAsync(password);
        await ButtonLogin.ClickAsync();
    }
    
    public async Task<bool> IsEmployeeDetailsVisible() => await LinkEmployeeDetails.IsVisibleAsync();
}