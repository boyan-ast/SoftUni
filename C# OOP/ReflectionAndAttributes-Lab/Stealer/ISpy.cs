namespace Stealer
{
    public interface ISpy
    {
        string StealFieldInfo(string className, params string[] fieldsNames);

        string AnalyzeAccessModifiers(string className);

        string RevealPrivateMethods(string className);

        string CollectGettersAndSetters(string className);
    }
}
