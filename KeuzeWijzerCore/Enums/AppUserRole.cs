namespace KeuzeWijzerCore.Enums
{
    [Flags]
    public enum AppUserRole
    {
        None = 0,
        Student = 1,
        StudentSupervisor = 2,
        Administrator = 4,
    }
}
