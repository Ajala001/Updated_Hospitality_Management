
class DepartmentManager : IDepartmentManager
{
    static List<Department> departments = new List<Department>();


    public void AddDepartment(Department department)
    {
        if (!IsDeptInList(department))
        {
            departments.Add(department);
            Console.WriteLine("Department Added successfully.");
            DisplayDeptID(department.DepartmentName);
        }
        else
        {
            Console.WriteLine($"Department with name {department.DepartmentName} already exists.");
            return;
        }
    }

    static bool IsDeptInList(Department department)
    {
        foreach (var deptItem in departments)
        {
            if (deptItem.DepartmentName == department.DepartmentName)
            {
                return true;
            }
        }
        return false;
    }

    public void DisplayDeptID(string departmentName)
    {
        foreach (var deptItem in departments)
        {
            if (deptItem.DepartmentName == departmentName)
            {
                Console.WriteLine($"{deptItem.DepartmentName} Department's ID is {deptItem.DepartmentID}");
            }
        }
    }

    public static List<Department> ListOfDepartment()
    {
        if (departments == null)
        {
            return null;
        }
        return departments;
    }
}