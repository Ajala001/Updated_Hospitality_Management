interface IAdminManager
{
    public void AddDoctor();
    public void RemoveDoctor();
    public string ViewDoctorDetails();
    public string ViewPatientDetails();
    public void GetAllDoctors();
    public void GetAllPatients();
    public void GetBookedDoctors();
    public void GetAvailableDoctors();
    public void ViewDoctorsReport();
    public void AddDepartment();
    public void GetAllDepartment();
    public void GetListOfDocInADept();
}