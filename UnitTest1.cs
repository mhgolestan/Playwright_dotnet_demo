using Microsoft.Playwright;
using NUnit.Framework.Legacy;
using PlaywrightDemo.Pages;

namespace PlaywrightDemo;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions()
        {
            Headless = false,
            SlowMo = 50,
        });
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://eaapp.somee.com/");
        await page.ClickAsync("text=Login");
        await page.ScreenshotAsync(new()
        {
            Path = "screenshot.png"
        });
        await page.FillAsync("#UserName", "admin");
        await page.FillAsync("#Password", "password");
        await page.ClickAsync("text=Log in");
        var isExist = await page.Locator("text='Employee Details'").IsVisibleAsync();
        Assert.That(isExist);
        
    }
    
    [Test]
    public async Task TestWithPom()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions()
        {
            Headless = false,
            SlowMo = 50,
        });
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://eaapp.somee.com/");
        
        LoginPage loginPage = new LoginPage(page);
        await loginPage.ClickLogin();
        await loginPage.Login("admin", "password");
        
        var isExist = await loginPage.IsEmployeeDetailsVisible();
        Assert.That(isExist);
        
    }
}
