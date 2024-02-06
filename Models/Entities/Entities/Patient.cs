class Patient : BaseClass
{
    public string PatientID {get; set;}
    static int patientCount = 0;
    public int Age {get; set;}
    public bool BookAppointment {get; set;}
    public string PatientFile {get; set;}
    public static string LoggedInPatient {get; set;}
    public Patient(string firstName, string lastName, string gmail, string phoneNumber, int gender, int age, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Gmail = gmail;
        PhoneNumber = phoneNumber;
        Gender = gender;
        Age = age;
        Password = password;
        BookAppointment = false;
        PatientID = "Pat" + (patientCount + 1);
        patientCount++;
        PatientFile = "Empty";
    }
}