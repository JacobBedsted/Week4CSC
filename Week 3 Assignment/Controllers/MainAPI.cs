using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Week_3_Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainAPI : ControllerBase
    {
        [HttpPost(Name = "GetWeatherForecast")]
        public ActionResult<List<string>> IntListWork(List<int> lint)
        {
            List<string> slist = new List<string>();

            double sum = 0;
            double counter = 0;
            double mean = 0;
            double preTotal = 0;
            double StDev = 0;

            try
            {
                lint.Sort();

                foreach (int i in lint)
                {
                    counter++;
                    sum += i;
                    mean = sum / counter;

                    preTotal = preTotal + (Math.Pow((i - mean), 2));

                    StDev = Math.Sqrt((preTotal) /(counter));

                    if (counter > 1)
                    {
                        slist.Add("Elements: " + counter + ": Current Standard Deviation: " + StDev);
                    }
                    else
                    {
                        slist.Add("List not long enough");
                    }
                }
                Console.WriteLine("Sum: " + sum);

                return slist;
            }

            catch
            {
                slist.Add("Error: Invalid values");
                return slist;
            }
        }
    }
}