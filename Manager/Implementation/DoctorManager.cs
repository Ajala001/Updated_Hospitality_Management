class DoctorManager : IDoctorManager
{
    static List<Doctor> doctors = new List<Doctor>();
    static List<Doctor> bookedDoctors = new List<Doctor>();
    static List<Doctor> availableDoctors = doctors;

    public void AddDoctor(Doctor doctor)
    {
        doctors.Add(doctor);
        Console.WriteLine("Doctor Added successfully.");
        DisplayDoctorID(doctor.Gmail);
    }

    static bool IsDoctorInList(Doctor doctor)
    {
        foreach (var doctorItem in doctors)
        {
            if (doctorItem.Gmail == doctor.Gmail)
            {
                return true;
            }
        }
        return false;
    }

    public void DisplayDoctorID(string gmail)
    {
        foreach (var doctorItem in doctors)
        {
            if (doctorItem.Gmail == gmail)
            {
                if (doctorItem.Gender == 1)
                {
                    Console.WriteLine($"Dr. (Mr.) {doctorItem.FirstName} {doctorItem.LastName}'s ID is {doctorItem.DoctorID}");
                }
                else if (doctorItem.Gender == 2)
                {
                    Console.WriteLine($"Dr. (Mrs.) {doctorItem.FirstName} {doctorItem.LastName}'s ID is {doctorItem.DoctorID}");
                }
            }
        }
    }

    public static bool AuthenticateDoctor(Doctor doctor, string doctorID, string doctorPass)
    {
        if (!IsDoctorInList(doctor))
        {
            Console.WriteLine("Your Details Dont't Exist on Our System!!!");
            Console.WriteLine();
            return false;
        }
        else
        {
            if (doctor.DoctorID == doctorID && doctor.Password == doctorPass)
            {
                Console.WriteLine("Login Successful.");
                Console.WriteLine();
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Credentials!!!");
                Console.WriteLine();
                return false;
            }
        }
    }

    public bool VerifyDoctorLoginDetails(string doctorID, string doctorPassword)
    {
        if (doctors.Count != 0)
        {
            foreach (var doctorItem in doctors)
            {
                if (doctorItem.DoctorID == doctorID && doctorItem.Password == doctorPassword)
                {
                    Console.WriteLine($"{doctorItem.DoctorID} You've Successfully Login!!!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid Credentials!!!");
                    return false;
                }
            }
        }
        else
        {
            Console.WriteLine("No Records for Doctors Yet!!!");
        }
        return false;
    }

    public static List<Doctor> ListOfDoctors()
    {
        if (doctors == null)
        {
            return null;
        }
        return doctors;
    }

    public static List<Doctor> ListOfBookedDoctors()
    {
        if (bookedDoctors != null)
        {
            return bookedDoctors;
        }
        return null;
    }

    public static List<Doctor> AvailableDoctors()
    {
        return availableDoctors;
    }

    public static void SetDoctorStatus(Doctor doctor)
    {
        foreach (var doctorItem in ListOfDoctors())
        {
            if (doctorItem.DoctorID == doctor.DoctorID)
            {
                doctor.DoctorStatus = "Booked";
            }
        }
    }

    public static void ChangeDoctorStatus(Doctor doctor)
    {
        foreach (var doctorItem in ListOfDoctors())
        {
            if (doctorItem.DoctorID == doctor.DoctorID)
            {
                doctor.DoctorStatus = "Available";
            }
        }
    }


    public static Doctor GetDoctorByID(string doctorID)
    {
        if (doctors != null)
        {
            foreach (var doctorItem in doctors)
            {
                if (doctorItem.DoctorID == doctorID)
                {
                    return doctorItem;
                }
            }
        }
        return null;
    }

    public void ViewAppointment()
    {
        Console.Write("Enter Your ID: ");
        string docID = Console.ReadLine();

        if (docID != Doctor.LoggedInDoctor)
        {
            Console.WriteLine("Invalid Registration ID!!!");
            return;
        }

        if (AppointmentManager.ListOfAppointment() != null && AppointmentManager.ListOfAppointment().Count > 0)
        {
            List<Appointment> docAppointments = AppointmentManager.ListOfAppointment().Where(appointment => appointment.DoctorID == docID).ToList();
            if (docAppointments.Count > 0)
            {
                foreach (var docAppointItem in docAppointments)
                {
                    Console.WriteLine($"{docAppointItem.PatientID} Booked and AppointMent With You on {docAppointItem.AppointmentDate}");
                }
            }
            else
            {
                Console.WriteLine("No appointments found for this doctor ID.");
            }
        }
        else
        {
            Console.WriteLine("No Appointments!!!");
        }
    }

    public void ViewDoctorWithinUrDept()
    {
        Console.Write("Enter Your Id: ");
        string docId = Console.ReadLine();

        if (docId != Doctor.LoggedInDoctor)
        {
            Console.WriteLine("Invalid Registration ID!!!");
            return;
        }

        var doctor = GetDoctorByID(Doctor.LoggedInDoctor);
        var listOfDepartment = DepartmentManager.ListOfDepartment();
        var dept = listOfDepartment.Find(dept => dept.DepartmentName == doctor.DoctorFieldOfSpecialization);

        if (dept != null)
        {
            Console.WriteLine($"Doctors in {dept.DepartmentName} Department:");
            foreach (var doctorItem in dept.DoctorsWithinTheDept)
            {
                Console.WriteLine($"Name: {doctor.FirstName} {doctor.LastName}\nSpecialization: {doctor.DoctorFieldOfSpecialization}\nDoctor Status: {doctor.DoctorStatus}\nDoc ID: {doctor.DoctorID}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine($"Department '{doctor.DoctorFieldOfSpecialization}' not found.");
        }
    }

    public void ViewListOfDocInOtherDept()
    {
        Console.Write("Enter the Department Name: ");
        string deptName = Console.ReadLine();

        var listOfDept = DepartmentManager.ListOfDepartment();
        var foundDept = listOfDept.Find(dept => dept.DepartmentName == deptName);

        if (foundDept != null)
        {
            Console.WriteLine($"Doctors in {foundDept.DepartmentName} Department:");
            foreach (var doctor in foundDept.DoctorsWithinTheDept)
            {
                Console.WriteLine($"Name: {doctor.FirstName} {doctor.LastName}\nSpecialization: {doctor.DoctorFieldOfSpecialization}\nDoctor Status: {doctor.DoctorStatus}\nDoc ID: {doctor.DoctorID}");
            }
        }
        else
        {
            Console.WriteLine($"Department '{deptName}' not found.");
        }

    }
}