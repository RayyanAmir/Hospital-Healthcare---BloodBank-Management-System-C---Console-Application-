using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Project
{
    class Program
    {
       
        //To open console in full screen
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            //To open console in full screen
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            //
            Console.ForegroundColor = ConsoleColor.Red;
            Program.Title();
            Program.Choice();
        }
        static void Title()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;



            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------   "  );
            Console.WriteLine(@"#     #                                               #     #                                                                   #####                                     "  );
            Console.WriteLine(@"#     #  ####   ####  #####  # #####   ##   #         #     # ######  ####  #    ###### #    # ######   ###   ######   ######  #          ##### ###### ######  #        # "  );
            Console.WriteLine(@"#     # #    # #      #    # #   #    #  #  #         #     # #      #    # #      #    #    # #       #   #  #     #  #        #   #   # #       #    #       # #    # # "  );
            Console.WriteLine(@"####### #    #  ####  #    # #   #   #    # #         ####### #      #    # #      #    ###### #       #####  # #  #   ######    #   ###    #     #    ####    #  #  #  # "  );
            Console.WriteLine(@"#     # #    #      # #####  #   #   ###### #         #     # ###### # ## # #      #    #    # #       #   #  # #      #           #  #       #   #    #       #   #    # "  );
            Console.WriteLine(@"#     # #    # #    # #      #   #   #    # #         #     # #      #    # #      #    #    # #       #   #  #  #     #           #  #       #   #    #####   #        # "  );
            Console.WriteLine(@"#     #  ####   ####  #      #   #   #    # ######    #     # ###### #    # #####  #    #    # ####### #   #  #    #   ######  ####   #   ####    #            #        # "  );
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------   "  );
            Console.WriteLine();

        }
        static void Choice()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\t\t\t\t**Enter Your Choice**");
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t\t\t\t\tFor Doctor's Appointment:        PRESS (1)");
            Console.WriteLine("\t\t\t\t\t\t\t\tTo Search for Appointment        PRESS (2)");
            Console.WriteLine("\t\t\t\t\t\t\t\tTo see All Appointments List:    PRESS (3)");
            Console.WriteLine("\t\t\t\t\t\t\t\tBlood Bank:                      PRESS (4)");
            Console.WriteLine("\t\t\t\t\t\t\t\tTo Exit:                         PRESS (5)");
            Console.Write("\n\t\t\t\t\t\t\t\tEnter Your Choice:");
            int Choice = int.Parse(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    Console.Clear();
                    Program.Appointment();

                    break;
                case 2:
                    Console.Clear();
                    Program.SearchAppointment();
                    break;
                case 3:
                    Console.Clear();
                    Program.AppointmentList();
                    break;
                case 4:
                    Console.Clear();
                    Program.BloodBank();
                    break;
                case 5:
                    Console.Clear();
                    Program.Exit();
                    break;
                default:
                    Console.Clear();
                    Program.Title();
                    Program.Choice();
                    break;

            }
            Console.ReadLine();

        }

        static void BloodBank()
        {
            Title();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\t\t**Enter Your Choice**");
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t\t\t\tTo donate blood:      (1)");
            Console.WriteLine("\t\t\t\t\t\t\tTo request blood:     (2)");
            Console.WriteLine("\t\t\t\t\t\t\tTo see Donors List:   (3)");
            Console.WriteLine("\t\t\t\t\t\t\tTo see Requests Lists:(4)");
            Console.WriteLine("\t\t\t\t\t\t\tTo Exit:              (5)");
            Console.Write("\t\t\t\t\t:");

            int Choice = int.Parse(Console.ReadLine());

            switch (Choice)
            {
                case 1:
                    Console.Clear();
                    Program.Donate();
                    break;
                case 2:
                    Program.ToRequestBlood();
                    break;
                case 3:
                    Console.Clear();
                    Program.List();
                    break;
                case 4:
                    Console.Clear();
                    Program.ReqList();
                    break;
                case 5:
                    Console.Clear();
                    Program.Exit();
                    break;
                default:
                    Console.Clear();
                    Program.Title();
                    Program.Choice();
                    break;

            }
            Console.ReadLine();
        }

        #region Hospital

    //Take doctor's appointment
        static void Appointment()
        {
            Console.Clear();
            Program.Title();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string doctors = File.ReadAllText("DoctorsList.txt");
            Console.WriteLine(doctors);

            var doc_id = File.ReadAllLines("doctors\\doctorid.txt")
              .Select(l => l.Split(new[] { '=' }))
              .ToDictionary(s => s[0].Trim(), s => s[1].Trim());

            var doc_fees = File.ReadAllLines("doctors\\doctorfees.txt")
              .Select(l => l.Split(new[] { '=' }))
              .ToDictionary(s => s[0].Trim(), s => s[1].Trim());

            try
            {
            Day:
                Console.WriteLine("\n\nSelect Appointment Day");
                string day = Console.ReadLine();
                if (day == "monday" || day == "Monday" || day == "MONDAY")
                {
                    Console.Clear();
                    Title();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    string monday = File.ReadAllText("doctors\\1_monday.txt");
                    Console.WriteLine("\n" + monday);
                }
                else if (day == "tuesday" || day == "Tuesday" || day == "TUESDAY")
                {
                    Console.Clear();
                    Title();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    string tuesday = File.ReadAllText("doctors\\2_tuesday.txt");
                    Console.WriteLine("\n" + tuesday);
                }
                else if (day == "wednesday" || day == "Wednesday" || day == "WEDNESDAY")
                {
                    Console.Clear();
                    Title();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    string wednesday = File.ReadAllText("doctors\\3_wednesday.txt");
                    Console.WriteLine("\n" + wednesday);
                }
                else if (day == "thursday" || day == "Thursday" || day == "THURSDAY")

                {
                    Console.Clear();
                    Title();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    string thursday = File.ReadAllText("doctors\\4_thursday.txt");
                    Console.WriteLine("\n" + thursday);
                }
                else if (day == "friday" || day == "Friday" || day == "FRIDAY")
                {
                    Console.Clear();
                    Title();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    string friday = File.ReadAllText("doctors\\5_friday.txt");
                    Console.WriteLine("\n" + friday);
                }
                else if (day == "saturday" || day == "Saturday" || day == "sunday" || day == "Sunday")
                {
                    Console.WriteLine(" Saturday's and Sunday's are OFF ");
                    goto Day;
                }
                else
                {
                    Console.WriteLine("Invalid Day Entered");
                    goto Day;
                }

                Console.WriteLine("\nEnter Doctor's ID for Appointment");
                string sel_doc = Console.ReadLine();
                string doc_name = doc_id[sel_doc];
                Console.Clear();
                Console.WriteLine("\nAssign Appointment Number");
                string appointment_num = Console.ReadLine();
                Console.WriteLine("\nEnter Patient's Name");
                string pat_name = Console.ReadLine();
                Console.WriteLine("\nEnter Patient's Age");
                string pat_age = Console.ReadLine();
                Console.WriteLine("\nEnter Patient's Contact Number");
                string pat_contact = Console.ReadLine();
                Console.WriteLine("\nEnter Patient's CNIC");
                string pat_cnic = Console.ReadLine();

                string fees = doc_fees[sel_doc];

                DateTime now = DateTime.Now;
                string all_appointments = "Appointments//All_Appointments.txt";
                string appointment = "Appointments//" + pat_cnic + ".txt";
                File.WriteAllText(appointment, Environment.NewLine + "Appointment Receipt:\n" + "--------------------" + "\nAppointment Day:  " + day + "\nAppointment For:  " + doc_name + "\nAppointment Number:  " + appointment_num + "\nPatient's Name:  " + pat_name + "\nPatient's Age:  " + pat_age + "\nPatient's Phone number:  " + pat_contact + "\nPatient's CNIC:  " + pat_cnic + "\nYour charges:  " + fees + "\nDate & Time:  " + now + "\n::::\n\n");
                File.AppendAllText(all_appointments, Environment.NewLine + "Appointment Receipt:\n" + "--------------------" + "\nAppointment Day:  " + day + "\nAppointment For:  " + doc_name + "\nAppointment Number:  " + appointment_num + "\nPatient's Name:  " + pat_name + "\nPatient's Age:  " + pat_age + "\nPatient's Phone number:  " + pat_contact + "\nPatient's CNIC:  " + pat_cnic + "\nYour charges:  " + fees + "\nDate & Time:  " + now + "\n::::\n\n");

                Console.Clear();
                string appointment_receipt = File.ReadAllText(appointment);
                Console.WriteLine("Your Appointment has been created\n\n");
                Console.WriteLine(appointment_receipt);

                Console.WriteLine("\n\nDo you want to Continue-(yes/no):");
                string opt = Console.ReadLine();
                if (opt == "yes" || opt == "Yes" || opt == "y" || opt == "YES")
                {
                    Console.Clear();
                    Program.Title();
                    Program.Choice();
                }
                else
                {
                    Console.Clear();
                    Program.Exit();
                }

            }
            catch (Exception)
            {

                Console.WriteLine("\nSomething went wrong");
            }



        }
        //Search for appointment via cnic
        static void SearchAppointment()
        {
            Program.Title();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Enter Patient's CNIC");
            string pat_cnic = Console.ReadLine();

            Console.WriteLine("\n\n------------------------------------------------");

            Console.WriteLine(pat_cnic + "'s Appointment List");
            Console.WriteLine("------------------------------------------------");

            if (File.Exists("Appointments//" + pat_cnic + ".txt"))
            {
                string content = File.ReadAllText("Appointments//" + pat_cnic + ".txt");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("\n\nYou do not have any appointment");
            }

            Console.WriteLine("\nDo you want to Continue-(yes/no):");
            string opt = Console.ReadLine();
            if (opt == "yes" || opt == "Yes" || opt == "y" || opt == "YES")
            {
                Console.Clear();
                Program.Title();
                Program.Choice();
            }
            else
                Console.Clear();
            Program.Exit();
        }

    

        //To see all appointments in system
        static void AppointmentList()
        {
            Program.Title();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\t\t\t\t__________________ ");
            Console.WriteLine("\t\t\t\t--------------------------------------------------");
            Console.WriteLine("\t\t\t\t||\t\t Appointment List:\t\t||");
            Console.WriteLine("\t\t\t\t__________________ ");
            Console.WriteLine("\t\t\t\t-------------------------------------------------- ");

            string all_appointments = "Appointments//All_Appointments.txt";

            if (File.Exists(all_appointments))
            {
                string content = File.ReadAllText(all_appointments);
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("No appointments exists");
            }


            Console.WriteLine("\n\nDo you want to Continue-(yes/no):");
            string opt = Console.ReadLine();
            if (opt == "yes" || opt == "Yes" || opt == "y" || opt == "YES")
            {
                Console.Clear();
                Program.Title();
                Program.Choice();
            }
            else
            {
                Console.Clear();
                Program.Exit();
            }
        }
        #endregion



        #region Blood Bank

        //To donate blood
        static void Donate()
        {
            Program.Title();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine("\t\t\t\t\tEnter Name:");
            Console.Write("\t\t\t\t\t");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tEnter your Medical ID:");
            Console.Write("\t\t\t\t\t");
            string id = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tEnter your Blood group:");
            Console.Write("\t\t\t\t\t");
            string blood = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tNumber of Bottle Donate:");
            Console.Write("\t\t\t\t\t");
            string no = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("\t\t\t\t\tEnter your age:");
            Console.Write("\t\t\t\t\t");
            int age = Convert.ToInt32(Console.ReadLine());
            if (age <= 18)
            {
                Console.WriteLine("\n\t\t\t\t\tSorry!\n\t\t\t\t\tYour'e Under-Age:");
                Console.WriteLine("\n\t\t\t\t\tDo you want to go to our main menu?-(yes/no)");
                string yes = Console.ReadLine();
                if (yes == "yes" || yes == "ys" || yes == "YES")
                {
                    Program.Choice();
                }
                else
                    Console.Clear();
                Program.Exit();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tEnter phone number of Donor:");
            Console.Write("\t\t\t\t\t");
            string phone = (Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tEnter E-mail of Donor:");
            Console.Write("\t\t\t\t\t");

            string email = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tYour data has been successfully added to our system:\n\t\t\t\t\t Thanks:");
            Console.Write("\t\t\t\tDo you want Receipt<yes/no>:");
            string opt = Console.ReadLine();
            if (opt == "y" || opt == "yes")
            {
                Console.Clear();
                Program.Title();
                DateTime now = DateTime.Now;
                string Url = "receipt.txt";
                File.AppendAllText(Url, Environment.NewLine + "\n\t\t\t\t\tBlood Donor Receipt:" + "\n\t\t\t\t\tName:" + name + "\n\t\t\t\t\tMedical ID:" + id + "\n\t\t\t\t\tBlood Group:" + blood + "\n\t\t\t\t\tNo of Blood:" + no + "\n\t\t\t\t\tYour Age:" + age + "\n\t\t\t\t\tDonor Phone number:" + phone + "\n\t\t\t\t\tDonor E-mail Address:" + email + "\n\t\t\t\t\tDate & Time:" + now + "\n\t\t\t\t\t\t::::");

                int Row = File.ReadAllLines(Url).Length;
                string[] Students = new string[Row];
                StreamReader SR = new StreamReader(Url);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;


                Console.Write("\t\t\t\t\t Donar Receipt:" + "\n\t\t\t\t\tName:" + name + "\n\t\t\t\t\tMedical Id:" + id + "\n\t\t\t\t\tBlood Group:" + blood + "\n\t\t\t\t\tNumber of Donates:" + no + "\n\t\t\t\t\tYour Age:" + age + "\n\t\t\t\t\tDonar Phone Number:" + phone + "\n\t\t\t\t\tDonar E-mail Address:" + email + "\n\t\t\t\t\tDate & Time:" + now);
            }

            else
            {
                Console.WriteLine("\t\t\t\t\tEnter Data Successfully");

            }
            Console.WriteLine("\n\t\t\t\t\tDo you want to continue-(yes/no):");
            string po = Console.ReadLine();
            if (po == "yes" || po == "YES" || po == "y")
            {
                Console.Clear();
                Program.Title();
                Program.Choice();
            }

        }

        // To see donor's list

        static void List()
        {
            Program.Title();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\t\t\t\t__________________ ");
            Console.WriteLine("\t\t\t\t--------------------------------------------------");
            Console.WriteLine("\t\t\t\t||\t\t Blood Donor List:\t\t||");
            Console.WriteLine("\t\t\t\t__________________ ");
            Console.WriteLine("\t\t\t\t-------------------------------------------------- ");

            string content = File.ReadAllText("receipt.txt");

            Console.WriteLine(content);
            Console.WriteLine("\t\t\t\t\t\t::::");
            Console.WriteLine("\n\t\t\t\tDo you want to Continue-(yes/no):");
            string opt = Console.ReadLine();
            if (opt == "yes" || opt == "Yes" || opt == "y" || opt == "YES")
            {
                Console.Clear();
                Program.Title();
                Program.Choice();
            }
            else
                Console.Clear();
            Program.Exit();
        }

        //To Request Blood
        static void ToRequestBlood()
        {
            Console.Clear();
            Program.Title();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Program.Category();
            Console.WriteLine("\t\t\t\t Blood group-A+ (Available) ");
            Console.WriteLine("\t\t\t\t -------------------------------------------------");

            Console.WriteLine("\t\t\t\t Blood Group-B+ (Available) ");
            Console.WriteLine("\t\t\t\t--------------------------------------------------");

            Console.WriteLine("\t\t\t\t Blood Group-O+ (Available) ");
            Console.WriteLine("\t\t\t\t -------------------------------------------------");

            Console.WriteLine("\t \t\t\t Blood Group-AB+ (Not Available) ");
            Console.WriteLine("\t\t\t\t -------------------------------------------------");

            Console.WriteLine("\t \t\t\t Blood Group-A- (Available) ");
            Console.WriteLine("\t\t\t\t -------------------------------------------------");

            Console.WriteLine("\t \t\t\t Blood Group-B- (Available) ");
            Console.WriteLine("\t\t\t\t -------------------------------------------------");

            Console.WriteLine("\t \t\t\t Blood Group-O- (Not Available) ");
            Console.WriteLine("\t\t\t\t -------------------------------------------------");

            Console.WriteLine("\t \t\t\t Blood Group AB- (Available) ");
            Console.WriteLine("\t\t\t\t-------------------------------------------------");

            Console.Write("\t\t\t\t Do you want to proceed your Process-(yes/no):");
            string req = Console.ReadLine();
            if (req == "y" || req == "yes" || req == "YES")
            {
                Console.Clear();
                Program.Title();
                Program.Category();
                Console.WriteLine("\t\t\t\t\tEnter Name:");
                Console.Write("\t\t\t\t\t");
                string name = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\tEnter your Medical ID:");
                Console.Write("\t\t\t\t\t");
                string id = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\tEnter Blood group you Required:");
                Console.Write("\t\t\t\t\t");
                string blood = Console.ReadLine();
                Console.WriteLine();
                if (blood == "O-" || blood == "o-" || blood == "AB+" || blood == "ab+")
                {
                    Console.WriteLine("\t\t\t\tSorry!...This Blood Group is not available at this time");
                    Console.WriteLine("\t\t\t\tDo you want to go to main menu-(yes/no)");
                    string go = Console.ReadLine();
                    if (go == "Yes" || go == "yes" || go == "y")
                    {
                        Console.Clear();
                        Program.Title();
                        Program.Choice();
                    }
                    else
                    {
                        Console.Clear();
                        Program.Exit();
                        return;
                    }
                }
                else if (blood == "A+" || blood == "a+" || blood == "B+" || blood == "b+" || blood == "O+" || blood == "o+" || blood == "A-" || blood == "a-" || blood == "B-" || blood == "b-" || blood == "AB-" || blood == "ab-")
                { Console.WriteLine("\t\t\t\t\tBlood is Available"); }
                else
                {
                    Console.WriteLine("\n\t\t\t\t\tThere is no category available for this group");
                    Console.WriteLine("\t\t\t\tDo you want to go to main menu-(yes/no)");
                    string go = Console.ReadLine();
                    if (go == "Yes" || go == "yes" || go == "y")
                    {
                        Console.Clear();
                        Program.Title();
                        Program.Choice();
                    }
                    else
                    {
                        Console.Clear();
                        Program.Exit();
                        return;
                    }
                    return;
                }
                Console.WriteLine("\t\t\t\t\tNumber of Bottles you Required:");
                Console.Write("\t\t\t\t\t");
                int no = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\tEnter your age:");
                Console.Write("\t\t\t\t\t");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine("\t\t\t\t\tEnter phone number of Acceptor:");
                Console.Write("\t\t\t\t\t");
                string phone = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\tEnter e-mail of Acceptor:");
                Console.Write("\t\t\t\t\t");
                string email = Console.ReadLine();
                Console.WriteLine();
                int payment = 4000 * no;
                Console.WriteLine("\t\t\t\tYour Charges:" + payment);
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\tYour data has been successfully added to our system:\n\t\t\t\t\t Thanks:");
                Console.Write("\t\t\t\tDo you want Receipt<yes/no>:");
                string opt = Console.ReadLine();
                Console.WriteLine("\t\t\t\t\tEnter Data Successfully");
                if (opt == "y" || opt == "yes")
                {
                    Console.Clear();
                    Program.Title();
                    DateTime now = DateTime.Now;
                    string Url = "Request.txt";
                    File.AppendAllText(Url, Environment.NewLine + "\n\t\t\t\t\tBlood Acceptor Receipt:" + "\n\t\t\t\t\tName:" + name + "\n\t\t\t\t\tMedical ID:" + id + "\n\t\t\t\t\tBlood Group:" + blood + "\n\t\t\t\t\tNo of Blood:" + no + "\n\t\t\t\t\tAcceptor Phone number:" + phone + "\n\t\t\t\t\tAcceptor E-mail Address:" + email + "\n\t\t\t\t\tYour charges:" + payment + "\n\t\t\t\t\tDate & Time:" + now + "\n\t\t\t\t\t::::");

                    int Row = File.ReadAllLines(Url).Length;
                    string[] Students = new string[Row];
                    StreamReader SR = new StreamReader(Url);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;


                    Console.WriteLine("\t\t\t\t\tBlood Acceptor Receipt:" + "\n\t\t\t\t\tName:" + name + "\n\t\t\t\t\tMedical Id:" + id + "\n\t\t\t\t\tBlood Group:" + blood + "\n\t\t\t\t\tNumber of Request:" + no + "\n\t\t\t\t\tAcceptor Phone Number:" + phone + "\n\t\t\t\t\tAcceptor E-mail Address:" + email + "\n\t\t\t\t\tYour charges:" + payment + "\n\t\t\t\t\tDate & Time:" + now);
                    Console.WriteLine("\t\t\t\tDo you want to go to main menu-(yes/no)");

                    string go = Console.ReadLine();
                    if (go == "Yes" || go == "yes" || go == "y")
                    {
                        Console.Clear();
                        Program.Title();
                        Program.Choice();
                    }
                    else
                    {
                        Console.Clear();
                        Program.Exit();
                        return;
                    }
                    return;
                }

                else
                {
                    Console.Clear();
                    Program.Exit();
                }

            }

            else
            {
                Console.Clear();
                Program.Exit();
            }



        }

        //Blood Category
        static void Category()
        {

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\t\t\t\t__________________ ");
            Console.WriteLine("\t\t\t\t--------------------------------------------------");
            Console.WriteLine("\t\t\t\t||\tEnter which category Blood you want:\t||");
            Console.WriteLine("\t\t\t\t__________________ ");
            Console.WriteLine("\t\t\t\t-------------------------------------------------- ");

            Console.WriteLine();
        }

        //To see blood Request List
        static void ReqList()
        {
            Program.Title();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\t\t\t\t__________________ ");
            Console.WriteLine("\t\t\t\t--------------------------------------------------");
            Console.WriteLine("\t\t\t\t||\t\t Blood Request List:\t\t||");
            Console.WriteLine("\t\t\t\t__________________ ");
            Console.WriteLine("\t\t\t\t-------------------------------------------------- ");

            string content = File.ReadAllText("Request.txt");

            Console.WriteLine(content);

            Console.WriteLine("\n\t\t\t\tDo you want to Continue-(yes/no):");
            string opt = Console.ReadLine();
            if (opt == "yes" || opt == "Yes" || opt == "y" || opt == "YES")
            {
                Console.Clear();
                Program.Title();
                Program.Choice();
            }
            else
            {
                Console.Clear();
                Program.Exit();
            }
        }



        #endregion


        //Exit from system
        static void Exit()
        {
            Program.Title();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n\t\t\t\tThanks for Choosing our Hospital HealthCare System:\n\t\t\t\tWe are waiting for you to come here again!");

        }
    }
}