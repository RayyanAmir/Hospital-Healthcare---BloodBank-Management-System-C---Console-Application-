# Hospital & BloodBank Management Console Application

The Hospital Management Console Application is designed to streamline various administrative tasks within a healthcare facility. This program allows users to manage appointments, maintain a blood bank database, and provide essential information through a user-friendly console interface.

## Language: C#

## Features:
- **Full-Screen Console Display:** 
  - The application opens in full-screen mode to provide a better user experience, using Windows API calls.

- **Main Menu:** 
  - Upon launching, the application displays a welcome screen with the hospital's name and an aesthetically pleasing console output.
  - Users can select from various options such as booking appointments, searching for appointments, viewing all appointments, and accessing blood bank services.

- **Doctor's Appointment Management:**
  - **Booking Appointments:**
    - Users can book appointments with doctors for specific days of the week.
    - The application lists available doctors along with their IDs and fees.
    - Appointment details such as the patient's name, age, contact number, and CNIC are recorded.
    - An appointment receipt is generated and saved for future reference.
  - **Searching Appointments:**
    - Users can search for their appointments using their CNIC.
    - The application displays all appointments associated with the entered CNIC.
  - **Viewing All Appointments:**
    - Admins or users can view a comprehensive list of all appointments in the system.

- **Blood Bank Management:**
  - **Donating Blood:**
    - Users can enter their details to donate blood, including name, medical ID, blood group, number of bottles donated, age, phone number, and email.
    - A receipt is generated and saved for the donation.
  - **Requesting Blood:**
    - Users can request specific blood types.
    - The application checks availability and proceeds with the request if the blood type is available.
  - **Viewing Donor List:**
    - Admins or users can view a list of all blood donors in the system, including their details and donation records.

- **Navigation and Exit Options:**
  - After completing any action, users are prompted to continue with other tasks or exit the application.
  - The application handles invalid inputs gracefully and guides users back to the main menu.

## Implementation Details:
- **Development Environment:**
  - The application is developed in C#.
  - Utilizes various namespaces such as System, System.Collections.Generic, System.IO, and System.Linq to handle file operations and manage data efficiently.
  - External libraries from Windows API (kernel32.dll and user32.dll) are used to control the console window behavior.
  - Data storage is managed using text files to maintain doctor details, appointments, and blood donor information.

## Code Structure:
- **Main Method:**
  - Initializes the console settings and displays the main menu.
- **Title Method:**
  - Displays the hospital's welcome screen with a styled output.
- **Choice Method:**
  - Handles user input from the main menu and navigates to the corresponding functionalities.
- **Appointment Management Methods:**
  - `Appointment`: Books a new doctor's appointment.
  - `SearchAppointment`: Searches for appointments using CNIC.
  - `AppointmentList`: Displays all appointments in the system.
- **Blood Bank Management Methods:**
  - `BloodBank`: Displays the blood bank menu and handles blood donation, request, and viewing donor lists.
  - `Donate`: Records blood donation details.
  - `ToRequestBlood`: Manages blood requests and checks availability.
  - `List`: Displays a list of all blood donors.
- **Exit Method:**
  - Safely exits the application.

The Hospital Management Console Application aims to simplify hospital administrative tasks, making it easier for patients and staff to manage appointments and blood donations efficiently. The user-friendly interface and comprehensive functionalities ensure smooth operation and better patient care management.
