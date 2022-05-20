using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        List<double> numbers = new List<double>();
        List<string> beforePare = new List<string>();
        double x = 0;
        public bool errorMessage { get; private set; } = false;
        [BindProperty]
        public string? FirstNumber { get; set; }

        [BindProperty]
        public string? SecondNumber { get; set; }

        [BindProperty]
        public string? ThirdNumber { get; set; }

        public double Average { get; private set; }
        public double Maximum { get; private set; }
        public double Minimum { get; private set; }
        public double Sum { get; private set; }
        public double TotalNumbers { get; private set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        
        }


        public void OnPost()
        {
            
            beforePare.Add(FirstNumber);
            beforePare.Add(SecondNumber);
            beforePare.Add(ThirdNumber);

            for (int i = 0; i < beforePare.Count; i++)
            {
                if (beforePare[i] != null)
                {
                    if (double.TryParse(beforePare[i], out x))
                    {
                    
                        numbers.Add(double.Parse(beforePare[i]));
                    }
                   
                }
                
            }
           
            if(numbers.Count > 0)
            {
                errorMessage = true;
               
                numbers.Sort();
                Average = Math.Round(numbers.Average(), 2);
                Sum = Math.Round(numbers.Sum(), 2);
                Maximum = numbers.Max();
                Minimum = numbers.Min();
                TotalNumbers = numbers.Count();
              
            }else
            {
               
                    errorMessage = true;
                    TotalNumbers = 0;
          
            }

        }
    }
}