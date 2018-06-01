# IMAP
IMAP protocol (C#)

A simple application created to show how IMAP works, which is one of the application layer protocols. 

User's interaction is accepted through console window, allowing you to take control of your e-mail account (only if the server supports IMAP commands).

Source: https://tools.ietf.org/html/rfc3501

All functions are working, except these were left untouched:
  > TARTTLS - because TSL is not needed when using TCP/SSL.
  > AUTHENTICATE - because LOGIN function takes care of that.
  > APPEND - because it's very complicated and IMAP is used for accessing messages, not saving/editing them.
  > X<atom> - because it's used for experimental/expansion related stuff - not needed.

Created using Visual Studio 2017.
