namespace Wartezimmer.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
        [HttpGet]
        public ViewResult Eingabe() {
            return View(); 
        }
        [HttpPost]
        public ViewResult Eingabe(Patient patient) {
            Patienten.AddPatient(patient);
            return View();
        }       
        public ViewResult Arztsicht() {          
            return View();
        }
        public ViewResult NextArztsicht() {
            string patient = "keine Patienten mehr im Warteraum";
            if (Patienten.Schlange.Count != 0) {
                patient = Patienten.GetNextPatient();
            }
            return View("Arztsicht", patient);
        }
        [HttpGet]
        public ViewResult PatientenListe() {
			Queue<Patient>? kunden = Patienten.Schlange;
			return View("PatientenListe", kunden);
        }
        [HttpPost]         
        public ViewResult Delete(int id) {
            Patienten.DeletePatient(id);
            Queue<Patient>? kunden = Patienten.Schlange;
            return View("PatientenListe", kunden);
        }
    }
}