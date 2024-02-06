class AppointmentManager : IAppointmentManager
{
    IDoctorManager doctorManager = new DoctorManager();
    static List<Appointment> appointments = new List<Appointment>();
    public void BookAppointment()
    {
        if (Patient.LoggedInPatient == null)
        {
            Console.WriteLine("You're not a Registered User!!!");
            return;
        }

        var availableDoctors = DoctorManager.ListOfDoctors();

        if (availableDoctors.Count == 0)
        {
            Console.WriteLine("No Doctors Registered Yet!!!");
            return;
        }

        Console.WriteLine("Here Are The List of Available Doctors");
        foreach (var doctor in availableDoctors)
        {
            Console.WriteLine($"Name: {doctor.FirstName} {doctor.LastName}\nDepartment: {doctor.DoctorFieldOfSpecialization}\nID: {doctor.DoctorID}\nStatus: {doctor.DoctorStatus}");
            Console.WriteLine();
        }

        Console.Write("Enter the Doctor ID: ");
        string doctorID = Console.ReadLine();

        var selectedDoctor = availableDoctors.FirstOrDefault(doctor => doctor.DoctorID == doctorID);
        if (selectedDoctor == null)
        {
            Console.WriteLine($"Doctor with ID {doctorID} not Available");
            return;
        }

        Console.Write("Enter the Appointment Time(HH: mm): ");
        DateTime appointmentTime = DateTime.Parse(Console.ReadLine());

        if (CheckExpiry(appointmentTime))
        {
            Console.WriteLine("Appointment Expired!!!");
            return;
        }

        Console.WriteLine($"You've {Patient.LoggedInPatient} Book An Appointment with Dr. {selectedDoctor.FirstName} {selectedDoctor.LastName}");
        Appointment appointment = new Appointment(doctorID, appointmentTime);
        appointments.Add(appointment);
        var currentPatient = PatientManager.GetpatientByID(Patient.LoggedInPatient);

        Console.WriteLine("What Complain are you Lodging: ");
        string lodgeComplain = Console.ReadLine();

        Doctor.DoctorsReport.Add(currentPatient, lodgeComplain);
        currentPatient.PatientFile = lodgeComplain;
        DoctorManager.SetDoctorStatus(selectedDoctor);
        DoctorManager.ListOfBookedDoctors().Add(selectedDoctor);
        DoctorManager.AvailableDoctors().Remove(selectedDoctor);

        var patientBooked = PatientManager.GetpatientByID(Patient.LoggedInPatient);
        PatientManager.SetPatientStatus(patientBooked);
    }

    public static List<Appointment> ListOfAppointment()
    {
        if (appointments.Count != 0)
        {
            return appointments;
        }
        return null;
    }

    public static void GetListOfAppointMent()
    {
        if(ListOfAppointment() != null)
        {
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"{appointment.AppointmentID}:  {appointment.AppointmentDescription}");
            }
        }else
            Console.WriteLine("No Appointment Yet!!!");
    }

    public bool CheckExpiry(DateTime appointmentTime)
    {
        var hour = appointmentTime - DateTime.Now;
        if (hour.Hours > 2)
        {
            return true;
        }
        return false;
    }
}