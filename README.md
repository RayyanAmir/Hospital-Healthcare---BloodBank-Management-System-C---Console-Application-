  <h1>Hospital Management Console Application</h1>
    <p>The Hospital Management Console Application is designed to streamline various administrative tasks within a healthcare facility. This program allows users to manage appointments, maintain a blood bank database, and provide essential information through a user-friendly console interface. Below are the key features and functionalities of the application:</p>

    <h2>Key Features:</h2>
    <h3>Full-Screen Console Display:</h3>
    <ul>
        <li>The application opens in full-screen mode to provide a better user experience, using Windows API calls.</li>
    </ul>

    <h3>Main Menu:</h3>
    <ul>
        <li>Upon launching, the application displays a welcome screen with the hospital's name and an aesthetically pleasing console output.</li>
        <li>Users can select from various options such as booking appointments, searching for appointments, viewing all appointments, and accessing blood bank services.</li>
    </ul>

    <h3>Doctor's Appointment Management:</h3>
    <ul>
        <li><strong>Booking Appointments:</strong>
            <ul>
                <li>Users can book appointments with doctors for specific days of the week.</li>
                <li>The application lists available doctors along with their IDs and fees.</li>
                <li>Appointment details such as the patient's name, age, contact number, and CNIC are recorded.</li>
                <li>An appointment receipt is generated and saved for future reference.</li>
            </ul>
        </li>
        <li><strong>Searching Appointments:</strong>
            <ul>
                <li>Users can search for their appointments using their CNIC.</li>
                <li>The application displays all appointments associated with the entered CNIC.</li>
            </ul>
        </li>
        <li><strong>Viewing All Appointments:</strong>
            <ul>
                <li>Admins or users can view a comprehensive list of all appointments in the system.</li>
            </ul>
        </li>
    </ul>

    <h3>Blood Bank Management:</h3>
    <ul>
        <li><strong>Donating Blood:</strong>
            <ul>
                <li>Users can enter their details to donate blood, including name, medical ID, blood group, number of bottles donated, age, phone number, and email.</li>
                <li>A receipt is generated and saved for the donation.</li>
            </ul>
        </li>
        <li><strong>Requesting Blood:</strong>
            <ul>
                <li>Users can request specific blood types.</li>
                <li>The application checks availability and proceeds with the request if the blood type is available.</li>
            </ul>
        </li>
        <li><strong>Viewing Donor List:</strong>
            <ul>
                <li>Admins or users can view a list of all blood donors in the system, including their details and donation records.</li>
            </ul>
        </li>
    </ul>

    <h3>Navigation and Exit Options:</h3>
    <ul>
        <li>After completing any action, users are prompted to continue with other tasks or exit the application.</li>
        <li>The application handles invalid inputs gracefully and guides users back to the main menu.</li>
    </ul>

    <h2>Implementation Details:</h2>
    <ul>
        <li>The application is developed in C# and utilizes various namespaces such as System, System.Collections.Generic, System.IO, and System.Linq to handle file operations and manage data efficiently.</li>
        <li>External libraries from Windows API (kernel32.dll and user32.dll) are used to control the console window behavior.</li>
        <li>Data storage is managed using text files to maintain doctor details, appointments, and blood donor information.</li>
    </ul>

    <h2>Code Structure:</h2>
    <ul>
        <li><strong>Main Method:</strong>
            <ul>
                <li>Initializes the console settings and displays the main menu.</li>
            </ul>
        </li>
        <li><strong>Title Method:</strong>
            <ul>
                <li>Displays the hospital's welcome screen with a styled output.</li>
            </ul>
        </li>
        <li><strong>Choice Method:</strong>
            <ul>
                <li>Handles user input from the main menu and navigates to the corresponding functionalities.</li>
            </ul>
        </li>
        <li><strong>Appointment Management Methods:</strong>
            <ul>
                <li><strong>Appointment:</strong> Books a new doctor's appointment.</li>
                <li><strong>SearchAppointment:</strong> Searches for appointments using CNIC.</li>
                <li><strong>AppointmentList:</strong> Displays all appointments in the system.</li>
            </ul>
        </li>
        <li><strong>Blood Bank Management Methods:</strong>
            <ul>
                <li><strong>BloodBank:</strong> Displays the blood bank menu and handles blood donation, request, and viewing donor lists.</li>
                <li><strong>Donate:</strong> Records blood donation details.</li>
                <li><strong>ToRequestBlood:</strong> Manages blood requests and checks availability.</li>
                <li><strong>List:</strong> Displays a list of all blood donors.</li>
            </ul>
        </li>
        <li><strong>Exit Method:</strong>
            <ul>
                <li>Safely exits the application.</li>
            </ul>
        </li>
    </ul>

    <h2>Technology and Language Used:</h2>
    <ul>
        <li><strong>Language:</strong> The application is developed in C#.</li>
        <li><strong>Platform:</strong> This is a console-based program, designed to run in a Windows environment.</li>
        <li><strong>APIs:</strong> Utilizes Windows API for full-screen console display and other console manipulations.</li>
        <li><strong>Data Storage:</strong> Manages data using text files for persistence of doctor details, appointments, and blood donor information.</li>
    </ul>

    <p>The Hospital Management Console Application aims to simplify hospital administrative tasks, making it easier for patients and staff to manage appointments and blood donations efficiently. The user-friendly interface and comprehensive functionalities ensure smooth operation and better patient care management.</p>
