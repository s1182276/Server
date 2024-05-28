namespace KeuzeWijzerCore.Enums
{
    [Flags]
    public enum AppRole
    {
        Student = 1 << 0,
        StudentSupervisor = 1 << 1,
        Administrator = 1 << 2,
    }
}
