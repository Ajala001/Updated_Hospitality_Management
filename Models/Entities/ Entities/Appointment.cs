using System.Dynamic;

class Appointment
{
    public string AppointmentID {get; set;}
    public string PatientID {get; set;}
    public string DoctorID {get; set;}
    public string AppointmentDate {get; set;}
    public string AppointmentDescription {get; set;}
    public static int appointmentCount = 0;
    public DateTime AppointmentTime {get; set;}

    public Appointment(string doctorID, DateTime appointmentTime)
    {
        PatientID = Patient.LoggedInPatient;
        DoctorID = doctorID;
        AppointmentDate = DateTime.Now.ToString("dddd, dd yyyy");
        AppointmentID = "App_" + appointmentCount + 1;
        appointmentCount++;
        AppointmentTime = appointmentTime;
        AppointmentDescription = $"{Patient.LoggedInPatient} Scheduled an Appointment with {DoctorID} on {AppointmentDate}";
    }
}