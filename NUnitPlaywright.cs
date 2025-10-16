using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Legacy;

namespace PlaywrightDemo;

public class NUnitPlaywright: PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://eaapp.somee.com/");
    }

    [Test]
    public async Task Test1()
    {
        Page.SetDefaultTimeout(10); 
        var loginLink = Page.Locator("text=Login");
        await loginLink.ClickAsync();
        await Page.FillAsync("#UserName", "admin");
        await Page.FillAsync("#Password", "password");
        var loginButton = Page.Locator("input" ,new PageLocatorOptions { HasTextString = "Log in" });
        await loginButton.ClickAsync();
        await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
    }
}
