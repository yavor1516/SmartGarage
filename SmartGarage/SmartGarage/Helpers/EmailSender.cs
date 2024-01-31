using System.Net;
using System.Net.Mail;

namespace SmartGarage.Helpers
{
    public class EmailSender
    {
        public void SendEmail(string userEmail, string generatedPassword)
        {


            // Recipient's email address
            string RecieverEmail = "milen316@gmail.com";
            string senderEmail = "smartgarageweb@gmail.com";
            string fromPassword = "bpcgnlzkcmmwuirz";
            // Create a MailMessage object
            MailMessage mail = new MailMessage(senderEmail, userEmail);
            mail.Subject = "Test Email";
            mail.IsBodyHtml = true;

            //Replace htmlBody string in frontEnd int the future!!!!!
            string htmlBody = @"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Email Notification</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            padding: 20px;
        }
        .container {
            max-width: 600px;
            margin: 0 auto;
            background-color: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h2 {
            color: #333;
        }
        p {
            color: #666;
        }
        .password {
            font-weight: bold;
            color: #007bff;
        }
    </style>
</head>
<body>
    <div class=""container"">
        <h2>Password Notification</h2>
        <p>Hello,</p>
        <p>Your password has been successfully generated. Here is your new password:</p>
        <p class=""password"">" + generatedPassword + @"</p>
        <p>Please keep this password secure and do not share it with anyone.</p>
        <p>If you did not request this password, please disregard this email.</p>
        <p>Thank you,</p>
        <p>The Smart Garage Team</p>
    </div>
</body>
</html>";

            mail.Body = htmlBody;

            // Create a SmtpClient object
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587; // Port number for SMTP (587 for TLS/STARTTLS)
            smtpClient.Credentials = new NetworkCredential(senderEmail, fromPassword);
            smtpClient.EnableSsl = true; // Enable SSL/TLS encryption

            try
            {
                // Send the email
                smtpClient.Send(mail);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }
        
    }

}
