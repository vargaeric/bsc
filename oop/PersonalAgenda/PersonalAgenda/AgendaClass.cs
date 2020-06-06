using System.Collections.Generic;
using System;

namespace PersonalAgenda
{
    internal class AgendaClass
    {
        public List<Activity> activites;

        public AgendaClass()
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

        public void removeActivity(Activity activity)
        {
            activites.Remove(activity);
        }

        public void sortActivitesByDate()
        {
            Activity aux;

            for (int i = 0; i < activites.Count - 1; i++)
                for (int j = i + 1; j < activites.Count; j++)
                    if (DateTime.Compare(activites[i].StartDate, activites[j].StartDate) == 1)
                    {
                        aux = activites[i];
                        activites[i] = activites[j];
                        activites[j] = aux;
                    }
        }
    }
}