using System;
using System.Linq;

namespace TicketSales.Constants.Tickets
{
    public static class Messages
    {
        public static string TicketAdded = "Ticked was added";
        public static string TicketUpdated = "Ticked was updated";
        public static string TicketRemoved = "Ticked was removed";

        public static string CompanyAdded = "Company was added";
        public static string CompanyUpdated = "Company was updated";
        public static string CompanyRemoved = "Company was removed";

        public static string TicketPurchased = "Ticket was purchased";

        public static string UserNotFound = "User Not Found!";
        public static string PasswordError = "Wrong Password!";
        public static string SuccessfulLogin = "You logged in";
        public static string UserAlreadyExists = "User already exist!";

        public static string Successful = "Successful";
        public static string AuthorizationDenied = "User or password was wrong";
    }
}
