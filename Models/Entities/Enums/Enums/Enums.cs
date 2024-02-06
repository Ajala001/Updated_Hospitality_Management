namespace enums
{
    public enum UserOptions
    {
        Register = 1,
        Login,
        Exit
    }

    public enum AdminRoles
    {
        Add_Doctor = 1,
        Remove_Doctor,
        View_Doctor_Details,
        View_Patient_Details,
        View_All_Doctors,
        View_Available_Doctors,
        View_Booked_Doctors,
        View_All_Patients,
        ViewDoctorsReport,
        View_Appointment_List,
        Add_Department,
        View_All_Departments,
        View_All_Doctors_Under_A_Department,
        Logout
    }

    public enum DoctorRoles
    {
        View_Appointment = 1,
        View_ListOf_Doctors_Within_Ur_Dept,
        View_ListOf_Doctors_Within_Other_Dept,
        Logout
    }

    public enum PatientRoles
    {
        ScheduleAppointment = 1,
        View_Doctor_Avalability,
        Logout
    }
}
