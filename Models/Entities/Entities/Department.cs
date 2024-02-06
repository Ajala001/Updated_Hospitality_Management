class Department
{
    public string DepartmentName {get; set;}
    public string DepartmentID {get; set;}
    public string HeadOfDepartment {get; set;}
    public TimeOnly OpeningHours {get; set;}
    public TimeOnly ClosingHours {get; set;}
    public List<Doctor> DoctorsWithinTheDept {get;} = new List<Doctor>();
    public static int deptCount = 0;

    public Department(string departmentName, string headOfDepartment, TimeOnly openingHours, TimeOnly closingHours)
    {
        DepartmentName = departmentName;
        DepartmentID = "Dept_" + (deptCount + 1);
        deptCount++;
        HeadOfDepartment = headOfDepartment;
        OpeningHours = openingHours;
        ClosingHours = closingHours;
    }

    public void AddDoctor(Doctor doctor)
    {
        DoctorsWithinTheDept.Add(doctor);
    }
}