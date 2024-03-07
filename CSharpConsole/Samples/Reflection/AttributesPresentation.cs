using System;
using System.Linq;
using System.Reflection;

namespace CSharpConsole.Samples.Reflection
{
    class AttributesPresentation
    {
        private static void Main(string[] args)
        {
            var updater = new VersionUpdate();
            Console.WriteLine("Updating english profile:");
            updater.InvokeMethods(UpdateProfile.English);

            Console.WriteLine();

            Console.WriteLine("Updating german profile:");
            updater.InvokeMethods(UpdateProfile.German);

            Console.ReadKey();
        }
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class UpdateMethodAttribute : Attribute
    {
        public UpdateMethodAttribute(int sequence, params UpdateProfile[] profiles)
        {
            Sequence = sequence;
            Profiles = profiles;
        }

        public UpdateProfile[] Profiles { get; set; }
        
        public int Sequence { get; set; }
    }

    public enum UpdateProfile
    {
        German,
        English
    }

    public class VersionUpdate
    {
        [UpdateMethod(1, UpdateProfile.English, UpdateProfile.German)]
        private void UpdateConfigs()
        {
            Console.WriteLine("Configs updated");
        }

        [UpdateMethod(5, UpdateProfile.English)]
        private void ApplyEnglishTranslation()
        {
            Console.WriteLine("English Translations updated");
        }

        [UpdateMethod(10, UpdateProfile.German)]
        private void ApplyGermanTranslation()
        {
            Console.WriteLine("German translations updated");
        }

        [UpdateMethod(4, UpdateProfile.German)]
        [UpdateMethod(9, UpdateProfile.English)]
        private void InstallWordChecker()
        {
            Console.WriteLine("Checker installed");
        }

        public void InvokeMethods(UpdateProfile profile)
        {
            // get methods with specific attribute only
            var updateMethods =
                this.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(m => m.GetCustomAttributes(typeof(UpdateMethodAttribute), false).Length > 0)
                    .SelectMany(m => m.GetCustomAttributes(typeof(UpdateMethodAttribute), false)
                                .Cast<UpdateMethodAttribute>()
                                .Select(uma => new
                                {
                                    MethodInfo = m,
                                    AttributeInfo = uma
                                }));

            // filter down to required and special methods only
            var methodAttributes = updateMethods
                .Where(um => (um.AttributeInfo.Profiles != null 
                            && um.AttributeInfo.Profiles.Length > 0
                            && um.AttributeInfo.Profiles.Contains(profile)))
                .OrderBy(um => um.AttributeInfo.Sequence);

            // execute
            foreach (var methodAttribute in methodAttributes)
            {
                try
                {
                    methodAttribute.MethodInfo.Invoke(this, null);
                }
                catch (Exception e)
                {
                    Console.WriteLine(methodAttribute.MethodInfo.Name + " failed to execute.");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

}
