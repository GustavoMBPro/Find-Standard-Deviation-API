using Microsoft.AspNetCore.Mvc;

namespace W3Assigment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainApi : ControllerBase
    {

        /*
         Author: GustavoMBPro
         Title: Find Standard Deviation API
         */

        //Sortlist Function
        List<double> sorting(List<double> list)
        {
            return list.OrderBy(x => x).ToList();
        }

        //Function LogObject() New addition to Week 5
        string LogObject(string input)
        {
            System.Diagnostics.Debug.WriteLine(input);
            return input;
        }

        //Standard Deviation Function
        double standardDeviation(List<double> n)
        {
            double avg = n.Average();
            double sum = n.Select(x => ((x - avg) * (x - avg))).Sum();
            return Math.Sqrt(sum / n.Count);
        }

        [HttpPost(Name = "W3Assigment")]

        public ActionResult<List<string>> InListWork(List<double> lista)
        {
            List<double> sorted = sorting(lista);
            List<string> listaHija = new List<string>();
            int counter = 1;

            foreach (double i in lista)
            {
                if(counter != 1)
                {
                    double res = standardDeviation(sorted.GetRange(0, counter));
                    listaHija.Add("Elements: " + counter + " Current Standard Deviation: " + res);
                    //Call New Function LogObject()
                    System.Console.WriteLine(LogObject(res.ToString()));
                }
                else
                {
                    listaHija.Add("List too small");
                }
                counter++;
            }

            return listaHija;
        }
    }
}