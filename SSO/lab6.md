# SSO - Single sign-on
A web application providing user authentication via SSO using 4 identity providers (Github, LinkedIn, Facebook, Google);
## Table of Contents
 - General information
 - Technologies
 - Setup

 ## General Information

Using SSO in your application represents a secure alternative to classical authentication using
login + passwords. On one hand it makes the life of the user much easier because they don’t need
to remember yet another password. On the other hand, the security savvy users can get worried
about what data is sent when using such logging systems. The task for this week’s laboratory
work is to write an application to analyze the sensitive data that is sent to applications when
using SSO.
The application should be able to authenticate a user using at least 3 identity providers
(e.g. Facebook, Gmail, Twitter etc.). After authenticating using one of those services, the
application should output on screen data that it has received from the identity providers (e.g.
user’s name, age, gender, email etc.).

To summarize, my application:
 - Offer user authentication via SSO using at 4 identity providers (Facebook, Gmail, GitHub, Linkedin);
 - Configure SSO integration to get as much as possible data about the end-user;
 -  Output all data which was provided by the identity providers

## Technologies

For this laboratory work I used following technologies:

 - JavaScript
 - HTML
 - Bootstrap
 - XAMPP
 - Apache server

 ## Setup

 To run this project, clone the repository and open the file in any browse, but make sure to host it on a web server. Note: to configure sso integration for an application you must obtain API_KEY/CLIENT_ID/CLIENT_SECRET from the needed identity provider, otherwise you won't be able to use sso authetication.
