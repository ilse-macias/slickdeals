using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slickdeals
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://slickdeals.net/";
            driver.Navigate();

            var dealElements = driver.FindElements(By.CssSelector(".fpGridBox.grid.frontpage"));

            foreach (var dealElement in dealElements)
            {
                IWebElement vote = dealElement.FindElement(By.ClassName("count"));
                int voteCount = 0;
                int.TryParse(vote.Text, out voteCount);
                
                /*Vote*/
                if(voteCount > 100)
                {
                    /*Description*/
                    IWebElement title = dealElement.FindElement(By.ClassName("itemTitle"));
                    Console.WriteLine($"Title: {title.Text}");

                    /*Price*/
                    IWebElement price = dealElement.FindElement(By.ClassName("itemPrice"));
                    Console.WriteLine($"price: {price.Text}");

                    Console.WriteLine($"vote: {voteCount}");
                    Console.WriteLine("*********");
                }
                 
            }
        }
    }
}
