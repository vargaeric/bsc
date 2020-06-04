using System.Collections.Generic;

namespace PersonalAgenda
{
    internal class Agenda
    {
        public List<Activity> activites;
        public Agenda()
        {
            activites = new List<Activity>();
        }

        public override string ToString()
        {
            string output = "";

            for (int i = 0; i < activites.Count; i++)
                output += activites[i].ToString();

            return output;
        }

        public void addActivity(Activity activity)
        {
            activites.Add(activity);
        }
    }
}