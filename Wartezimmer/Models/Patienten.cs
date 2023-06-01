namespace Wartezimmer.Models {
    public class Patienten {
        public static Queue<Patient>? Schlange { get; set; } = new();
        public static void AddPatient(Patient patient) {
            Schlange.Enqueue(patient);
        }
        public static String GetNextPatient() {
            String ergebnis;
            Patient patient = Schlange.Dequeue() ;
            ergebnis = $"PNr{patient.PNr}: {patient.Anrede} {patient.Vorname} {patient.Name} wohnhaft in {patient.Plz} {patient.Ort}, {patient.Strasse} {patient.Hausnummer}";
            return ergebnis;
        }
        public static void DeletePatient(int nr) {
            Schlange = new Queue<Patient>(Schlange.Where(x => x.PNr != nr));
        }
    }
}
