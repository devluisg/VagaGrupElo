using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace VagaGrupElo
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver;
            WebDriverWait wait;

            using (driver = new ChromeDriver())
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                driver.Navigate().GoToUrl(@"https://www.google.com.br/");

                wait.Until<bool>((page) =>
                {
                    return page.Title.Contains("Google");
                }
                );
                IWebElement input = driver.FindElement(By.Name("q"));
                input.Click();
                input.SendKeys("DEVOPS");
                //Espera para evitar erro element not interactable
                Thread.Sleep(1000);
                IWebElement btn = driver.FindElement(By.Name("btnK"));
                btn.Submit();
                wait.Until<bool>((page) =>
                {
                    return page.Title.Contains("DEVOPS");
                }
                );  
                var links = driver.FindElements(By.ClassName("r"));
                int count = 0;
                Console.Clear();
                for(int index = 0; count <5; index++)
                {
                    if (links[index].Displayed)
                    {
                        Console.WriteLine($"{count + 1}º - {links[index].Text} \n");
                        count++;
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
