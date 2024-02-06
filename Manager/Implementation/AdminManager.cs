class AdminManager : IAdminManager
{
    IDoctorManager doctorManager = new DoctorManager();
    IDepartmentManager departmentManager = new DepartmentManager();

    public void AddDoctor()
    {
        Console.Write("Enter Your First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Your Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter Your Gmail: ");
        string email = Console.ReadLine();

        Console.Write("Enter Your Phone Number: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("Enter Your Gender:\nEnter 1 for Male:\nEnter 2 for Female:");
        int gender = int.Parse(Console.ReadLine());

        Console.Write("Choose A Password: ");
        string password = Console.ReadLine();

        Console.Write("Enter Doctor's Fieild Of Specialization: ");
        string doctorFieldOfSpecialization = Console.ReadLine();

        Doctor doctor = new Doctor(firstName, lastName, email, phoneNumber, gender, password, doctorFieldOfSpecialization);
        doctorManager.AddDoctor(doctor);
    }

    public void RemoveDoctor()
    {
        Console.Write("Enter the ID of Doctor to Remove: ");
        string doctorID = Console.ReadLine();

        var doctorList = DoctorManager.ListOfDoctors();
        Doctor doctorToRemove = doctorList.Find(doctor => doctor.DoctorID == doctorID);

        if (doctorToRemove != null)
        {
            doctorList.Remove(doctorToRemove);
            Console.WriteLine($"Dr. {doctorToRemove.FirstName} {doctorToRemove.LastName} with ID {doctorToRemove.DoctorID} has been removed Successfully!!!");
        }
        else
        {
            Console.WriteLine($"Doctor with ID {doctorID} not found.");
        }
    }



    public string ViewDoctorDetails()
    {
        Console.Write("Enter the Doctor's ID: ");
        string docID = Console.ReadLine();

        var listOfBookedDoctors = DoctorManager.ListOfBookedDoctors();
        var listOfAvailableDoctors = DoctorManager.AvailableDoctors();

        List<Doctor> allDoctors = new List<Doctor>();
        allDoctors.AddRange(listOfBookedDoctors);
        allDoctors.AddRange(listOfAvailableDoctors);

        Doctor doctorToView = allDoctors.Find(doctor => doctor.DoctorID == docID);
        if (doctorToView != null)
        {
            foreach (var doctor in allDoctors)
            {
                if (doctor.DoctorID == docID)
                {
                    Console.WriteLine($"Name: {doctor.FirstName} {doctor.LastName}\nDepartment: {doctor.DoctorFieldOfSpecialization}\nID: {doctor.DoctorID}\nStatus: {doctor.DoctorStatus}");
                }
            }
        }
        else
        {
            Console.WriteLine("Doctor List Empty!!!");
        }
        return null;
    }

    public string ViewPatientDetails()
    {
        Console.Write("Enter the Patient's ID: ");
        string patID = Console.ReadLine();

        var patientsList = PatientManager.ListOfPatients();
        if (patientsList != null && patientsList.Count != 0)
        {
            foreach (var patient in patientsList)
            {
                if (patient.PatientID == patID)
                {
                    Console.WriteLine($"FirstName: {patient.FirstName}\nLastName: {patient.LastName}\nGmail: {patient.Gmail}\nPhone Number: {patient.PhoneNumber}\nPatient ID: {patient.PatientID}\nPatient Age: {patient.Age}\nBook Appointment: {patient.BookAppointment}\nPatient File: {patient.PatientFile}");
                }
                else
                    Console.WriteLine($"No Patient with this {patID} ID");
                break;
            }
        }
        else
        {
            Console.WriteLine("Patient List Empty!!!");
        }
        return null;
    }



    public void PrintUser()
    {
        throw new NotImplementedException();
    }

    public void GetAllDoctors()
    {
        var listOfBookedDoctors = DoctorManager.ListOfBookedDoctors();
        var listOfAvailableDoctors = DoctorManager.AvailableDoctors();

        List<Doctor> allDoctors = new List<Doctor>();
        allDoctors.AddRange(listOfBookedDoctors);
        allDoctors.AddRange(listOfAvailableDoctors);

        if (allDoctors.Count > 0)
        {
            foreach (var doctor in allDoctors)
            {
                Console.WriteLine($"Name: {doctor.FirstName} {doctor.LastName}\nDepartment: {doctor.DoctorFieldOfSpecialization}\nID: {doctor.DoctorID}\nStatus: {doctor.DoctorStatus}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No Doctors Registered Yet!!!");
        }
    }

    public void GetBookedDoctors()
    {
        var bookedDoctors = DoctorManager.ListOfBookedDoctors();
        if (bookedDoctors != null && bookedDoctors.Count > 0)
        {
            foreach (var doctor in bookedDoctors)
            {
                Console.WriteLine($"Name: {doctor.FirstName} {doctor.LastName}\nDepartment: {doctor.DoctorFieldOfSpecialization}\nID: {doctor.DoctorID}\nStatus: {doctor.DoctorStatus}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No Doctor Booked!!!");
        }
    }

    public void GetAvailableDoctors()
    {
        var availableDoctors = DoctorManager.AvailableDoctors();
        if (availableDoctors != null && availableDoctors.Count != 0)
        {
            foreach (var doctor in availableDoctors)
            {
                Console.WriteLine($"Name: {doctor.FirstName} {doctor.LastName}\nDepartment: {doctor.DoctorFieldOfSpecialization}\nID: {doctor.DoctorID}\nStatus: {doctor.DoctorStatus}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No Doctor Available!!!");
        }
    }

    public void GetAllPatients()
    {
        var listOfPatients = PatientManager.ListOfPatients();
        if (listOfPatients != null && listOfPatients.Count != 0)
        {
            foreach (var patient in listOfPatients)
            {
                Console.WriteLine($"FirstName: {patient.FirstName}\nLastName: {patient.LastName}\nGmail: {patient.Gmail}\nPhone Number: {patient.PhoneNumber}\nPatient ID: {patient.PatientID}\nPatient Age: {patient.Age}\nPatient File: {patient.PatientFile}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No Paients Registered Yet!!!");
        }
    }

    public static string VerifyUser(string userID)
    {
        if (userID == "001")
        {
            return "Admin";
        }
        else if (userID.StartsWith("Doc"))
        {
            return "Doctor";
        }
        else if (userID.StartsWith("Pat"))
        {
            return "Patient";
        }
        else
            return "Invalid";

    }

    public static bool AuthenticateAdmin(string userID, string userPassword)
    {
        if (userID == "001" && userPassword == "admin")
        {
            Console.WriteLine("You've Successfully Login!!!");
            return true;
        }
        Console.WriteLine("Invalid Credentials");
        return false;
    }

    public void ViewDoctorsReport()
    {
        Console.Write("Enter Doctor's ID: ");
        string docID = Console.ReadLine();

        if (DoctorManager.ListOfBookedDoctors != null && DoctorManager.ListOfBookedDoctors().Count > 0)
        {
            foreach (var doctor in DoctorManager.ListOfBookedDoctors())
            {
                if (doctor.DoctorID == docID)
                {
                    foreach (var reports in Doctor.DoctorsReport)
                    {
                        Console.WriteLine($"Patient's FirstName:{reports.Key.FirstName}\nPatient's Complain{reports.Value}");
                    }
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("No Reports Available!!!");
        }
    }

    public void AddDepartment()
    {
        Console.Write("Enter The Name Of The Department: ");
        string deptName = Console.ReadLine();

        Console.Write("Enter The Name Of The HOD: ");
        string hodName = Console.ReadLine();

        Console.Write("Enter The Opening Time: ");
        TimeOnly openingTime = TimeOnly.Parse(Console.ReadLine());

        Console.Write("Enter The Closing Time: ");
        TimeOnly closingTime = TimeOnly.Parse(Console.ReadLine());

        Department department = new Department(deptName, hodName, openingTime, closingTime);
        departmentManager.AddDepartment(department);
        AddDoctorToDept(department);

    }

    public void GetAllDepartment()
    {
        var listOfDepartment = DepartmentManager.ListOfDepartment();
        if (listOfDepartment != null && listOfDepartment.Count != 0)
        {
            foreach (var department in listOfDepartment)
            {
                Console.WriteLine($"Department ID: {department.DepartmentID}\nDepartment Name: {department.DepartmentName}\nDepartment HOD: {department.HeadOfDepartment}\nOpening Hours: {department.OpeningHours}\nClosing Hours: {department.ClosingHours}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Departments Not Opened!!!");
        }
    }

    public void AddDoctorToDept(Department department)
    {
        var listOfDoctors = DoctorManager.ListOfDoctors();

        if (listOfDoctors == null && listOfDoctors.Count == 0)
        {
            Console.WriteLine("Error: Unable to retrieve the list of doctors.");
            return;
        }

        foreach (var docItem in listOfDoctors)
        {
            if (docItem.DoctorFieldOfSpecialization == department.DepartmentName)
            {
                department.AddDoctor(docItem);
            }
        }
    }


    public void GetListOfDocInADept()
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