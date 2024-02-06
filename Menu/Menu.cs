using System.Security.Cryptography.X509Certificates;
using enums;

class Menu
{
    IAdminManager adminManager = new AdminManager();
    IDoctorManager doctorManager = new DoctorManager();
    IPatientManager patientManager = new PatientManager();
    IAppointmentManager appointmentManager = new AppointmentManager();
    public void MainMenu()
    {
        bool isContinue = true;
        Console.WriteLine("Your're Welcome To HMS");
        while (isContinue)
        {
            foreach (var option in Enum.GetValues(typeof(UserOptions)))
            {
                System.Console.WriteLine($"Enter {(int)option} to {option}");
            }
            int userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    Register();
                    break;
                case 2:
                    Login();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    break;
            }
        }
    }

    public void Register()
    {
        bool isRegistering = true;
        while (isRegistering)
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

            Console.Write("Enter Your Date Of Birth(Year Only): ");
            int dateOfBirth = int.Parse(Console.ReadLine());

            Console.Write("Choose A Password: ");
            string password = Console.ReadLine();

            Patient patient = new Patient(firstName, lastName, email, phoneNumber, gender, DateTime.Now.Year - dateOfBirth, password);
            patientManager.AddPatient(patient);

            isRegistering = false;
        }
    }

    public void Login()
    {
        bool isContinue = true;
        while (isContinue)
        {
            Console.Write("Enter Your ID: ");
            string userID = Console.ReadLine();

            switch (AdminManager.VerifyUser(userID))
            {
                case "Admin":
                    Console.Write("Enter Your Password: ");
                    string adminPassword = Console.ReadLine();
                    if (AdminManager.AuthenticateAdmin(userID, adminPassword))
                    {
                        AdminMenu();
                    }
                    break;

                case "Doctor":
                    Console.Write("Enter Your Password: ");
                    string docPassword = Console.ReadLine();
                    Doctor.LoggedInDoctor = userID;
                    var currentDoctor = DoctorManager.GetDoctorByID(userID);
                    if (DoctorManager.AuthenticateDoctor(currentDoctor, userID, docPassword))
                    {
                        DoctorMenu();
                    }
                    break;

                case "Patient":
                    Console.Write("Enter Your Password: ");
                    string patPassword = Console.ReadLine();
                    Patient.LoggedInPatient = userID;
                    var currentPatient = PatientManager.GetpatientByID(userID);
                    if (PatientManager.AuthenticatePatient(currentPatient, userID, patPassword))
                    {
                        PatientMenu();
                    }
                    break;
                case "Invalid":
                    Console.WriteLine("Invalid Input!!!");
                    break;
            }
            isContinue = false;
        }
    }

    public void AdminMenu()
    {
        bool isContinue = true;
        while (isContinue)
        {
            foreach (var item in Enum.GetValues(typeof(AdminRoles)))
            {
                Console.Write($"Enter {(int)item} To {item}\n");
            }
            int adminChoice = int.Parse(Console.ReadLine());
            switch (adminChoice)
            {
                case 1:
                    adminManager.AddDoctor();
                    PressEnterToContinue();
                    break;
                case 2:
                    adminManager.RemoveDoctor();
                    PressEnterToContinue();
                    break;
                case 3:
                    adminManager.ViewDoctorDetails();
                    PressEnterToContinue();
                    break;
                case 4:
                    adminManager.ViewPatientDetails();
                    PressEnterToContinue();
                    break;
                case 5:
                    adminManager.GetAllDoctors();
                    PressEnterToContinue();
                    break;
                case 6:
                    adminManager.GetAvailableDoctors();
                    PressEnterToContinue();
                    break;
                case 7:
                    adminManager.GetBookedDoctors();
                    PressEnterToContinue();
                    break;
                case 8:
                    adminManager.GetAllPatients();
                    PressEnterToContinue();
                    break;
                case 9:
                    adminManager.ViewDoctorsReport();
                    PressEnterToContinue();
                    break;
                case 10:
                    AppointmentManager.GetListOfAppointMent();
                    PressEnterToContinue();
                    break;
                case 11:
                    adminManager.AddDepartment();
                    PressEnterToContinue();
                    break;
                case 12:
                    adminManager.GetAllDepartment();
                    PressEnterToContinue();
                    break;
                case 13:
                    adminManager.GetListOfDocInADept();
                    PressEnterToContinue();
                    break;
                case 14:
                    isContinue = false;
                    break;
            }
        }

    }

    public void DoctorMenu()
    {
        bool isContinue = true;
        while (isContinue)
        {
            foreach (var item in Enum.GetValues(typeof(DoctorRoles)))
            {
                Console.Write($"Enter {(int)item} To {item}:\n");
            }
            int doctorChoice = int.Parse(Console.ReadLine());

            switch (doctorChoice)
            {
                case 1:
                    doctorManager.ViewAppointment();
                    break;
                case 2:
                    doctorManager.ViewDoctorWithinUrDept();
                    break;
                case 3:
                    doctorManager.ViewListOfDocInOtherDept();
                    break;
                case 4:
                    isContinue = false;
                    break;
            }
        }
    }

    public void PatientMenu()
    {
        bool isContinue = true;
        while (isContinue)
        {
            foreach (var item in Enum.GetValues(typeof(PatientRoles)))
            {
                Console.Write($"Enter {(int)item} To {item}\n");
            }
            int patientChoice = int.Parse(Console.ReadLine());

            switch (patientChoice)
            {
                case 1:
                    appointmentManager.BookAppointment();
                    break;
                case 2:
                    patientManager.CheckDoctorStatus();
                    break;
                case 3:
                    isContinue = false;
                    break;
            }
        }
    }

    public static void PressEnterToContinue()
    {
        Console.Write("Press Enter to Continue:");
        Console.ReadKey();
        Console.WriteLine();
    }
}
