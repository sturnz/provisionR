using Jasmin1.Interfaces;

namespace Jasmin1
{
    public class Auswahlgrafik : IGrafik
    {
        public string Print(string parameter)
        {
            Console.WriteLine();
            var options = new List<string>()
            {
                "Neuen Kunden anlegen",
                "Neuen Vertrag anlegen",
                "Kundenliste anschauen",
                "Vertragsliste anschauen"
            };
           
            return String.Join("\n", options);
        }
    }
}
