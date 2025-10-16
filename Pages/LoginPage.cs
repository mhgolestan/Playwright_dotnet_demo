using Microsoft.Playwright;

namespace PlaywrightDemo.Pages;

public class LoginPage
{
    private IPage _page;
    private readonly ILocator _linkLogin;
    private readonly ILocator _inputUsername;
    private readonly ILocator _inputPassword;
    private readonly ILocator _buttonLogin;
    private readonly ILocator _linkEmployeeDetails;
    
    public LoginPage(IPage page)
    {
        _page = page;
        _linkLogin = _page.Locator("text=Login");
        _inputUsername = _page.Locator("#UserName");
        _inputPassword = _page.Locator("#Password");
        _buttonLogin = _page.Locator("input" ,new PageLocatorOptions { HasTextString = "Log in" });
        _linkEmployeeDetails = _page.Locator("text='Employee Details'");
    }
    
    public async Task ClickLogin() => await _linkLogin.ClickAsync();

    public async Task Login(string username = "admin", string password = "password")
    {
        await _inputUsername.FillAsync(username);
        await _inputPassword.FillAsync(password);
        await _buttonLogin.ClickAsync();
    }
    
    public async Task<bool> IsEmployeeDetailsVisible() => await _linkEmployeeDetails.IsVisibleAsync();
}