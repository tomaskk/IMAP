using System;

namespace IMAP
{
    public class Program_Main
    {
        static int caseSwitch = 0;

        static void Main(string[] args)
        {
            ImapClient ic = new ImapClient();

            for (;;)
            {
                if (caseSwitch == -1)
                    break;

                ShowMenu();

                Console.Write("A" + ic.commandNumber + ":  Preferred function : ");
                bool valid = Int32.TryParse(Console.ReadLine(), out caseSwitch);
                
                if (valid)
                {
                    switch (caseSwitch)
                    {
                        case 0:         // exit
                            if (ic.userAvailable) { ic.DcFromGmail(); }
                            caseSwitch = -1;
                            break;

                        case 1:         // log in
                            if (!ic.userAvailable) { ic.ConnectToGmail(); }
                            else { Console.WriteLine("ERR : User has already logged in"); }
                            break;

                        case 2:         // log off
                            if (ic.userAvailable) { ic.DcFromGmail(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 3:         // inbox status
                            if (ic.userAvailable) { ic.DefaultStatus(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 4:         // Show all mailboxes
                            if (ic.userAvailable) { ic.SelectMailboxes(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 5:         // Select mailbox
                            if (ic.userAvailable) { ic.SelectMailbox(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 6:         // Close mailbox
                            if (ic.userAvailable) { ic.ClosetMailbox(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 7:         // Fetch Header
                            if (ic.userAvailable) { ic.FetchHead(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 8:         // Fetch date
                            if (ic.userAvailable) { ic.FetchDate(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 9:         // Flags: mark all as read
                            if (ic.userAvailable) { ic.SetAllRead(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 10:        // Flags: mark 1x as unread
                            if (ic.userAvailable) { ic.SetAsUnread(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 11:        // Expunge e-mail
                            if (ic.userAvailable) { ic.DeleteLetter(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 12:        // Search by criteria
                            if (ic.userAvailable) { ic.SearchByText(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 13:        // Search unseen UIDs
                            if (ic.userAvailable) { ic.SearchUnseenUIDs(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 14:        // Copy e-mail
                            if (ic.userAvailable) { ic.Copy(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 15:        // Create new mailbox
                            if (ic.userAvailable) { ic.CreateNew(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 16:        // Rename mailbox
                            if (ic.userAvailable) { ic.RenameMail(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 17:        // Delete mailbox
                            if (ic.userAvailable) { ic.DeleteMail(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 18:        // Check answer's validity
                            if (ic.userAvailable) { ic.DoNothing(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 19:        // Examine mailbox
                            if (ic.userAvailable) { ic.ExamineMailbox(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 20:        // Subscribe to a mailbox
                            if (ic.userAvailable) { ic.SubscribeMailbox(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 21:        // Unubscribe from a mailbox
                            if (ic.userAvailable) { ic.UnsubscribeMailbox(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 22:        // Check subscribes mailboxes
                            if (ic.userAvailable) { ic.CheckSubscribed(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 23:        // All e-mail IDs
                            if (ic.userAvailable) { ic.UIDSearch(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        case 24:        // All e-mail flags
                            if (ic.userAvailable) { ic.GetFlags(); }
                            else { Console.WriteLine("ERR : User is not logged in"); }
                            break;

                        default:
                            Console.WriteLine("Wrong choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong choice.");
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n_________________________________________");
            Console.WriteLine("IMAP protocol // Gmail services         *");
            Console.WriteLine("1.  Log in                              *"); // LOGIN
            Console.WriteLine("2.  Log off                             *"); // LOGOUT
            Console.WriteLine("3.  Inbox status                        *"); // STATUS + CAPABILITY
            Console.WriteLine("4.  All available mailboxes             *"); // LIST
            Console.WriteLine("5.  Select mailbox                      *"); // SELECT
            Console.WriteLine("6.  Close mailbox                       *"); // CLOSE
            Console.WriteLine("7.  Fetch header                        *"); // FETCH HEADER
            Console.WriteLine("8.  Fetch internal date                 *"); // FETCH DATE
            Console.WriteLine("9.  Set Flag: make all e-mails READ     *"); // STORE
            Console.WriteLine("10. Set Flag: mark e-mail as unread     *"); // STORE
            Console.WriteLine("11. Delete (expunge) e-mail             *"); // STORE + EXPUNGE
            Console.WriteLine("12. Search e-mails by criteria          *"); // SEARCH TEXT
            Console.WriteLine("13. Search unseen e-mail IDs            *"); // SEARCH UNSEEN
            Console.WriteLine("14. Copy e-mail                         *"); // COPY
            Console.WriteLine("15. Create a new mailbox                *"); // CREATE
            Console.WriteLine("16. Rename an existing mailbox          *"); // RENAME
            Console.WriteLine("17. Delete an existing mailbox          *"); // DELETE
            Console.WriteLine("18. Use NOOP command 3x                 *"); // NOOP --
            Console.WriteLine("19. Examine Mailbox                     *"); // EXAMINE
            Console.WriteLine("20. Subscribe to a mailbox              *"); // SUBSCRIBE
            Console.WriteLine("21. Unsubscribe from a mailbox          *"); // UNSUBSCRIBE
            Console.WriteLine("22. Check subscribed mailboxes          *"); // LSUB
            Console.WriteLine("23. Get e-mail's IDs                    *"); // UID SEARCH
            Console.WriteLine("24. Get e-mail's flags                  *"); // FETCH FLAGS
            Console.WriteLine("0.  Exit                                *");
            Console.WriteLine("_________________________________________"); // TOTAL: 21.  (Left: STARTTLS     - Already using TCP/SSL, no need for TSL, 
        }                                                                   //                    AUTHENTICATE - LOGIN takes care of authentication,   
    }                                                                       //                    APPEND       - Very complicated + IMAP is used for
}                                                                           //                                   accessing but not saving/editing e-mails,
                                                                            //                    X<atom>      - For Experimental/Expansion - not needed)       