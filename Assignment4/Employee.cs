using System;
/*
 * @Author Dallas Tang A00937791
*/
namespace Assignment1
{
    internal class Employee
    {
        private String name;
        private String startdate;
        private String jobtitle;
        public Employee(String name, String startdate, String jobtitle)
        {
            this.name = name;
            this.startdate = startdate;
            this.jobtitle = jobtitle;
        }

        public String getName
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }

        public String getStartdate
        {
            get
            {
            return startdate;
            }
            set
            {
                this.startdate = value;
            }
        }
        public String getJobtitle
        {
            get
            {
                return jobtitle;
            }
            set
            {
                this.jobtitle = value;
            }
        }
    }
}